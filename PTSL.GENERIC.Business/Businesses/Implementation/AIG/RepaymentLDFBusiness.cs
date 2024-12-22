using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.AIG;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.AIG
{
    public class RepaymentLDFBusiness : BaseBusiness<RepaymentLDF>, IRepaymentLDFBusiness
    {
        private readonly GENERICUnitOfWork _unitOfWork;
        private readonly GENERICReadOnlyCtx _readOnlyCtx;
        private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

        public RepaymentLDFBusiness(
            GENERICUnitOfWork unitOfWork,
            GENERICReadOnlyCtx readOnlyCtx,
            GENERICWriteOnlyCtx writeOnlyCtx)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _readOnlyCtx = readOnlyCtx;
            _writeOnlyCtx = writeOnlyCtx;
        }

        public override Task<(ExecutionState executionState, IQueryable<RepaymentLDF> entity, string message)> List(QueryOptions<RepaymentLDF> queryOptions = null)
        {
            return base.List(new QueryOptions<RepaymentLDF>
            {
                SortingExpression = e => e.OrderBy(x => x.RepaymentSerial),
            });
        }

        public Task<(ExecutionState executionState, IQueryable<RepaymentLDF> entity, string message)> GetListWithProgress(long aigId)
        {
            return base.List(new QueryOptions<RepaymentLDF>
            {
                SortingExpression = e => e.OrderBy(x => x.RepaymentSerial),
                IncludeExpression = e => e.Include(x => x.LDFProgress!),
                FilterExpression = e => e.AIGBasicInformationId == aigId
            });
        }

        public Task<(ExecutionState executionState, IQueryable<RepaymentLDF> entity, string message)> GetListByFirstLDFId(long ldfId)
        {
            return base.List(new QueryOptions<RepaymentLDF>
            {
                SortingExpression = e => e.OrderBy(x => x.RepaymentSerial),
                FilterExpression = e => e.FirstSixtyPercentageLDFId == ldfId
            });
        }

        public Task<(ExecutionState executionState, IQueryable<RepaymentLDF> entity, string message)> GetListBySecondLDFId(long ldfId)
        {
            return base.List(new QueryOptions<RepaymentLDF>
            {
                SortingExpression = e => e.OrderBy(x => x.RepaymentSerial),
                FilterExpression = e => e.SecondFourtyPercentageLDFId == ldfId
            });
        }

        public Task<(ExecutionState executionState, IQueryable<RepaymentLDF> entity, string message)> GetListByAIGId(long aigId)
        {
            return base.List(new QueryOptions<RepaymentLDF>
            {
                SortingExpression = e => e.OrderBy(x => x.RepaymentSerial),
                IncludeExpression = e => e.Include(x => x.FirstSixtyPercentageLDF).Include(x => x.SecondFourtyPercentageLDF!),
                FilterExpression = e => e.AIGBasicInformationId == aigId
            });
        }

        public async Task<(ExecutionState executionState, IList<RepaymentLDFHistory> entity, string message)> ListHistory(long repaymentId)
        {
            var result = await _readOnlyCtx.Set<RepaymentLDFHistory>()
                .Where(x => x.RepaymentLDFId  == repaymentId)
                .Include(x => x.EventUser)
                .OrderBy(x => x.EventOccurredDate)
                .ToListAsync();

            return (ExecutionState.Retrieved, result, "Data returned successfully");
        }

        public async Task<(ExecutionState executionState, RepaymentLDF entity, string message)> CompletePayment(CompleteRepaymentVM completeRepayment, long userId)
        {
            using var transaction = _writeOnlyCtx.Database.BeginTransaction();

            try
            {
                var result = await _writeOnlyCtx.Set<RepaymentLDF>().FirstOrDefaultAsync(x => x.Id == completeRepayment.RepaymentId);
                if (result is null) return (ExecutionState.Failure, null!, "Repayment is not found");

                var isValid = result.IsRepaymentValidForCompletePayment();
                if (isValid.isOk == false) return (ExecutionState.Failure, null!, isValid.errorMessage);

                var isCompleteRepaymentValid = completeRepayment.IsValid(result);
                if (isCompleteRepaymentValid.isOk == false) return (ExecutionState.Failure, null!, isCompleteRepaymentValid.errorMessage);

                var currentDate = DateTime.Now;

                var isPreviousRepaymentCompeted = await _unitOfWork.RepaymentLDFRepo.IsPreviousRepaymentCompleted(result.AIGBasicInformationId, result.RepaymentSerial);
                if (isPreviousRepaymentCompeted == false) return (ExecutionState.Failure, null!, "Previous payment is not completed");

                if (completeRepayment.IsPaymentReceivedIsLessThanExpected(result.FirstSixtyPercentRepaymentAmount, result.SecondFortyPercentRepaymentAmount))
                {
                    var sixtyPercentageRemaining = result.FirstSixtyPercentRepaymentAmount - completeRepayment.FirstSixtyPercentRepaymentAmountReceived;
                    var fortyPercentageRemaining = result.SecondFortyPercentRepaymentAmount - completeRepayment.SecondFortyPercentRepaymentAmountReceived;
                    var nextRepayments = await _unitOfWork.RepaymentLDFRepo.GetNextUncompletedRepayments(result.AIGBasicInformationId, result.RepaymentSerial);

                    if (nextRepayments is null || nextRepayments.Count == 0)
                    {
                        var lastRepaymentSerial = await _unitOfWork.RepaymentLDFRepo.GetMaxRepaymentSerial(result.AIGBasicInformationId);
                        var newRepayment = new RepaymentLDF
                        {
                            FirstSixtyPercentRepaymentAmount = sixtyPercentageRemaining,
                            SecondFortyPercentRepaymentAmount = fortyPercentageRemaining,
                            RepaymentStartDate = currentDate.AddMonths(1),
                            RepaymentEndDate = currentDate.AddMonths(2),
                            FirstSixtyPercentageLDFId = result.FirstSixtyPercentageLDFId,
                            SecondFourtyPercentageLDFId = result.SecondFourtyPercentageLDFId,
                            AIGBasicInformationId = result.AIGBasicInformationId,
                            RepaymentSerial = lastRepaymentSerial + 1,
                            UpdatedAt = currentDate,
                        };

                        _writeOnlyCtx.Set<RepaymentLDF>().Add(newRepayment);
                    }
                    else
                    {
                        var calculateDivideFirstSixtyPercentage = sixtyPercentageRemaining / nextRepayments.Count;
                        var calculateDivideFortyPercentage = fortyPercentageRemaining / nextRepayments.Count;

                        foreach (var next in nextRepayments)
                        {
                            next.FirstSixtyPercentRepaymentAmount += calculateDivideFirstSixtyPercentage;

                            if (fortyPercentageRemaining > 0)
                            {
                                next.SecondFortyPercentRepaymentAmount += calculateDivideFortyPercentage;
                            }
                        }

                        _writeOnlyCtx.Set<RepaymentLDF>().UpdateRange(nextRepayments);
                    }
                }

                result.IsDeleted = false;
                result.IsActive = true;
                result.UpdatedAt = currentDate;
                result.ModifiedBy = userId;
                result.IsLocked = true;

                result.IsPaymentCompleted = true;
                result.PaymentCompletedDateTime = currentDate;
                result.FirstSixtyPercentRepaymentAmountReceived = completeRepayment.FirstSixtyPercentRepaymentAmountReceived;
                result.SecondFortyPercentRepaymentAmountReceived = completeRepayment.SecondFortyPercentRepaymentAmountReceived;

                if (currentDate > result.RepaymentEndDate)
                {
                    result.IsPaymentCompletedLate = true;
                }

                _writeOnlyCtx.Set<RepaymentLDF>().Update(result);
                _writeOnlyCtx.Set<RepaymentLDFHistory>().Add(new RepaymentLDFHistory
                {
                    IsActive = true,
                    CreatedAt = currentDate,
                    CreatedBy = userId,
                    EventUserId = userId,
                    RepaymentLDFId = completeRepayment.RepaymentId,
                    EventOccurredDate = currentDate,
                    RepaymentLDFEventType = RepaymentLDFEventType.Received
                });
                await _writeOnlyCtx.SaveChangesAsync();
                await transaction.CommitAsync();

                await AIGBasicInformationBusiness.SetBadLoan(_readOnlyCtx, _writeOnlyCtx, result.AIGBasicInformationId);

                return (ExecutionState.Success, result, "Successfully completed payment");
            }
            catch (Exception)
            {
                transaction?.Rollback();
                return (ExecutionState.Failure, null!, "Unexpected error occurred");
            }
        }

        public async Task<(ExecutionState executionState, RepaymentLDF entity, string message)> RemovePayment(long repaymentId, long userId)
        {
            using var transaction = _writeOnlyCtx.Database.BeginTransaction();

            try
            {
                var result = await base.GetAsync(repaymentId);
                if (result.entity == null) return (ExecutionState.Failure, null!, "Repayment is not found");
                if (result.entity.IsLocked) return (ExecutionState.Failure, null!, "Repayment is locked");

                var newLoanResult = await CheckIfNewLoanIsAlreadyTaken(repaymentId);
                if (newLoanResult.executionState == ExecutionState.Failure)
                {
                    return (newLoanResult.executionState, null!, newLoanResult.message);
                }

                var currentDate = DateTime.Now;

                result.entity.IsDeleted = false;
                result.entity.IsActive = true;
                result.entity.UpdatedAt = currentDate;
                result.entity.ModifiedBy = userId;

                result.entity.IsPaymentCompleted = false;
                result.entity.PaymentCompletedDateTime = default;
                result.entity.IsPaymentCompletedLate = false;

                _writeOnlyCtx.Set<RepaymentLDF>().Update(result.entity);
                _writeOnlyCtx.Set<RepaymentLDFHistory>().Add(new RepaymentLDFHistory
                {
                    IsActive = true,
                    CreatedAt = currentDate,
                    CreatedBy = userId,
                    EventUserId = userId,
                    RepaymentLDFId = repaymentId,
                    EventOccurredDate = currentDate,
                    RepaymentLDFEventType = RepaymentLDFEventType.Removed
                });
                await _writeOnlyCtx.SaveChangesAsync();
                await transaction.CommitAsync();

                await AIGBasicInformationBusiness.SetBadLoan(_readOnlyCtx, _writeOnlyCtx, result.entity.AIGBasicInformationId);

                return (ExecutionState.Success, result.entity, "Successfully removed payment");
            }
            catch (Exception)
            {
                transaction?.Rollback();
                return (ExecutionState.Failure, null!, "Unexpected error occurred");
            }
        }

        private async Task<(ExecutionState executionState, string message)> CheckIfNewLoanIsAlreadyTaken(long repaymentId)
        {
            var aigLdfCountAndSurveyId = await _readOnlyCtx.Set<RepaymentLDF>()
                .Where(x => x.Id == repaymentId)
                .Select(x => new { x.AIGBasicInformation!.LDFCount, x.AIGBasicInformation.SurveyId })
                .FirstOrDefaultAsync();
            var newLoanCount = await _readOnlyCtx.Set<AIGBasicInformation>()
                .Where(x => x.SurveyId == aigLdfCountAndSurveyId!.SurveyId && x.LDFCount > aigLdfCountAndSurveyId.LDFCount)
                .CountAsync();

            return newLoanCount switch
            {
                > 0 => (ExecutionState.Failure, "Can not remove, New loan has been created"),
                _ => (ExecutionState.Success, string.Empty)
            };
        }

        public async Task<(ExecutionState executionState, RepaymentLDF entity, string message)> LockUnlockPayment(long repaymentId, long userId, bool shouldLock)
        {
            IDbContextTransaction? transaction = null;

            try
            {
                var result = await base.GetAsync(repaymentId);
                if (result.entity == null) return (ExecutionState.Failure, null!, "Repayment is not found");

                var newLoanResult = await CheckIfNewLoanIsAlreadyTaken(repaymentId);
                if (newLoanResult.executionState == ExecutionState.Failure)
                {
                    return (newLoanResult.executionState, null!, "Can not lock or unlock, New loan has been created");
                }

                var currentDate = DateTime.Now;

                result.entity.IsDeleted = false;
                result.entity.IsActive = true;
                result.entity.UpdatedAt = currentDate;
                result.entity.ModifiedBy = userId;
                result.entity.IsLocked = shouldLock;

                transaction = _writeOnlyCtx.Database.BeginTransaction();
                _writeOnlyCtx.Set<RepaymentLDF>().Update(result.entity);
                _writeOnlyCtx.Set<RepaymentLDFHistory>().Add(new RepaymentLDFHistory
                {
                    IsActive = true,
                    CreatedAt = currentDate,
                    CreatedBy = userId,
                    EventUserId = userId,
                    RepaymentLDFId = repaymentId,
                    EventOccurredDate = currentDate,
                    RepaymentLDFEventType = shouldLock ? RepaymentLDFEventType.Locked : RepaymentLDFEventType.Unlocked
                });
                await _writeOnlyCtx.SaveChangesAsync();
                await transaction.CommitAsync();

                return (ExecutionState.Success, result.entity, "Successfully completed locking");
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

        #region Reports
        public async Task<(ExecutionState executionState, List<RepaymentLDFOutstandingLoanPerBorrowerVM> entity, string message)> OutstandingLoanPerBorrowerFilter(RepaymentLDFOutstandingLoanPerBorrowerFilterVM filter)
        {
            var startDate = new DateTime(filter.Year ?? 0001, 1, 1);
            var endDate = new DateTime(filter.Year ?? 0001, 12, 31);

            var result = await _readOnlyCtx.Set<AIGBasicInformation>()
                .FilterByLocation(filter)
                .SelectMany(e => e.RepaymentLDFs!.Where(
                        x => (!filter.HasMonth || x.RepaymentEndDate.Month == (int)filter.Month!)
                        && (!filter.HasYear || x.RepaymentEndDate >= startDate && x.RepaymentEndDate <= endDate!)
                    ),
                (aig, repayment) => new RepaymentLDFOutstandingLoanPerBorrowerResult
                {
                    ForestFcvVcfId = aig.ForestFcvVcfId,
                    ForestFcvVcfName = aig.ForestFcvVcf!.Name,
                    ForestFcvVcfNameBn = aig.ForestFcvVcf.NameBn,
                    FirstSixtyPercentRepaymentAmount = repayment.FirstSixtyPercentRepaymentAmount,
                    SecondFortyPercentRepaymentAmount = repayment.SecondFortyPercentRepaymentAmount,
                    RepaymentEndDate = repayment.RepaymentEndDate,
                    IsPaymentCompleted = repayment.IsPaymentCompleted,
                })
                .ToListAsync();


            var groupedResults = result
                .GroupBy(r => new
                {
                    r.ForestFcvVcfId,
                    r.ForestFcvVcfName,
                    r.ForestFcvVcfNameBn
                })
                .Select(g => new RepaymentLDFOutstandingLoanPerBorrowerVM
                {
                    ForestFcvVcfId = g.Key.ForestFcvVcfId,
                    ForestFcvVcfName = g.Key.ForestFcvVcfName,
                    ForestFcvVcfNameBn = g.Key.ForestFcvVcfNameBn,
                    TotalExpectedRepayment = Math.Round(g.Sum(x => x.TotalRepaymentAmount), 2),
                    TotalActualRepayment = Math.Round(g.Sum(x => x.IsPaymentCompleted ? x.TotalRepaymentAmount : 0), 2),
                    TotalBorrower = g.Count(),
                    Year = filter.Year,
                    Month = filter.Month
                })
                .ToList();

            return (ExecutionState.Success, groupedResults!, "Returned successfully");
        }

        public async Task<(ExecutionState executionState, List<DateWiseRepaymentReportVM> entity, string message)> DateWiseRepaymentReport(DateWiseRepaymentReportFilterVM filter)
        {
            var startDate = new DateTime(filter.Year ?? 0001, 1, 1);
            var endDate = new DateTime(filter.Year ?? 0001, 12, 31);

            var result = await _readOnlyCtx.Set<AIGBasicInformation>()
                .FilterByLocation(filter)
                .SelectMany(
                    x => x.RepaymentLDFs!.Where(
                            y => (!filter.HasMonth || y.RepaymentEndDate.Month == (int)filter.Month!)
                                && (!filter.HasYear || y.RepaymentEndDate >= startDate && y.RepaymentEndDate <= endDate!)
                                && (!filter.HasDate || y.RepaymentStartDate <= filter.Date! && filter.Date <= y.RepaymentEndDate)
                                && (!filter.HasIsCompleted || y.IsPaymentCompleted == filter.IsCompleted!)
                        ),
                (aig, repayment) => new DateWiseRepaymentReportVM
                {
                    BeneficiaryName = aig.Survey!.BeneficiaryName,
                    BeneficiaryPhone = aig.Survey!.BeneficiaryPhone,
                    BeneficiaryNid = aig.Survey!.BeneficiaryNid,

                    LDFCount = aig.LDFCount,

                    TotalAllocatedLoanAmount = aig.TotalAllocatedLoanAmount,
                    FirstSixtyPercentRepaymentAmount = repayment.FirstSixtyPercentRepaymentAmount,
                    SecondFortyPercentRepaymentAmount =  repayment.SecondFortyPercentRepaymentAmount,

                    RepaymentStartDate = repayment.RepaymentStartDate,
                    RepaymentEndDate = repayment.RepaymentEndDate,
                    IsPaymentCompleted = repayment.IsPaymentCompleted,
                })
                .ToListAsync();

            return (ExecutionState.Success, result, "Data returned successfully");
        }
        #endregion
    }
}