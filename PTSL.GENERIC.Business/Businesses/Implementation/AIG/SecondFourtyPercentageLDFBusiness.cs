using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.AIG
{
    public class SecondFourtyPercentageLDFBusiness : BaseBusiness<SecondFourtyPercentageLDF>, ISecondFourtyPercentageLDFBusiness
    {
        private readonly GENERICUnitOfWork _unitOfWork;
        private readonly GENERICWriteOnlyCtx _writeOnlyCtx;
        private readonly GENERICReadOnlyCtx _readOnlyCtx;

        public SecondFourtyPercentageLDFBusiness(GENERICUnitOfWork unitOfWork, GENERICWriteOnlyCtx writeOnlyCtx, GENERICReadOnlyCtx readOnlyCtx)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _writeOnlyCtx = writeOnlyCtx;
            _readOnlyCtx = readOnlyCtx;
        }

        public override async Task<(ExecutionState executionState, SecondFourtyPercentageLDF entity, string message)> CreateAsync(SecondFourtyPercentageLDF entity)
        {
            // Validation
            var aigBasicInfoResult = await _readOnlyCtx.Set<AIGBasicInformation>().FirstOrDefaultAsync(x => x.Id == entity.AIGBasicInformationId);
            if (aigBasicInfoResult is null) return (executionState: ExecutionState.Success, null!, "AIG Information not found");
            if (aigBasicInfoResult.EndDate <= entity.StartDate) return (executionState: ExecutionState.Success, null!, "AIG End Date exceeded");

            // Check if first ldf is exists
            var firstLdfResult = await _readOnlyCtx.Set<FirstSixtyPercentageLDF>()
                .Where(x => x.AIGBasicInformationId == entity.AIGBasicInformationId)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();
            if (firstLdfResult == default) return (executionState: ExecutionState.Success, null!, "First LDF does not exists");

            // Check if second ldf is already exists
            var secondLdfResult = await _readOnlyCtx.Set<SecondFourtyPercentageLDF>()
                .Where(x => x.AIGBasicInformationId == entity.AIGBasicInformationId)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();
            if (secondLdfResult > 0) return (executionState: ExecutionState.Success, null!, "Second LDF already exists");

            // Serials
            //int? currentRepaymentSerial = null;
            //var maxRepaymentSerial = await _readOnlyCtx.Set<RepaymentLDF>().MaxAsync(x => x.RepaymentSerial);
            //if (maxRepaymentSerial == default) return (executionState: ExecutionState.Success, null!, "Repayment serial not found");

            var currentRepayment = await _readOnlyCtx.Set<RepaymentLDF>()
                .Where(x => x.Id == entity.StartRepaymentLDFId && x.AIGBasicInformationId == entity.AIGBasicInformationId)
                .Select(x => new { x.RepaymentSerial, x.IsPaymentCompleted })
                .FirstOrDefaultAsync();
            if (currentRepayment is null) return (executionState: ExecutionState.Success, null!, "No repayment found for this Id");
            //currentRepaymentSerial = currentRepaymentForCurrentDate.RepaymentSerial;

            try
            {
                // Check if repayments is consecutive for three months

                /*
                // Current serials
                var currentSerial = currentRepaymentForCurrentDate.RepaymentSerial;
                var serials = new List<int> { currentSerial - 1, currentSerial - 2 };
                if (currentRepaymentForCurrentDate.IsPaymentCompleted == false) serials.Add(currentSerial - 3);
                var repayments = await _readOnlyCtx.Set<RepaymentLDF>()
                    .CountAsync(x => serials.Contains(x.RepaymentSerial) && x.IsPaymentCompleted && x.AIGBasicInformationId == aigBasicInfoResult.Id);

                // Validate payments
                var totalValidRepayments = currentRepaymentForCurrentDate.IsPaymentCompleted ? 2 : 3;
                if (repayments != totalValidRepayments) return (executionState: ExecutionState.Success, null!, "Consecutive last three month is not paid");
                */
            }
            catch (Exception)
            {
                return (executionState: ExecutionState.Success, null!, "More than one repayments found");
            }

            using var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();
            try
            {
                entity.DisbursementDate = DateTime.Now;

                // Second forty LDF
                entity
                    .SetLDFAmountAndSecurityCharge(aigBasicInfoResult.TotalAllocatedLoanAmount)
                    .SetLDFAmountAndServiceCharge(aigBasicInfoResult.TotalAllocatedLoanAmount);

                entity.StartDate = DateTime.Now;

                // Repayments
                var repayments = await _readOnlyCtx.Set<RepaymentLDF>()
                    .Where(x => x.RepaymentSerial >= currentRepayment.RepaymentSerial && x.IsPaymentCompleted == false)
                    .Where(x => x.AIGBasicInformationId == aigBasicInfoResult.Id)
                    .ToListAsync();
                if (repayments is null) return (executionState: ExecutionState.Success, null!, "Repayments not found");

                // Calculate total repayment amount per month
                var perMonthRepaymentAmount = Math.Round((entity.LDFAmount + entity.ServiceChargeAmount) / (repayments.Count), 2);

                await _writeOnlyCtx.Set<SecondFourtyPercentageLDF>().AddAsync(entity);
                await _writeOnlyCtx.SaveChangesAsync();

                foreach (var repayment in repayments)
                {
                    repayment.SecondFortyPercentRepaymentAmount = perMonthRepaymentAmount;
                    repayment.SecondFourtyPercentageLDFId = entity.Id;

                    repayment.IsPaymentCompleted = false;
                    repayment.IsPaymentCompletedLate = false;
                    repayment.PaymentCompletedDateTime = null;
                }

                _writeOnlyCtx.Set<RepaymentLDF>().UpdateRange(repayments);
                await _writeOnlyCtx.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return (executionState: ExecutionState.Success, null!, "Unknown error occurred.");
            }

            return (executionState: ExecutionState.Created, null!, "Created Successfully");
        }
    }
}