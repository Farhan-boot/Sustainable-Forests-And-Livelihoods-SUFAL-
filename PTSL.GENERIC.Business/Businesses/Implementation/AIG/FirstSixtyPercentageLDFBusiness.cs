using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.AIG
{
    public class FirstSixtyPercentageLDFBusiness : BaseBusiness<FirstSixtyPercentageLDF>, IFirstSixtyPercentageLDFBusiness
    {
        private readonly GENERICUnitOfWork _unitOfWork;
        private readonly GENERICWriteOnlyCtx _writeOnlyCtx;
        private readonly GENERICReadOnlyCtx _readOnlyCtx;

        public FirstSixtyPercentageLDFBusiness(GENERICUnitOfWork unitOfWork, GENERICWriteOnlyCtx writeOnlyCtx, GENERICReadOnlyCtx readOnlyCtx)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _writeOnlyCtx = writeOnlyCtx;
            _readOnlyCtx = readOnlyCtx;
        }

        public override async Task<(ExecutionState executionState, FirstSixtyPercentageLDF entity, string message)> CreateAsync(FirstSixtyPercentageLDF entity)
        {
            // Check if grace month has valid grace month
            if (entity.HasGrace && (entity.GraceMonth < 0 || entity.GraceMonth > 3)) return (executionState: ExecutionState.Success, null!, "Grace month must not be less than 0 or greater than 3");

            // Check if first ldf is already created
            var firstLdfResult = await _readOnlyCtx.Set<FirstSixtyPercentageLDF>().CountAsync(x => x.AIGBasicInformationId == entity.AIGBasicInformationId);
            if (firstLdfResult > 0) return (executionState: ExecutionState.Success, null!, "First LDF Already exists.");

            // Check if aig exists and end date has not passed from current date
            var aigBasicInfoResult = await _readOnlyCtx.Set<AIGBasicInformation>().FirstOrDefaultAsync(x => x.Id == entity.AIGBasicInformationId);
            if (aigBasicInfoResult == default) return (executionState: ExecutionState.Success, null!, "AIG Information not found");
            if (aigBasicInfoResult.EndDate <= DateTime.Now) return (executionState: ExecutionState.Success, null!, "AIG End Date exceeded");

            // Start and end Date validation and add GraceMonth
            var startDate = entity.HasGrace ? aigBasicInfoResult.StartDate.AddMonths(entity.GraceMonth) : aigBasicInfoResult.StartDate;
            var endDate = aigBasicInfoResult.EndDate;
            if (startDate < endDate == false) return (executionState: ExecutionState.Success, null!, "Start date can not be greater or equal to end date.");

            // Calculate total repayment months including grace
            var totalRepaymentMonths = (endDate.Month - startDate.Month) + 12 * (endDate.Year - startDate.Year);

            using var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();

            try
            {
                entity.DisbursementDate = DateTime.Now;

                // First sixty LDF
                entity
                    .SetLDFAmountAndSecurityCharge(aigBasicInfoResult.TotalAllocatedLoanAmount)
                    .SetLDFAmountAndServiceCharge(aigBasicInfoResult.TotalAllocatedLoanAmount);

                // Calculate total repayment amount per month
                var perMonthRepaymentAmount = Math.Round((entity.LDFAmount + entity.ServiceChargeAmount) / totalRepaymentMonths, 2);

                await _writeOnlyCtx.Set<FirstSixtyPercentageLDF>().AddAsync(entity);
                await _writeOnlyCtx.SaveChangesAsync();

                // Repayments
                var repayments = new List<RepaymentLDF>();
                foreach (var m in Enumerable.Range(1, totalRepaymentMonths))
                {
                    repayments.Add(new RepaymentLDF
                    {
                        FirstSixtyPercentRepaymentAmount = perMonthRepaymentAmount,
                        RepaymentStartDate = startDate,
                        RepaymentEndDate = startDate.AddMonths(1),
                        FirstSixtyPercentageLDFId = entity.Id,
                        AIGBasicInformationId = aigBasicInfoResult.Id,
                        RepaymentSerial = m,
                        UpdatedAt = DateTime.Now,
                    });

                    startDate = startDate.AddMonths(1);
                }

                await _writeOnlyCtx.Set<RepaymentLDF>().AddRangeAsync(repayments);
                await _writeOnlyCtx.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return (executionState: ExecutionState.Success, null!, "Unknown error occurred.");
            }

            return (executionState: ExecutionState.Created, entity!, "Created successfully.");
        }
    }
}