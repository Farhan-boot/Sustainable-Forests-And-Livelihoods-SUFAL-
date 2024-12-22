using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.InternalLoan;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.InternalLoan;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.InternalLoan
{
    public class RepaymentInternalLoanBusiness : BaseBusiness<RepaymentInternalLoan>, IRepaymentInternalLoanBusiness
    {
        private readonly GENERICReadOnlyCtx _readOnlyCtx;
        private readonly GENERICWriteOnlyCtx _writeOnlyCtx;
        public RepaymentInternalLoanBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyCtx, GENERICWriteOnlyCtx writeOnlyCtx)
            : base(unitOfWork)
        {
            _readOnlyCtx = readOnlyCtx;
            _writeOnlyCtx = writeOnlyCtx;
        }

        public override Task<(ExecutionState executionState, IQueryable<RepaymentInternalLoan> entity, string message)> List(QueryOptions<RepaymentInternalLoan> queryOptions = null)
        {
            return base.List(new QueryOptions<RepaymentInternalLoan>
            {
                SortingExpression = e => e.OrderByDescending(x => x.RepaymentSerial)
            });
        }


        public async Task<(ExecutionState executionState, RepaymentInternalLoan entity, string message)> CompletePayment(long repaymentId, long userId)
        {
            IDbContextTransaction? transaction = null;

            try
            {
                var result = await base.GetAsync(repaymentId);
                if (result.entity == null) return (ExecutionState.Failure, null!, "Repayment is not found");
                if (result.entity.IsLocked ?? false) return (ExecutionState.Failure, null!, "Repayment is locked");
                if (result.entity.IsPaymentCompleted ?? false) return (ExecutionState.Failure, null!, "Payment is already completed");

                var previousPaymentCount = await _readOnlyCtx.Set<RepaymentInternalLoan>()
                    .CountAsync(x => x.RepaymentSerial < result.entity.RepaymentSerial && x.IsPaymentCompleted == false && x.InternalLoanInformationId == result.entity.InternalLoanInformationId);
                if (previousPaymentCount > 0) return (ExecutionState.Failure, null!, "Previous payment is not completed");

                var currentDate = DateTime.Now;

                result.entity.IsDeleted = false;
                result.entity.IsActive = true;
                result.entity.UpdatedAt = currentDate;
                result.entity.ModifiedBy = userId;
                result.entity.IsLocked = true;

                result.entity.IsPaymentCompleted = true;
                result.entity.PaymentCompletedDateTime = currentDate;

                if (currentDate > result.entity.RepaymentEndDate)
                {
                    result.entity.IsPaymentCompletedLate = true;
                }

                transaction = _writeOnlyCtx.Database.BeginTransaction();
                _writeOnlyCtx.Set<RepaymentInternalLoan>().Update(result.entity);

                await _writeOnlyCtx.SaveChangesAsync();
                await transaction.CommitAsync();


                return (ExecutionState.Success, result.entity, "Successfully completed payment");
            }
            catch (Exception)
            {
                transaction?.Rollback();
                return (ExecutionState.Failure, null!, "Unexpected error occurred");
            }
            finally
            {
                transaction?.Dispose();
            }
        }



    }
}