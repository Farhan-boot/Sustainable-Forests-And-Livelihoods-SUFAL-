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
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.AIG;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG.Reports;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.AIG
{
    public class AIGBasicInformationBusiness : BaseBusiness<AIGBasicInformation>, IAIGBasicInformationBusiness
    {
        private readonly GENERICReadOnlyCtx _readOnlyCtx;
        private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

        public AIGBasicInformationBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyCtx, GENERICWriteOnlyCtx writeOnlyCtx)
            : base(unitOfWork)
        {
            _readOnlyCtx = readOnlyCtx;
            _writeOnlyCtx = writeOnlyCtx;
        }

        public override Task<(ExecutionState executionState, IQueryable<AIGBasicInformation> entity, string message)> List(QueryOptions<AIGBasicInformation> queryOptions = null)
        {
            return base.List(new QueryOptions<AIGBasicInformation>
            {
                IncludeExpression = e => e
                    .Include(x => x.RepaymentLDFs!)
                    .Include(x => x.Ngo!)
                    .Include(x => x.Survey!)
                    .Include(x => x.FirstSixtyPercentageLDF!)
                    .Include(x => x.SecondFourtyPercentageLDF!),
                SortingExpression = e => e.OrderByDescending(x => x.Id)
            });
        }

        public async Task<(ExecutionState executionState, AIGLoanOverviewVM entity, string message)> LoanOverview(ForestCivilLocationFilter filter)
        {
            try
            {
                IQueryable<AIGBasicInformation> query = _readOnlyCtx.Set<AIGBasicInformation>()
                    .OrderByDescending(x => x.Id);

                query = query.FilterByLocation(filter);

                var totalLoan = await query
                    .GroupBy(x => x.SurveyId)
                    .Select(x => new
                    {
                        ColumnName = x.Key,
                        Count = x.Count()
                    })
                    .CountAsync();

                var totalRegularWealth = await query
                    .Where(x => x.BadLoanType == BadLoanType.Regular)
                    .GroupBy(x => x.SurveyId)
                    .Select(x => new
                    {
                        ColumnName = x.Key,
                        Count = x.Count()
                    })
                    .CountAsync();
                var totalRegularWealthPercentage = Math.Round(((double)totalRegularWealth / totalLoan) * 100);

                var totalUnderObservation = await query
                    .Where(x => x.BadLoanType == BadLoanType.UnderObservation)
                    .GroupBy(x => x.SurveyId)
                    .Select(x => new
                    {
                        ColumnName = x.Key,
                        Count = x.Count()
                    })
                    .CountAsync();
                var totalUnderObservationPercentage = Math.Round(((double)totalUnderObservation / totalLoan) * 100);

                var totalInferiorWealth = await query
                    .Where(x => x.BadLoanType == BadLoanType.InferiorLoan)
                    .GroupBy(x => x.SurveyId)
                    .Select(x => new
                    {
                        ColumnName = x.Key,
                        Count = x.Count()
                    })
                    .CountAsync();
                var totalInferiorWealthPercentage = Math.Round(((double)totalInferiorWealth / totalLoan) * 100);

                var totalSuspiciousWealth = await query
                    .Where(x => x.BadLoanType == BadLoanType.SuspiciousLoan)
                    .GroupBy(x => x.SurveyId)
                    .Select(x => new
                    {
                        ColumnName = x.Key,
                        Count = x.Count()
                    })
                    .CountAsync();
                var totalSuspiciousWealthPercentage = Math.Round(((double)totalSuspiciousWealth / totalLoan) * 100);

                var totalEvilWealth = await query
                    .Where(x => x.BadLoanType == BadLoanType.EvilLoan)
                    .GroupBy(x => x.SurveyId)
                    .Select(x => new
                    {
                        ColumnName = x.Key,
                        Count = x.Count()
                    })
                    .CountAsync();
                var totalEvilWealthPercentage = Math.Round(((double)totalEvilWealth / totalLoan) * 100);

                var result = new AIGLoanOverviewVM
                {
                    TotalLoan = totalLoan,
                    RegularPercentage = double.IsNaN(totalRegularWealthPercentage) ? 0 : totalRegularWealthPercentage,
                    UnderObservationPercentage = double.IsNaN(totalUnderObservationPercentage) ? 0 : totalUnderObservationPercentage,
                    InferiorWealthPercentage = double.IsNaN(totalInferiorWealthPercentage) ? 0 : totalInferiorWealthPercentage,
                    SuspiciousWealthPercentage = double.IsNaN(totalSuspiciousWealthPercentage) ? 0 : totalSuspiciousWealthPercentage,
                    EvilWealthPercentage = double.IsNaN(totalEvilWealthPercentage) ? 0 : totalEvilWealthPercentage,
                };

                return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Failure, new AIGLoanOverviewVM(), "Unexpected error occurred.");
            }
        }

        public async Task<(ExecutionState executionState, PaginationResutl<AIGBasicInformation> entity, string message)> GetAIGByFilter(AIGBasicInformationFilterVM filter)
        {
            try
            {
                //IQueryable<AIGBasicInformation> query = _readOnlyCtx.Set<AIGBasicInformation>()
                //    .OrderByDescending(x => x.Id);



                if (filter.sSearch != null)
                {
                    IQueryable<AIGBasicInformation> queryTotalSearch = _readOnlyCtx.Set<AIGBasicInformation>()
                   .OrderByDescending(x => x.Id);
                    IQueryable<AIGBasicInformation> querySearch = _readOnlyCtx.Set<AIGBasicInformation>()
                                     .Include(x => x.Ngo!)
                                     .Include(x => x.Survey!)
                                     .Include(x => x.FirstSixtyPercentageLDF!)
                                     .Include(x => x.SecondFourtyPercentageLDF!)
                                     .OrderByDescending(x => x.Id);

                    querySearch = querySearch.Where(x => x.Survey.BeneficiaryName.Contains(filter.sSearch) || x.Survey.BeneficiaryPhone.Contains(filter.sSearch) || x.Survey.BeneficiaryNid.Contains(filter.sSearch));
                    var resultSearch = await querySearch.ToListAsync();
                    return (ExecutionState.Retrieved, new PaginationResutl<AIGBasicInformation>
                    {
                        aaData = resultSearch,
                        iTotalDisplayRecords = await queryTotalSearch.CountAsync(),
                        iTotalRecords = await queryTotalSearch.CountAsync(),
                    }, "Data returned successfully.");
                }



                IQueryable<AIGBasicInformation> query;
                if (filter.iDisplayStart != null || filter.iDisplayLength != null)
                {
                    query = _readOnlyCtx.Set<AIGBasicInformation>()
                                      .Include(x => x.Ngo!)
                                      .Include(x => x.Survey!)
                                      .Include(x => x.FirstSixtyPercentageLDF!)
                                      .Include(x => x.SecondFourtyPercentageLDF!)
                                      .OrderByDescending(x => x.Id)
                                      .Skip(filter.iDisplayStart ?? 0)
                                      .Take(filter.iDisplayLength ?? 0);
                }
                else
                {
                    query = _readOnlyCtx.Set<AIGBasicInformation>()
                                      .Include(x => x.Ngo!)
                                      .Include(x => x.Survey!)
                                      .Include(x => x.FirstSixtyPercentageLDF!)
                                      .Include(x => x.SecondFourtyPercentageLDF!)
                                      .OrderByDescending(x => x.Id);
                }
                IQueryable<AIGBasicInformation> queryTotal = _readOnlyCtx.Set<AIGBasicInformation>()
                .OrderByDescending(x => x.Id);




                // Forest Administration
                query = query.WhereIf(filter.HasForestCircleId, x => x.ForestCircleId == filter.ForestCircleId);
                query = query.WhereIf(filter.HasForestDivisionId, x => x.ForestDivisionId == filter.ForestDivisionId);
                query = query.WhereIf(filter.HasForestRangeId, x => x.ForestRangeId == filter.ForestRangeId);
                query = query.WhereIf(filter.HasForestBeatId, x => x.ForestBeatId == filter.ForestBeatId);
                query = query.WhereIf(filter.HasForestFcvVcfId, x => x.ForestFcvVcfId == filter.ForestFcvVcfId);

                // Civil Administration
                query = query.WhereIf(filter.HasDivisionId, x => x.DivisionId == filter.DivisionId);
                query = query.WhereIf(filter.HasDistrictId, x => x.DistrictId == filter.DistrictId);
                query = query.WhereIf(filter.HasUpazillaId, x => x.UpazillaId == filter.UpazillaId);
                query = query.WhereIf(filter.HasUnionId, x => x.UnionId == filter.UnionId);

                // Common
                query = query.WhereIf(filter.HasGender, x => x.Survey!.BeneficiaryGender == filter.Gender);
                query = query.WhereIf(filter.HasPhoneNumber, x => x.Survey!.BeneficiaryPhone == filter.PhoneNumber);
                query = query.WhereIf(filter.HasNID, x => x.Survey!.BeneficiaryNid == filter.NID);
                query = query.WhereIf(filter.HasNgoId, x => x.NgoId == filter.NgoId);

                query = query
                    .Include(x => x.Ngo!)
                    .Include(x => x.Survey!)
                    .Include(x => x.FirstSixtyPercentageLDF!)
                    .Include(x => x.SecondFourtyPercentageLDF!);

                if (filter.HasTake)
                {
                    query = query.Take(filter.Take ?? Defaults.Take);
                }

                var result = await query.ToListAsync();


                return (ExecutionState.Retrieved, new PaginationResutl<AIGBasicInformation>
                {
                    aaData = result,
                    iTotalDisplayRecords = await queryTotal.CountAsync(),
                    iTotalRecords = await queryTotal.CountAsync(),
                }, "Data returned successfully.");




               // return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Failure, new PaginationResutl<AIGBasicInformation>()!, "Unexpected error occurred.");
            }
        }

        public override Task<(ExecutionState executionState, AIGBasicInformation entity, string message)> GetAsync(long key)
        {
            return base.GetAsync(new FilterOptions<AIGBasicInformation>
            {
                FilterExpression = e => e.Id == key,
                IncludeExpression = e => e.Include(x => x.Survey!),
            });
        }

        public async Task<(ExecutionState executionState, AIGBeneficiaryCheckEligibilityVM entity, string message)> AIGBeneficiaryCheckEligibility(long surveyId)
        {
            var result = await _readOnlyCtx.Set<AIGBasicInformation>()
                .Where(x => x.SurveyId == surveyId)
                .Select(x => new AIGBeneficiaryCheckEligibilityPreviousLoan
                {
                    AIGBasicInformationId = x.Id,
                    LoanStartDate = x.StartDate,
                    LoanEndDate = x.EndDate,
                    FirstSixtyPercentageLDF = x.FirstSixtyPercentageLDF,
                    SecondFourtyPercentageLDF = x.SecondFourtyPercentageLDF,

                    TotalAllocatedLoanAmount = x.TotalAllocatedLoanAmount,
                    TotalLoanRepaymentAmount = Math.Round(x.RepaymentLDFs!.Where(y => y.IsPaymentCompleted).Sum(y => y.FirstSixtyPercentRepaymentAmount + y.SecondFortyPercentRepaymentAmount), 2),
                    TotalLoanRepaymentsNumber = x.RepaymentLDFs!.Count(),
                    TotalLoanRepaymentsNotCompletedNumber = x.RepaymentLDFs!.Where(y => y.IsPaymentCompleted == false).Count(),

                    LDFRound = x.LDFCount,
                    BadLoanType = x.BadLoanType
                })
                .ToListAsync();

            return (
                ExecutionState.Failure, new AIGBeneficiaryCheckEligibilityVM
                {
                    AIGBeneficiaryCheckEligibilityPreviousLoans = result,
                },
                "Ok"
            );
        }

        public async Task<(ExecutionState executionState, AIGBasicInformation entity, string message)> GetIncludeFirstSecondAndBen(long key)
        {
            var aig = await _readOnlyCtx.Set<AIGBasicInformation>()
                .Where(x => x.Id == key)
                .Include(x => x.ForestCircle!)
                .Include(x => x.ForestDivision!)
                .Include(x => x.ForestRange!)
                .Include(x => x.ForestBeat!)
                .Include(x => x.ForestFcvVcf!)
                .Include(x => x.Division!)
                .Include(x => x.District!)
                .Include(x => x.Upazilla!)
                .Include(x => x.Union!)
                .Include(x => x.Ngo!)
                .Include(x => x.Survey)
                .Include(x => x.FirstSixtyPercentageLDF)
                .Include(x => x.SecondFourtyPercentageLDF!)
                .FirstOrDefaultAsync();

            var repayments = await _readOnlyCtx.Set<RepaymentLDF>()
                .Where(x => x.AIGBasicInformationId == key)
                .Include(x => x.RepaymentLDFHistories!)
                .ThenInclude(x => x.EventUser)
                .ToListAsync();
            var ldfProgress = await _readOnlyCtx.Set<LDFProgress>()
                .Where(x => x.AIGBasicInformationId == key)
                .ToListAsync();

            aig.RepaymentLDFs = repayments;
            aig.LDFProgresses = ldfProgress;

            return (executionState: ExecutionState.Retrieved, aig, "Successfully loaded data.");
        }

        #region Report
        public async Task<(ExecutionState executionState, IList<AIGBasicInformation> entity, string message)> RepaymentReport(RepaymentReportFilterVM filter)
        {
            try
            {
                IQueryable<AIGBasicInformation> query = _readOnlyCtx.Set<AIGBasicInformation>()
                    .OrderByDescending(x => x.Id);

                query = query.FilterByLocation(filter);

                // Common
                query = query.WhereIf(filter.HasGender, x => x.Survey!.BeneficiaryGender == filter.Gender);
                query = query.WhereIf(filter.HasPhoneNumber, x => x.Survey!.BeneficiaryPhone == filter.PhoneNumber);
                query = query.WhereIf(filter.HasNID, x => x.Survey!.BeneficiaryNid == filter.NID);
                query = query.WhereIf(filter.HasNgoId, x => x.NgoId == filter.NgoId);

                query = query
                    .Include(x => x.Ngo!)
                    .Include(x => x.Survey!)
                    .Include(x => x.FirstSixtyPercentageLDF!)
                    .Include(x => x.SecondFourtyPercentageLDF!)
                    .Include(x => x.RepaymentLDFs);

                var result = await query.ToListAsync();

                return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception)
            {
                return (ExecutionState.Failure, new List<AIGBasicInformation>()!, "Unexpected error occurred.");
            }
        }

        public async Task<(ExecutionState executionState, IList<AIGBasicInformation> entity, string message)> BeneficiaryWiseRepaymentProgress(long surveyId)
        {
            try
            {
                var aigs = await _readOnlyCtx.Set<AIGBasicInformation>()
                    .Where(x => x.SurveyId == surveyId)
                    .Include(x => x.Ngo!)
                    .Include(x => x.Survey!)
                    .Include(x => x.FirstSixtyPercentageLDF!)
                    .Include(x => x.SecondFourtyPercentageLDF!)
                    .ToListAsync();

                if (aigs is not null && aigs.Count > 0)
                {
                    var aigIds = aigs.Select(x => x.Id);

                    var repaymentLDFs = await _readOnlyCtx.Set<RepaymentLDF>().Where(x => aigIds.Contains(x.AIGBasicInformationId)).ToListAsync();
                    var lDFProgresses = await _readOnlyCtx.Set<LDFProgress>().Where(x => aigIds.Contains(x.AIGBasicInformationId)).ToListAsync();

                    foreach (var item in aigs)
                    {
                        item.RepaymentLDFs = repaymentLDFs.Where(x => x.AIGBasicInformationId == item.Id).ToList();
                        item.LDFProgresses = lDFProgresses.Where(x => x.AIGBasicInformationId == item.Id).ToList();
                    }
                }

                return (ExecutionState.Retrieved, aigs ?? new List<AIGBasicInformation>(), "Data returned successfully.");
            }
            catch (Exception)
            {
                return (ExecutionState.Failure, new List<AIGBasicInformation>(), "Unexpected error occurred.");
            }
        }

        public async Task<(ExecutionState executionState, List<AverageLoanSizeVM> entity, string message)> AverageLoanSizeFilter(AverageLoanSizeFilterVM filter)
        {
            var startDate = new DateTime(filter.Year ?? 0001, 1, 1);
            var endDate = new DateTime(filter.Year ?? 0001, 12, 31);

            var firstLoans = await _readOnlyCtx.Set<FirstSixtyPercentageLDF>()
                .WhereIf(filter.HasYear, x => x.DisbursementDate >= startDate && x.DisbursementDate <= endDate)
                .WhereIf(filter.HasMonth, x => x.DisbursementDate.Month == (int)filter.Month!)
                .WhereIf(filter.HasForestCircleId, x => x.AIGBasicInformation!.ForestCircleId == filter.ForestCircleId)
                .WhereIf(filter.HasForestDivisionId, x => x.AIGBasicInformation!.ForestDivisionId == filter.ForestDivisionId)
                .WhereIf(filter.HasForestRangeId, x => x.AIGBasicInformation!.ForestRangeId == filter.ForestRangeId)
                .WhereIf(filter.HasForestBeatId, x => x.AIGBasicInformation!.ForestBeatId == filter.ForestBeatId)
                .WhereIf(filter.HasForestFcvVcfId, x => x.AIGBasicInformation!.ForestFcvVcfId == filter.ForestFcvVcfId)

                .WhereIf(filter.HasDivisionId, x => x.AIGBasicInformation!.DivisionId == filter.DivisionId)
                .WhereIf(filter.HasDistrictId, x => x.AIGBasicInformation!.DistrictId == filter.DistrictId)
                .WhereIf(filter.HasUpazillaId, x => x.AIGBasicInformation!.UpazillaId == filter.UpazillaId)
                .WhereIf(filter.HasUnionId, x => x.AIGBasicInformation!.UnionId == filter.UnionId)
                .Select(x => new AverageLoanSizeResult
                {
                    AIGBasicInformationId = x.AIGBasicInformationId,
                    ForestFcvVcfId = x.AIGBasicInformation!.ForestFcvVcfId,
                    ForestFcvVcfName = x.AIGBasicInformation.ForestFcvVcf!.Name,
                    ForestFcvVcfNameBn = x.AIGBasicInformation.ForestFcvVcf.NameBn,
                    FirstSixtyPercentRepaymentAmount = x.LDFAmount,
                })
                .ToListAsync();

            var secondLoans = await _readOnlyCtx.Set<SecondFourtyPercentageLDF>()
                .WhereIf(filter.HasYear, x => x.DisbursementDate >= startDate && x.DisbursementDate <= endDate)
                .WhereIf(filter.HasMonth, x => x.DisbursementDate.Month == (int)filter.Month!)
                .WhereIf(filter.HasForestCircleId, x => x.AIGBasicInformation!.ForestCircleId == filter.ForestCircleId)
                .WhereIf(filter.HasForestDivisionId, x => x.AIGBasicInformation!.ForestDivisionId == filter.ForestDivisionId)
                .WhereIf(filter.HasForestRangeId, x => x.AIGBasicInformation!.ForestRangeId == filter.ForestRangeId)
                .WhereIf(filter.HasForestBeatId, x => x.AIGBasicInformation!.ForestBeatId == filter.ForestBeatId)
                .WhereIf(filter.HasForestFcvVcfId, x => x.AIGBasicInformation!.ForestFcvVcfId == filter.ForestFcvVcfId)

                .WhereIf(filter.HasDivisionId, x => x.AIGBasicInformation!.DivisionId == filter.DivisionId)
                .WhereIf(filter.HasDistrictId, x => x.AIGBasicInformation!.DistrictId == filter.DistrictId)
                .WhereIf(filter.HasUpazillaId, x => x.AIGBasicInformation!.UpazillaId == filter.UpazillaId)
                .WhereIf(filter.HasUnionId, x => x.AIGBasicInformation!.UnionId == filter.UnionId)
                .Select(x => new AverageLoanSizeResult
                {
                    AIGBasicInformationId = x.AIGBasicInformationId,
                    ForestFcvVcfId = x.AIGBasicInformation!.ForestFcvVcfId,
                    ForestFcvVcfName = x.AIGBasicInformation.ForestFcvVcf!.Name,
                    ForestFcvVcfNameBn = x.AIGBasicInformation.ForestFcvVcf.NameBn,
                    SecondFortyPercentRepaymentAmount = x.LDFAmount,
                })
                .ToListAsync();


            var combinedResult = firstLoans.Concat(secondLoans)
                .GroupBy(r => r.AIGBasicInformationId)
                .Select(g => new AverageLoanSizeResult
                {
                    AIGBasicInformationId = g.Key,
                    ForestFcvVcfId = g.First().ForestFcvVcfId,
                    ForestFcvVcfName = g.First().ForestFcvVcfName,
                    ForestFcvVcfNameBn = g.First().ForestFcvVcfNameBn,
                    FirstSixtyPercentRepaymentAmount = g.Sum(x => x.FirstSixtyPercentRepaymentAmount),
                    SecondFortyPercentRepaymentAmount = g.Sum(x => x.SecondFortyPercentRepaymentAmount)
                })
                .ToList();

            var groupedResults = combinedResult
                .GroupBy(r => new
                {
                    r.ForestFcvVcfId,
                    r.ForestFcvVcfName,
                    r.ForestFcvVcfNameBn
                })
                .Select(g => new AverageLoanSizeVM
                {
                    ForestFcvVcfId = g.Key.ForestFcvVcfId,
                    ForestFcvVcfName = g.Key.ForestFcvVcfName,
                    ForestFcvVcfNameBn = g.Key.ForestFcvVcfNameBn,
                    TotalLoanDisbursementAmount = Math.Round(g.Sum(x => x.FirstSixtyPercentRepaymentAmount + x.SecondFortyPercentRepaymentAmount), 2),
                    TotalLoanDisbursement = g.Count(),
                    Year = filter.Year,
                    Month = filter.Month
                })
                .ToList();

            return (ExecutionState.Success, groupedResults!, "Returned successfully");
        }

        public async Task<(ExecutionState executionState, List<AIGLoanStatusReportVM> entity, string message)> AIGLoanStatusReport(AIGLoanStatusReportFilterVM filter)
        {
            var result = await _readOnlyCtx.Set<AIGBasicInformation>()
                .FilterByLocation(filter)
                .Select(x => new AIGLoanStatusReportVM
                {
                    BeneficiaryName = x.Survey!.BeneficiaryName,
                    BeneficiaryNid = x.Survey.BeneficiaryNid,
                    BeneficiaryPhoneNumber = x.Survey.BeneficiaryPhone,

                    BeneficiaryForestCircle = x.Survey.ForestCircle!.Name,
                    BeneficiaryForestDivision = x.Survey.ForestDivision!.Name,
                    BeneficiaryForestRange = x.Survey.ForestRange!.Name,
                    BeneficiaryForestBeat = x.Survey.ForestBeat!.Name,
                    BeneficiaryForestFcvVcf = x.Survey.ForestFcvVcf!.Name,
                    BeneficiaryForestFcvVcfIsFcv = x.Survey.ForestFcvVcf!.IsFcv,

                    FirstSixtyPercentageLDF = x.FirstSixtyPercentageLDF,
                    SecondFourtyPercentageLDF = x.SecondFourtyPercentageLDF,

                    TotalLoanRepaymentAmount = Math.Round(x.RepaymentLDFs!.Where(y => y.IsPaymentCompleted).Sum(y => y.FirstSixtyPercentRepaymentAmount + y.SecondFortyPercentRepaymentAmount), 2),
                    TotalLoanRepaymentsNumber = x.RepaymentLDFs!.Count(),
                    TotalLoanRepaymentsNotCompletedNumber = x.RepaymentLDFs!.Where(y => y.IsPaymentCompleted == false).Count(),

                    LDFCountNumber = x.LDFCount,
                    BadLoanType = x.BadLoanType
                })
                .ToListAsync();

            return (ExecutionState.Success, result!, "Returned successfully");
        }

        public async Task<(ExecutionState executionState, List<CumulativeRecoveryRateVM> entity, string message)> CumulativeRecoveryRateReport(CumulativeRecoveryRateFilterVM filter)
        {
            IQueryable<AIGBasicInformation> query = _readOnlyCtx.Set<AIGBasicInformation>()
                .FilterByLocation(filter);

            var dateRangeRepayments = await query.SelectMany(
                    x => x.RepaymentLDFs!.Where(
                            y => (y.RepaymentStartDate >= filter.FromDate)
                                    && (y.RepaymentEndDate <= filter.ToDate)
                        ),
                (aig, repayment) => new CumulativeRecoveryRateHelper
                {
                    AIGBasicInformationId = aig.Id,
                    SurveyId = aig.SurveyId,

                    ForestCircleId = aig.ForestCircleId,
                    ForestDivisionId = aig.ForestDivisionId,
                    ForestRangeId = aig.ForestRangeId,
                    ForestBeatId = aig.ForestBeatId,
                    ForestFcvVcfId = aig.ForestFcvVcfId,

                    ForestCircle = aig.ForestCircle!.Name,
                    ForestDivision = aig.ForestDivision!.Name,
                    ForestRange = aig.ForestRange!.Name,
                    ForestBeat = aig.ForestBeat!.Name,
                    ForestFcvVcf = aig.ForestFcvVcf!.Name,
                    ForestFcvVcfIsFcv = aig.ForestFcvVcf.IsFcv,

                    FirstSixtyPercentRepaymentAmount = repayment.FirstSixtyPercentRepaymentAmount,
                    SecondFortyPercentRepaymentAmount = repayment.SecondFortyPercentRepaymentAmount,

                    RepaymentStartDate = repayment.RepaymentStartDate,
                    RepaymentEndDate = repayment.RepaymentEndDate,
                    PaymentCompletedDateTime = repayment.PaymentCompletedDateTime,
                    IsPaymentCompleted = repayment.IsPaymentCompleted,
                })
                .ToListAsync();

            var advanceRecoveredRepayments = await query.SelectMany(
                    x => x.RepaymentLDFs!.Where(
                            y => (y.PaymentCompletedDateTime <= filter.ToDate)
                                && (filter.FromDate <= y.PaymentCompletedDateTime)
                                && (filter.ToDate < y.RepaymentStartDate)
                                && y.IsPaymentCompleted
                        ),
                (aig, repayment) => new CumulativeRecoveryRateHelper
                {
                    AIGBasicInformationId = aig.Id,
                    SurveyId = aig.SurveyId,

                    ForestCircleId = aig.ForestCircleId,
                    ForestDivisionId = aig.ForestDivisionId,
                    ForestRangeId = aig.ForestRangeId,
                    ForestBeatId = aig.ForestBeatId,
                    ForestFcvVcfId = aig.ForestFcvVcfId,

                    ForestCircle = aig.ForestCircle!.Name,
                    ForestDivision = aig.ForestDivision!.Name,
                    ForestRange = aig.ForestRange!.Name,
                    ForestBeat = aig.ForestBeat!.Name,
                    ForestFcvVcf = aig.ForestFcvVcf!.Name,
                    ForestFcvVcfIsFcv = aig.ForestFcvVcf.IsFcv,

                    FirstSixtyPercentRepaymentAmount = repayment.FirstSixtyPercentRepaymentAmount,
                    SecondFortyPercentRepaymentAmount = repayment.SecondFortyPercentRepaymentAmount,

                    RepaymentStartDate = repayment.RepaymentStartDate,
                    RepaymentEndDate = repayment.RepaymentEndDate,
                    PaymentCompletedDateTime = repayment.PaymentCompletedDateTime,
                    IsPaymentCompleted = repayment.IsPaymentCompleted,

                    IsAdvance = true,
                })
                .ToListAsync();

            var mergedList = dateRangeRepayments.Concat(advanceRecoveredRepayments);

            var finalResult = mergedList
                .GroupBy(x => new { x.ForestCircleId, x.ForestDivisionId, x.ForestRangeId, x.ForestBeatId, x.ForestFcvVcfId })
                .Select(group => new CumulativeRecoveryRateVM
                {
                    ForestCircle = group.Where(x => x.ForestCircleId == group.Key.ForestCircleId).Select(x => x.ForestCircle).First(),
                    ForestDivision = group.Where(x => x.ForestDivisionId == group.Key.ForestDivisionId).Select(x => x.ForestDivision).First(),
                    ForestRange = group.Where(x => x.ForestRangeId == group.Key.ForestRangeId).Select(x => x.ForestRange).First(),
                    ForestBeat = group.Where(x => x.ForestBeatId == group.Key.ForestBeatId).Select(x => x.ForestBeat).First(),
                    ForestFcvVcf = group.Where(x => x.ForestFcvVcfId == group.Key.ForestFcvVcfId).Select(x => x.ForestFcvVcf).First(),
                    ForestFcvVcfIsFcv = group.Where(x => x.ForestFcvVcfId == group.Key.ForestFcvVcfId).Select(x => x.ForestFcvVcfIsFcv).First(),

                    DateWiseRecoveredTk = Math.Round(group.Where(x => x.IsAdvance == false && x.IsPaymentCompleted).Sum(x => x.TotalRepaymentAmount), 2),
                    AdvancedRecoveryTk = Math.Round(group.Where(x => x.IsAdvance == true).Sum(x => x.TotalRepaymentAmount), 2),
                    ExpectedRecoveryTk = Math.Round(group.Where(x => x.IsAdvance == false).Sum(x => x.TotalRepaymentAmount), 2),
                })
                .ToList();

            return (ExecutionState.Success, finalResult!, "Returned successfully");
        }
        #endregion

        public override async Task<(ExecutionState executionState, AIGBasicInformation entity, string message)> CreateAsync(AIGBasicInformation entity)
        {
            var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable);

            try
            {
                var account = await _readOnlyCtx.Set<Account>()
                    .Where(x => x.Id == entity.AccountId)
                    .FirstOrDefaultAsync();
                if (account is null)
                {
                    return (ExecutionState.Failure, null!, "Invalid account");
                }
                if (account.AccountAllowedFundExpenses.Contains(Common.Enum.AccountManagement.AccountAllowedFundExpense.AIG) == false)
                {
                    return (ExecutionState.Failure, null!, "Account is not allowed for AIG/LDF");
                }

                var eligibility = await AIGBeneficiaryCheckEligibility(entity.SurveyId);
                if (eligibility.entity is not null && !eligibility.entity.AllPreviousLoanCompleted)
                {
                    return (ExecutionState.Failure, null!, "Previous loan is not completed");
                }

                account.CurrentBlockAmount += entity.TotalAllocatedLoanAmount;
                if (account.CurrentAvailableBalance < 0)
                {
                    return (ExecutionState.Failure, null!, "Account does not have enough available balance");
                }

                entity.EndDate = entity.StartDate.AddMonths(entity.MaximumRepaymentMonth);

                var countInCompletedLoan = await _readOnlyCtx.Set<RepaymentLDF>()
                    .CountAsync(x => x.AIGBasicInformation!.SurveyId == entity!.SurveyId && x.IsPaymentCompleted == false);
                if (countInCompletedLoan > 0)
                {
                    return (ExecutionState.Success, null!, "Previous loan is not completed");
                }

                var ldfCount = 0;
                var ldfExists = await _readOnlyCtx.Set<AIGBasicInformation>().AnyAsync(x => x.SurveyId == entity.SurveyId);
                if (ldfExists)
                {
                    ldfCount = await _readOnlyCtx.Set<AIGBasicInformation>().Where(x => x.SurveyId == entity.SurveyId).MaxAsync(x => x.LDFCount);
                }
                entity.LDFCount = ldfCount + 1;

                _writeOnlyCtx.Set<AIGBasicInformation>().Add(entity);

                await _writeOnlyCtx.SaveChangesAsync();
                await transaction.CommitAsync();

                return (ExecutionState.Created, entity, "Created successfully");
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return (ExecutionState.Failure, null!, "Unexpected error occurred");
            }
        }

        public async Task<(ExecutionState executionState, bool entity, string message)> SetBadLoanData()
        {
            try
            {
                await SetBadLoan(_readOnlyCtx, _writeOnlyCtx);

                return (ExecutionState.Success, true, "Successfully set bad loan");
            }
            catch (Exception)
            {
                return (ExecutionState.Failure, false, "Failed to set bad loan");
            }
        }

        public static async Task SetBadLoan(GENERICReadOnlyCtx _readOnlyCtx, GENERICWriteOnlyCtx _writeOnlyCtx, long? aigId = null)
        {
            var currentDate = DateTime.Now;
            var hasAigId = aigId is not null && aigId > 0;

            var suspects = await _readOnlyCtx.Set<RepaymentLDF>()
                .WhereIf(hasAigId, x => x.AIGBasicInformationId == aigId)
                .Where(x => x.RepaymentEndDate < currentDate && x.IsPaymentCompleted == false)
                .Select(x => new
                {
                    x.AIGBasicInformationId,
                    x.RepaymentEndDate,
                })
                .ToListAsync();
            if (suspects.Count == 0)
            {
                if (hasAigId)
                {
                    await _writeOnlyCtx.Set<AIGBasicInformation>()
                        .Where(x => x.Id == aigId)
                        .ExecuteUpdateAsync(x => x.SetProperty(y => y.BadLoanType, BadLoanType.Regular));
                }

                return;
            }

            var evilWealth = suspects
                .Where(x => currentDate > x.RepaymentEndDate.AddMonths(12))
                .ToList();
            var suspiciousWealth = suspects
                .Where(x => evilWealth.Select(x => x.AIGBasicInformationId).Contains(x.AIGBasicInformationId) == false)
                .Where(x => x.RepaymentEndDate.AddMonths(6) < currentDate && currentDate <= x.RepaymentEndDate.AddMonths(12))
                .ToList();
            var inferiorWealth = suspects
                .Where(x => suspiciousWealth.Concat(evilWealth).Select(x => x.AIGBasicInformationId).Contains(x.AIGBasicInformationId) == false)
                .Where(x => x.RepaymentEndDate.AddMonths(1) < currentDate && currentDate <= x.RepaymentEndDate.AddMonths(6))
                .ToList();
            var underObserver = suspects
                .Where(x => inferiorWealth.Concat(suspiciousWealth).Concat(evilWealth).Select(x => x.AIGBasicInformationId).Contains(x.AIGBasicInformationId) == false)
                .Where(x => currentDate <= x.RepaymentEndDate.AddMonths(1))
                .ToList();

            if (hasAigId && evilWealth.Count + suspiciousWealth.Count + inferiorWealth.Count + underObserver.Count == 0)
            {
                await _writeOnlyCtx.Set<AIGBasicInformation>()
                    .Where(x => x.Id == aigId)
                    .ExecuteUpdateAsync(x => x.SetProperty(y => y.BadLoanType, BadLoanType.Regular));

                return;
            }

            await _writeOnlyCtx.Set<AIGBasicInformation>()
                .Where(x => evilWealth.Select(y => y.AIGBasicInformationId).Contains(x.Id))
                .ExecuteUpdateAsync(x => x.SetProperty(y => y.BadLoanType, BadLoanType.EvilLoan));

            await _writeOnlyCtx.Set<AIGBasicInformation>()
                .Where(x => suspiciousWealth.Select(y => y.AIGBasicInformationId).Contains(x.Id))
                .ExecuteUpdateAsync(x => x.SetProperty(y => y.BadLoanType, BadLoanType.SuspiciousLoan));

            await _writeOnlyCtx.Set<AIGBasicInformation>()
                .Where(x => inferiorWealth.Select(y => y.AIGBasicInformationId).Contains(x.Id))
                .ExecuteUpdateAsync(x => x.SetProperty(y => y.BadLoanType, BadLoanType.InferiorLoan));

            await _writeOnlyCtx.Set<AIGBasicInformation>()
                .Where(x => underObserver.Select(y => y.AIGBasicInformationId).Contains(x.Id))
                .ExecuteUpdateAsync(x => x.SetProperty(y => y.BadLoanType, BadLoanType.UnderObservation));

            if (hasAigId == false)
            {
                await _writeOnlyCtx.Set<AIGBasicInformation>()
                    .Where(x => suspects.Select(y => y.AIGBasicInformationId).Contains(x.Id) == false)
                    .ExecuteUpdateAsync(x => x.SetProperty(y => y.BadLoanType, BadLoanType.Regular));
            }
        }

        public async Task<(ExecutionState executionState, List<OnTimeRecoveryRateVM> entity, string message)> OnTimeRecoveryRate(OnTimeRecoveryRateFilterVM filter)
        {
            IQueryable<AIGBasicInformation> query = _readOnlyCtx.Set<AIGBasicInformation>()
                .FilterByLocation(filter);

            var sumOfRegularRecoveryDuringThePeriod = await query.SelectMany(
                    x => x.RepaymentLDFs!.Where(
                            y => (y.RepaymentStartDate >= filter.FromDate)
                                    && (y.RepaymentEndDate <= filter.ToDate)
                                    && y.IsPaymentCompleted
                        ),
                (aig, repayment) => new OnTimeRecoveryRateHelper
                {
                    AIGBasicInformationId = aig.Id,
                    SurveyId = aig.SurveyId,

                    ForestCircleId = aig.ForestCircleId,
                    ForestDivisionId = aig.ForestDivisionId,
                    ForestRangeId = aig.ForestRangeId,
                    ForestBeatId = aig.ForestBeatId,
                    ForestFcvVcfId = aig.ForestFcvVcfId,

                    ForestCircle = aig.ForestCircle!.Name,
                    ForestDivision = aig.ForestDivision!.Name,
                    ForestRange = aig.ForestRange!.Name,
                    ForestBeat = aig.ForestBeat!.Name,
                    ForestFcvVcf = aig.ForestFcvVcf!.Name,
                    ForestFcvVcfIsFcv = aig.ForestFcvVcf.IsFcv,

                    FirstSixtyPercentRepaymentAmount = repayment.FirstSixtyPercentRepaymentAmount,
                    SecondFortyPercentRepaymentAmount = repayment.SecondFortyPercentRepaymentAmount,

                    RepaymentStartDate = repayment.RepaymentStartDate,
                    RepaymentEndDate = repayment.RepaymentEndDate,
                    PaymentCompletedDateTime = repayment.PaymentCompletedDateTime,
                    IsPaymentCompleted = repayment.IsPaymentCompleted,
                })
                .ToListAsync();

            var sumOfRegularRecoverableDuringThePeriod = await query.SelectMany(
                 //x => x.RepaymentLDFs!.Where(
                 //y => (y.PaymentCompletedDateTime <= filter.ToDate)
                 // && (filter.FromDate <= y.PaymentCompletedDateTime)
                 // && (filter.ToDate < y.RepaymentStartDate)
                 // && y.IsPaymentCompleted
                 //),
                 x => x.RepaymentLDFs!.Where(
                            y => (y.RepaymentStartDate >= filter.FromDate)
                                    && (y.RepaymentEndDate <= filter.ToDate)
                        ),


                (aig, repayment) => new OnTimeRecoveryRateHelper
                {
                    AIGBasicInformationId = aig.Id,
                    SurveyId = aig.SurveyId,

                    ForestCircleId = aig.ForestCircleId,
                    ForestDivisionId = aig.ForestDivisionId,
                    ForestRangeId = aig.ForestRangeId,
                    ForestBeatId = aig.ForestBeatId,
                    ForestFcvVcfId = aig.ForestFcvVcfId,

                    ForestCircle = aig.ForestCircle!.Name,
                    ForestDivision = aig.ForestDivision!.Name,
                    ForestRange = aig.ForestRange!.Name,
                    ForestBeat = aig.ForestBeat!.Name,
                    ForestFcvVcf = aig.ForestFcvVcf!.Name,
                    ForestFcvVcfIsFcv = aig.ForestFcvVcf.IsFcv,

                    FirstSixtyPercentRepaymentAmount = repayment.FirstSixtyPercentRepaymentAmount,
                    SecondFortyPercentRepaymentAmount = repayment.SecondFortyPercentRepaymentAmount,

                    RepaymentStartDate = repayment.RepaymentStartDate,
                    RepaymentEndDate = repayment.RepaymentEndDate,
                    PaymentCompletedDateTime = repayment.PaymentCompletedDateTime,
                    IsPaymentCompleted = repayment.IsPaymentCompleted,

                    IsAdvance = true,
                })
                .ToListAsync();

            var mergedList = sumOfRegularRecoveryDuringThePeriod.Concat(sumOfRegularRecoverableDuringThePeriod);

            var finalResult = mergedList
                .GroupBy(x => new { x.ForestCircleId, x.ForestDivisionId, x.ForestRangeId, x.ForestBeatId, x.ForestFcvVcfId })
                .Select(group => new OnTimeRecoveryRateVM
                {
                    ForestCircle = group.Where(x => x.ForestCircleId == group.Key.ForestCircleId).Select(x => x.ForestCircle).First(),
                    ForestDivision = group.Where(x => x.ForestDivisionId == group.Key.ForestDivisionId).Select(x => x.ForestDivision).First(),
                    ForestRange = group.Where(x => x.ForestRangeId == group.Key.ForestRangeId).Select(x => x.ForestRange).First(),
                    ForestBeat = group.Where(x => x.ForestBeatId == group.Key.ForestBeatId).Select(x => x.ForestBeat).First(),
                    ForestFcvVcf = group.Where(x => x.ForestFcvVcfId == group.Key.ForestFcvVcfId).Select(x => x.ForestFcvVcf).First(),
                    ForestFcvVcfIsFcv = group.Where(x => x.ForestFcvVcfId == group.Key.ForestFcvVcfId).Select(x => x.ForestFcvVcfIsFcv).First(),

                    //OnTimeRecoveryRate = Math.Round(group.Where(x => x.IsAdvance == false && x.IsPaymentCompleted).Sum(x => x.TotalRepaymentAmount), 2),
                    SumOfRegularRecoveryDuringThePeriodTk = Math.Round(group.Where(x => x.IsPaymentCompleted == true).Sum(x => x.TotalRepaymentAmount), 2),
                    SumOfRegularRecoverableDuringThePeriodTk = Math.Round(group.Sum(x => x.TotalRepaymentAmount), 2),
                })
                .ToList();

            return (ExecutionState.Success, finalResult!, "Returned successfully");
        }

        public async Task<(ExecutionState executionState, List<PortfolioAtRiskVM> entity, string message)> PortfolioAtRisk(PortfolioAtRiskFilterVM filter)
        {
            IQueryable<AIGBasicInformation> query = _readOnlyCtx.Set<AIGBasicInformation>()
                .FilterByLocation(filter);

            var onlyDefotdatLoanAmount = await query.SelectMany(
                    x => x.RepaymentLDFs!.Where(
                            y => (y.RepaymentStartDate >= filter.FromDate)
                                    && (y.RepaymentEndDate <= filter.ToDate)
                                    //&& y.IsPaymentCompleted
                        ),
                (aig, repayment) => new PortfolioAtRiskHelper
                {
                    AIGBasicInformationId = aig.Id,
                    SurveyId = aig.SurveyId,

                    ForestCircleId = aig.ForestCircleId,
                    ForestDivisionId = aig.ForestDivisionId,
                    ForestRangeId = aig.ForestRangeId,
                    ForestBeatId = aig.ForestBeatId,
                    ForestFcvVcfId = aig.ForestFcvVcfId,

                    ForestCircle = aig.ForestCircle!.Name,
                    ForestDivision = aig.ForestDivision!.Name,
                    ForestRange = aig.ForestRange!.Name,
                    ForestBeat = aig.ForestBeat!.Name,
                    ForestFcvVcf = aig.ForestFcvVcf!.Name,
                    ForestFcvVcfIsFcv = aig.ForestFcvVcf.IsFcv,

                    FirstSixtyPercentRepaymentAmount = repayment.FirstSixtyPercentRepaymentAmount,
                    SecondFortyPercentRepaymentAmount = repayment.SecondFortyPercentRepaymentAmount,

                    RepaymentStartDate = repayment.RepaymentStartDate,
                    RepaymentEndDate = repayment.RepaymentEndDate,
                    PaymentCompletedDateTime = repayment.PaymentCompletedDateTime,
                    IsPaymentCompleted = repayment.IsPaymentCompleted,
                })
                .ToListAsync();

            var afterDefolderPayAmount = await query.SelectMany(
                 //x => x.RepaymentLDFs!.Where(
                 //y => (y.PaymentCompletedDateTime <= filter.ToDate)
                 // && (filter.FromDate <= y.PaymentCompletedDateTime)
                 // && (filter.ToDate < y.RepaymentStartDate)
                 // && y.IsPaymentCompleted
                 //),
                 x => x.RepaymentLDFs!.Where(
                            y => (y.RepaymentStartDate >= filter.FromDate)
                                    && (y.RepaymentEndDate <= filter.ToDate)
                                    && y.RepaymentEndDate < y.PaymentCompletedDateTime
                        ),


                (aig, repayment) => new PortfolioAtRiskHelper
                {
                    AIGBasicInformationId = aig.Id,
                    SurveyId = aig.SurveyId,

                    ForestCircleId = aig.ForestCircleId,
                    ForestDivisionId = aig.ForestDivisionId,
                    ForestRangeId = aig.ForestRangeId,
                    ForestBeatId = aig.ForestBeatId,
                    ForestFcvVcfId = aig.ForestFcvVcfId,

                    ForestCircle = aig.ForestCircle!.Name,
                    ForestDivision = aig.ForestDivision!.Name,
                    ForestRange = aig.ForestRange!.Name,
                    ForestBeat = aig.ForestBeat!.Name,
                    ForestFcvVcf = aig.ForestFcvVcf!.Name,
                    ForestFcvVcfIsFcv = aig.ForestFcvVcf.IsFcv,

                    FirstSixtyPercentRepaymentAmount = repayment.FirstSixtyPercentRepaymentAmount,
                    SecondFortyPercentRepaymentAmount = repayment.SecondFortyPercentRepaymentAmount,

                    RepaymentStartDate = repayment.RepaymentStartDate,
                    RepaymentEndDate = repayment.RepaymentEndDate,
                    PaymentCompletedDateTime = repayment.PaymentCompletedDateTime,
                    IsPaymentCompleted = repayment.IsPaymentCompleted,

                    IsAdvance = true,
                })
                .ToListAsync();



            var totalPayableAmount = await query.SelectMany(
                    x => x.RepaymentLDFs!.Where(
                            y => (y.RepaymentStartDate >= filter.FromDate)
                                    && (y.RepaymentEndDate <= filter.ToDate)
                        //&& y.IsPaymentCompleted
                        ),
                (aig, repayment) => new PortfolioAtRiskHelper
                {
                    AIGBasicInformationId = aig.Id,
                    SurveyId = aig.SurveyId,

                    ForestCircleId = aig.ForestCircleId,
                    ForestDivisionId = aig.ForestDivisionId,
                    ForestRangeId = aig.ForestRangeId,
                    ForestBeatId = aig.ForestBeatId,
                    ForestFcvVcfId = aig.ForestFcvVcfId,

                    ForestCircle = aig.ForestCircle!.Name,
                    ForestDivision = aig.ForestDivision!.Name,
                    ForestRange = aig.ForestRange!.Name,
                    ForestBeat = aig.ForestBeat!.Name,
                    ForestFcvVcf = aig.ForestFcvVcf!.Name,
                    ForestFcvVcfIsFcv = aig.ForestFcvVcf.IsFcv,

                    FirstSixtyPercentRepaymentAmount = repayment.FirstSixtyPercentRepaymentAmount,
                    SecondFortyPercentRepaymentAmount = repayment.SecondFortyPercentRepaymentAmount,

                    RepaymentStartDate = repayment.RepaymentStartDate,
                    RepaymentEndDate = repayment.RepaymentEndDate,
                    PaymentCompletedDateTime = repayment.PaymentCompletedDateTime,
                    IsPaymentCompleted = repayment.IsPaymentCompleted,
                })
                .ToListAsync();




            var alreadyPayAmount = await query.SelectMany(
                    x => x.RepaymentLDFs!.Where(
                            y => (y.RepaymentStartDate >= filter.FromDate)
                                    && (y.RepaymentEndDate <= filter.ToDate)
                                    && y.IsPaymentCompleted
                        ),
                (aig, repayment) => new PortfolioAtRiskHelper
                {
                    AIGBasicInformationId = aig.Id,
                    SurveyId = aig.SurveyId,

                    ForestCircleId = aig.ForestCircleId,
                    ForestDivisionId = aig.ForestDivisionId,
                    ForestRangeId = aig.ForestRangeId,
                    ForestBeatId = aig.ForestBeatId,
                    ForestFcvVcfId = aig.ForestFcvVcfId,

                    ForestCircle = aig.ForestCircle!.Name,
                    ForestDivision = aig.ForestDivision!.Name,
                    ForestRange = aig.ForestRange!.Name,
                    ForestBeat = aig.ForestBeat!.Name,
                    ForestFcvVcf = aig.ForestFcvVcf!.Name,
                    ForestFcvVcfIsFcv = aig.ForestFcvVcf.IsFcv,

                    FirstSixtyPercentRepaymentAmount = repayment.FirstSixtyPercentRepaymentAmount,
                    SecondFortyPercentRepaymentAmount = repayment.SecondFortyPercentRepaymentAmount,

                    RepaymentStartDate = repayment.RepaymentStartDate,
                    RepaymentEndDate = repayment.RepaymentEndDate,
                    PaymentCompletedDateTime = repayment.PaymentCompletedDateTime,
                    IsPaymentCompleted = repayment.IsPaymentCompleted,
                })
                .ToListAsync();


            var mergedList = onlyDefotdatLoanAmount.Concat(afterDefolderPayAmount).Concat(totalPayableAmount).Concat(alreadyPayAmount);

            var finalResult = mergedList
                .GroupBy(x => new { x.ForestCircleId, x.ForestDivisionId, x.ForestRangeId, x.ForestBeatId, x.ForestFcvVcfId })
                .Select(group => new PortfolioAtRiskVM
                {
                    ForestCircle = group.Where(x => x.ForestCircleId == group.Key.ForestCircleId).Select(x => x.ForestCircle).First(),
                    ForestDivision = group.Where(x => x.ForestDivisionId == group.Key.ForestDivisionId).Select(x => x.ForestDivision).First(),
                    ForestRange = group.Where(x => x.ForestRangeId == group.Key.ForestRangeId).Select(x => x.ForestRange).First(),
                    ForestBeat = group.Where(x => x.ForestBeatId == group.Key.ForestBeatId).Select(x => x.ForestBeat).First(),
                    ForestFcvVcf = group.Where(x => x.ForestFcvVcfId == group.Key.ForestFcvVcfId).Select(x => x.ForestFcvVcf).First(),
                    ForestFcvVcfIsFcv = group.Where(x => x.ForestFcvVcfId == group.Key.ForestFcvVcfId).Select(x => x.ForestFcvVcfIsFcv).First(),

                    //OnTimeRecoveryRate = Math.Round(group.Where(x => x.IsAdvance == false && x.IsPaymentCompleted).Sum(x => x.TotalRepaymentAmount), 2),
                    OnlyDefotdatLoanAmountTk = Math.Round(group.Where(x => x.IsPaymentCompleted == false).Sum(x => x.TotalRepaymentAmount), 2),
                    AfterDefolderPayAmountTk = Math.Round(group.Where(x => x.RepaymentEndDate < x.PaymentCompletedDateTime).Sum(x => x.TotalRepaymentAmount), 2),
                    TotalPayableAmountTk = Math.Round(group.Sum(x => x.TotalRepaymentAmount), 2),
                    AlreadyPayAmountTk = Math.Round(group.Where(x => x.IsPaymentCompleted == true).Sum(x => x.TotalRepaymentAmount), 2),

                })
                .ToList();

            return (ExecutionState.Success, finalResult!, "Returned successfully");
        }

        public async Task<(ExecutionState executionState, List<DelinquencyRatioVM> entity, string message)> DelinquencyRatio(DelinquencyRatioFilterVM filter)
        {
            IQueryable<AIGBasicInformation> query = _readOnlyCtx.Set<AIGBasicInformation>()
                .FilterByLocation(filter);

            var overTimePaymentTk = await query.SelectMany(
                    x => x.RepaymentLDFs!.Where(
                            y => (y.RepaymentStartDate >= filter.FromDate)
                                    && (y.RepaymentEndDate <= filter.ToDate)
                                    && y.RepaymentEndDate < y.PaymentCompletedDateTime
                        ),
                (aig, repayment) => new DelinquencyRatioHelper
                {
                    AIGBasicInformationId = aig.Id,
                    SurveyId = aig.SurveyId,

                    ForestCircleId = aig.ForestCircleId,
                    ForestDivisionId = aig.ForestDivisionId,
                    ForestRangeId = aig.ForestRangeId,
                    ForestBeatId = aig.ForestBeatId,
                    ForestFcvVcfId = aig.ForestFcvVcfId,

                    ForestCircle = aig.ForestCircle!.Name,
                    ForestDivision = aig.ForestDivision!.Name,
                    ForestRange = aig.ForestRange!.Name,
                    ForestBeat = aig.ForestBeat!.Name,
                    ForestFcvVcf = aig.ForestFcvVcf!.Name,
                    ForestFcvVcfIsFcv = aig.ForestFcvVcf.IsFcv,

                    FirstSixtyPercentRepaymentAmount = repayment.FirstSixtyPercentRepaymentAmount,
                    SecondFortyPercentRepaymentAmount = repayment.SecondFortyPercentRepaymentAmount,

                    RepaymentStartDate = repayment.RepaymentStartDate,
                    RepaymentEndDate = repayment.RepaymentEndDate,
                    PaymentCompletedDateTime = repayment.PaymentCompletedDateTime,
                    IsPaymentCompleted = repayment.IsPaymentCompleted,
                })
                .ToListAsync();

            var duePayment = await query.SelectMany(
                 //x => x.RepaymentLDFs!.Where(
                 //y => (y.PaymentCompletedDateTime <= filter.ToDate)
                 // && (filter.FromDate <= y.PaymentCompletedDateTime)
                 // && (filter.ToDate < y.RepaymentStartDate)
                 // && y.IsPaymentCompleted
                 //),
                 x => x.RepaymentLDFs!.Where(
                            y => (y.RepaymentStartDate >= filter.FromDate)
                                    && (y.RepaymentEndDate <= filter.ToDate)
                                    && y.RepaymentEndDate < y.PaymentCompletedDateTime
                                    && y.IsPaymentCompleted
                        ),


                (aig, repayment) => new DelinquencyRatioHelper
                {
                    AIGBasicInformationId = aig.Id,
                    SurveyId = aig.SurveyId,

                    ForestCircleId = aig.ForestCircleId,
                    ForestDivisionId = aig.ForestDivisionId,
                    ForestRangeId = aig.ForestRangeId,
                    ForestBeatId = aig.ForestBeatId,
                    ForestFcvVcfId = aig.ForestFcvVcfId,

                    ForestCircle = aig.ForestCircle!.Name,
                    ForestDivision = aig.ForestDivision!.Name,
                    ForestRange = aig.ForestRange!.Name,
                    ForestBeat = aig.ForestBeat!.Name,
                    ForestFcvVcf = aig.ForestFcvVcf!.Name,
                    ForestFcvVcfIsFcv = aig.ForestFcvVcf.IsFcv,

                    FirstSixtyPercentRepaymentAmount = repayment.FirstSixtyPercentRepaymentAmount,
                    SecondFortyPercentRepaymentAmount = repayment.SecondFortyPercentRepaymentAmount,

                    RepaymentStartDate = repayment.RepaymentStartDate,
                    RepaymentEndDate = repayment.RepaymentEndDate,
                    PaymentCompletedDateTime = repayment.PaymentCompletedDateTime,
                    IsPaymentCompleted = repayment.IsPaymentCompleted,

                    IsAdvance = true,
                })
                .ToListAsync();



            var totalPayableAmount = await query.SelectMany(
                    x => x.RepaymentLDFs!.Where(
                            y => (y.RepaymentStartDate >= filter.FromDate)
                                    && (y.RepaymentEndDate <= filter.ToDate)
                        //&& y.IsPaymentCompleted
                        ),
                (aig, repayment) => new DelinquencyRatioHelper
                {
                    AIGBasicInformationId = aig.Id,
                    SurveyId = aig.SurveyId,

                    ForestCircleId = aig.ForestCircleId,
                    ForestDivisionId = aig.ForestDivisionId,
                    ForestRangeId = aig.ForestRangeId,
                    ForestBeatId = aig.ForestBeatId,
                    ForestFcvVcfId = aig.ForestFcvVcfId,

                    ForestCircle = aig.ForestCircle!.Name,
                    ForestDivision = aig.ForestDivision!.Name,
                    ForestRange = aig.ForestRange!.Name,
                    ForestBeat = aig.ForestBeat!.Name,
                    ForestFcvVcf = aig.ForestFcvVcf!.Name,
                    ForestFcvVcfIsFcv = aig.ForestFcvVcf.IsFcv,

                    FirstSixtyPercentRepaymentAmount = repayment.FirstSixtyPercentRepaymentAmount,
                    SecondFortyPercentRepaymentAmount = repayment.SecondFortyPercentRepaymentAmount,

                    RepaymentStartDate = repayment.RepaymentStartDate,
                    RepaymentEndDate = repayment.RepaymentEndDate,
                    PaymentCompletedDateTime = repayment.PaymentCompletedDateTime,
                    IsPaymentCompleted = repayment.IsPaymentCompleted,
                })
                .ToListAsync();




            var alreadyPayAmount = await query.SelectMany(
                    x => x.RepaymentLDFs!.Where(
                            y => (y.RepaymentStartDate >= filter.FromDate)
                                    && (y.RepaymentEndDate <= filter.ToDate)
                                    && y.IsPaymentCompleted
                        ),
                (aig, repayment) => new DelinquencyRatioHelper
                {
                    AIGBasicInformationId = aig.Id,
                    SurveyId = aig.SurveyId,

                    ForestCircleId = aig.ForestCircleId,
                    ForestDivisionId = aig.ForestDivisionId,
                    ForestRangeId = aig.ForestRangeId,
                    ForestBeatId = aig.ForestBeatId,
                    ForestFcvVcfId = aig.ForestFcvVcfId,

                    ForestCircle = aig.ForestCircle!.Name,
                    ForestDivision = aig.ForestDivision!.Name,
                    ForestRange = aig.ForestRange!.Name,
                    ForestBeat = aig.ForestBeat!.Name,
                    ForestFcvVcf = aig.ForestFcvVcf!.Name,
                    ForestFcvVcfIsFcv = aig.ForestFcvVcf.IsFcv,

                    FirstSixtyPercentRepaymentAmount = repayment.FirstSixtyPercentRepaymentAmount,
                    SecondFortyPercentRepaymentAmount = repayment.SecondFortyPercentRepaymentAmount,

                    RepaymentStartDate = repayment.RepaymentStartDate,
                    RepaymentEndDate = repayment.RepaymentEndDate,
                    PaymentCompletedDateTime = repayment.PaymentCompletedDateTime,
                    IsPaymentCompleted = repayment.IsPaymentCompleted,
                })
                .ToListAsync();


            var mergedList = overTimePaymentTk.Concat(duePayment).Concat(totalPayableAmount).Concat(alreadyPayAmount);

            var finalResult = mergedList
                .GroupBy(x => new { x.ForestCircleId, x.ForestDivisionId, x.ForestRangeId, x.ForestBeatId, x.ForestFcvVcfId })
                .Select(group => new DelinquencyRatioVM
                {
                    ForestCircle = group.Where(x => x.ForestCircleId == group.Key.ForestCircleId).Select(x => x.ForestCircle).First(),
                    ForestDivision = group.Where(x => x.ForestDivisionId == group.Key.ForestDivisionId).Select(x => x.ForestDivision).First(),
                    ForestRange = group.Where(x => x.ForestRangeId == group.Key.ForestRangeId).Select(x => x.ForestRange).First(),
                    ForestBeat = group.Where(x => x.ForestBeatId == group.Key.ForestBeatId).Select(x => x.ForestBeat).First(),
                    ForestFcvVcf = group.Where(x => x.ForestFcvVcfId == group.Key.ForestFcvVcfId).Select(x => x.ForestFcvVcf).First(),
                    ForestFcvVcfIsFcv = group.Where(x => x.ForestFcvVcfId == group.Key.ForestFcvVcfId).Select(x => x.ForestFcvVcfIsFcv).First(),

                    //OnTimeRecoveryRate = Math.Round(group.Where(x => x.IsAdvance == false && x.IsPaymentCompleted).Sum(x => x.TotalRepaymentAmount), 2),
                    OverTimePaymentTk = Math.Round(group.Sum(x => x.TotalRepaymentAmount), 2),
                    DuePaymentTk = Math.Round(group.Where(x => x.IsPaymentCompleted == false).Sum(x => x.TotalRepaymentAmount), 2),
                    TotalPayableAmountTk = Math.Round(group.Sum(x => x.TotalRepaymentAmount), 2),
                    AlreadyPayAmountTk = Math.Round(group.Where(x => x.IsPaymentCompleted == true).Sum(x => x.TotalRepaymentAmount), 2),

                })
                .ToList();

            return (ExecutionState.Success, finalResult!, "Returned successfully");
        }

        public async Task<(ExecutionState executionState, List<BorrowerPerVillageVM> entity, string message)> BorrowerPerVillageReport(BorrowerPerVillageFilterVM filter)
        {
            IQueryable<Survey> query = _readOnlyCtx.Set<Survey>()
                .FilterSurvey(filter);

            var groups = await query
                .Where(x => x.ForestFcvVcf!.IsFcv)
                .Include(x => x.AIGBasicInformations)
                .Select(x => new
                {
                    x.ForestCircleId,
                    x.ForestDivisionId,
                    x.ForestRangeId,
                    x.ForestBeatId,
                    x.ForestFcvVcfId,

                    ForestCircle = x.ForestCircle!.Name,
                    ForestDivision = x.ForestDivision!.Name,
                    ForestRange = x.ForestRange!.Name,
                    ForestBeat = x.ForestBeat!.Name,
                    ForestFcvVcf = x.ForestFcvVcf!.Name,

                    x.Id,
                    x.AIGBasicInformations
                })
                .ToListAsync();

            var result = groups
                .GroupBy(x => new { x.ForestCircleId, x.ForestDivisionId, x.ForestRangeId, x.ForestBeatId, x.ForestFcvVcfId })
                .Select(group => new BorrowerPerVillageVM
                {
                    ForestCircle = group.Where(x => x.ForestCircleId == group.Key.ForestCircleId).Select(x => x.ForestCircle).First(),
                    ForestDivision = group.Where(x => x.ForestDivisionId == group.Key.ForestDivisionId).Select(x => x.ForestDivision).First(),
                    ForestRange = group.Where(x => x.ForestRangeId == group.Key.ForestRangeId).Select(x => x.ForestRange).First(),
                    ForestBeat = group.Where(x => x.ForestBeatId == group.Key.ForestBeatId).Select(x => x.ForestBeat).First(),
                    ForestFcvVcf = group.Where(x => x.ForestFcvVcfId == group.Key.ForestFcvVcfId).Select(x => x.ForestFcvVcf).First(),

                    TotalBorrower = group.Where(x => x.AIGBasicInformations?.Count > 0).Count(),
                    TotalVillage = group.Count()
                })
                .ToList();

            return (ExecutionState.Success, result!, "Returned successfully");
        }

        public async Task<(ExecutionState executionState, List<BorrowerCoverageVM> entity, string message)> BorrowerCoverageReport(BorrowerCoverageFilterVM filter)
        {
            IQueryable<Survey> query = _readOnlyCtx.Set<Survey>()
                .FilterSurvey(filter);

            var groups = await query
                .Where(x => x.ForestFcvVcf!.IsFcv)
                .Include(x => x.AIGBasicInformations!)
                .ThenInclude(x => x.RepaymentLDFs)
                .Select(x => new
                {
                    x.ForestCircleId,
                    x.ForestDivisionId,
                    x.ForestRangeId,
                    x.ForestBeatId,
                    x.ForestFcvVcfId,

                    ForestCircle = x.ForestCircle!.Name,
                    ForestDivision = x.ForestDivision!.Name,
                    ForestRange = x.ForestRange!.Name,
                    ForestBeat = x.ForestBeat!.Name,
                    ForestFcvVcf = x.ForestFcvVcf!.Name,

                    x.Id,
                    x.AIGBasicInformations,
                })
                .ToListAsync();

            var result = groups
                .GroupBy(x => new { x.ForestCircleId, x.ForestDivisionId, x.ForestRangeId, x.ForestBeatId, x.ForestFcvVcfId })
                .Select(group => new BorrowerCoverageVM
                {
                    ForestCircle = group.Where(x => x.ForestCircleId == group.Key.ForestCircleId).Select(x => x.ForestCircle).First(),
                    ForestDivision = group.Where(x => x.ForestDivisionId == group.Key.ForestDivisionId).Select(x => x.ForestDivision).First(),
                    ForestRange = group.Where(x => x.ForestRangeId == group.Key.ForestRangeId).Select(x => x.ForestRange).First(),
                    ForestBeat = group.Where(x => x.ForestBeatId == group.Key.ForestBeatId).Select(x => x.ForestBeat).First(),
                    ForestFcvVcf = group.Where(x => x.ForestFcvVcfId == group.Key.ForestFcvVcfId).Select(x => x.ForestFcvVcf).First(),

                    CurrentBorrower = group // Change this to AIG Bad loan type check
                        .Where(x => x.AIGBasicInformations?.Count > 0)
                        .Where(x =>
                            x.AIGBasicInformations!.Any(
                                y => y.RepaymentLDFs?.Any(
                                    z => !z.IsPaymentCompleted) == true))
                        .Count(),
                    CurrentMember = group.Count()
                })
                .ToList();

            return (ExecutionState.Success, result!, "Returned successfully");
        }



        public async Task<(ExecutionState executionState, List<PortfolioPerVillageVM> entity, string message)> PortfolioPerVillage(PortfolioPerVillageFilterVM filter)
        {

            // NoOfTotalVillage

            IQueryable<Survey> query2 = _readOnlyCtx.Set<Survey>()
              .FilterSurvey(filter);

            var groups = await query2
                .Where(x => x.ForestFcvVcf!.IsFcv)
                .Select(x => new
                {
                    x.ForestCircleId,
                    x.ForestDivisionId,
                    x.ForestRangeId,
                    x.ForestBeatId,
                    x.ForestFcvVcfId,

                    ForestCircle = x.ForestCircle!.Name,
                    ForestDivision = x.ForestDivision!.Name,
                    ForestRange = x.ForestRange!.Name,
                    ForestBeat = x.ForestBeat!.Name,
                    ForestFcvVcf = x.ForestFcvVcf!.Name,

                    x.Id,
                })
                .ToListAsync();

            var result = groups
                .GroupBy(x => new { x.ForestCircleId, x.ForestDivisionId, x.ForestRangeId, x.ForestBeatId, x.ForestFcvVcfId })
                .Select(group => new PortfolioPerVillageHelper
                {
                    ForestCircle = group.Where(x => x.ForestCircleId == group.Key.ForestCircleId).Select(x => x.ForestCircle).First(),
                    ForestDivision = group.Where(x => x.ForestDivisionId == group.Key.ForestDivisionId).Select(x => x.ForestDivision).First(),
                    ForestRange = group.Where(x => x.ForestRangeId == group.Key.ForestRangeId).Select(x => x.ForestRange).First(),
                    ForestBeat = group.Where(x => x.ForestBeatId == group.Key.ForestBeatId).Select(x => x.ForestBeat).First(),
                    ForestFcvVcf = group.Where(x => x.ForestFcvVcfId == group.Key.ForestFcvVcfId).Select(x => x.ForestFcvVcf).First()

                    //NoOfTotalVillage = group.Count()
                })
                .ToList();



         

            // TotalOutstandingLoan

            IQueryable<AIGBasicInformation> query = _readOnlyCtx.Set<AIGBasicInformation>()
                .FilterByLocation(filter);

            
            var totalPayableAmount = await query.SelectMany(
                    x => x.RepaymentLDFs!.Where(
                            y => (y.RepaymentStartDate >= filter.FromDate)
                                    && (y.RepaymentEndDate <= filter.ToDate)
                        //&& y.IsPaymentCompleted
                        ),
                (aig, repayment) => new PortfolioPerVillageHelper
                {
                    AIGBasicInformationId = aig.Id,
                    SurveyId = aig.SurveyId,

                    ForestCircleId = aig.ForestCircleId,
                    ForestDivisionId = aig.ForestDivisionId,
                    ForestRangeId = aig.ForestRangeId,
                    ForestBeatId = aig.ForestBeatId,
                    ForestFcvVcfId = aig.ForestFcvVcfId,

                    ForestCircle = aig.ForestCircle!.Name,
                    ForestDivision = aig.ForestDivision!.Name,
                    ForestRange = aig.ForestRange!.Name,
                    ForestBeat = aig.ForestBeat!.Name,
                    ForestFcvVcf = aig.ForestFcvVcf!.Name,
                    ForestFcvVcfIsFcv = aig.ForestFcvVcf.IsFcv,

                    FirstSixtyPercentRepaymentAmount = repayment.FirstSixtyPercentRepaymentAmount,
                    SecondFortyPercentRepaymentAmount = repayment.SecondFortyPercentRepaymentAmount,

                    RepaymentStartDate = repayment.RepaymentStartDate,
                    RepaymentEndDate = repayment.RepaymentEndDate,
                    PaymentCompletedDateTime = repayment.PaymentCompletedDateTime,
                    IsPaymentCompleted = repayment.IsPaymentCompleted,
                })
                .ToListAsync();


            var alreadyPayAmount = await query.SelectMany(
                    x => x.RepaymentLDFs!.Where(
                            y => (y.RepaymentStartDate >= filter.FromDate)
                                    && (y.RepaymentEndDate <= filter.ToDate)
                                    && y.IsPaymentCompleted
                        ),
                (aig, repayment) => new PortfolioPerVillageHelper
                {
                    AIGBasicInformationId = aig.Id,
                    SurveyId = aig.SurveyId,

                    ForestCircleId = aig.ForestCircleId,
                    ForestDivisionId = aig.ForestDivisionId,
                    ForestRangeId = aig.ForestRangeId,
                    ForestBeatId = aig.ForestBeatId,
                    ForestFcvVcfId = aig.ForestFcvVcfId,

                    ForestCircle = aig.ForestCircle!.Name,
                    ForestDivision = aig.ForestDivision!.Name,
                    ForestRange = aig.ForestRange!.Name,
                    ForestBeat = aig.ForestBeat!.Name,
                    ForestFcvVcf = aig.ForestFcvVcf!.Name,
                    ForestFcvVcfIsFcv = aig.ForestFcvVcf.IsFcv,

                    FirstSixtyPercentRepaymentAmount = repayment.FirstSixtyPercentRepaymentAmount,
                    SecondFortyPercentRepaymentAmount = repayment.SecondFortyPercentRepaymentAmount,

                    RepaymentStartDate = repayment.RepaymentStartDate,
                    RepaymentEndDate = repayment.RepaymentEndDate,
                    PaymentCompletedDateTime = repayment.PaymentCompletedDateTime,
                    IsPaymentCompleted = repayment.IsPaymentCompleted,
                })
                .ToListAsync();



            var mergedList = totalPayableAmount.Concat(alreadyPayAmount).Concat(result);




            var finalResult = mergedList
                .GroupBy(x => new { x.ForestCircleId, x.ForestDivisionId, x.ForestRangeId, x.ForestBeatId, x.ForestFcvVcfId })
                .Select(group => new PortfolioPerVillageVM
                {
                    ForestCircle = group.Where(x => x.ForestCircleId == group.Key.ForestCircleId).Select(x => x.ForestCircle).First(),
                    ForestDivision = group.Where(x => x.ForestDivisionId == group.Key.ForestDivisionId).Select(x => x.ForestDivision).First(),
                    ForestRange = group.Where(x => x.ForestRangeId == group.Key.ForestRangeId).Select(x => x.ForestRange).First(),
                    ForestBeat = group.Where(x => x.ForestBeatId == group.Key.ForestBeatId).Select(x => x.ForestBeat).First(),
                    ForestFcvVcf = group.Where(x => x.ForestFcvVcfId == group.Key.ForestFcvVcfId).Select(x => x.ForestFcvVcf).First(),
                    ForestFcvVcfIsFcv = group.Where(x => x.ForestFcvVcfId == group.Key.ForestFcvVcfId).Select(x => x.ForestFcvVcfIsFcv).First(),

                    //OnTimeRecoveryRate = Math.Round(group.Where(x => x.IsAdvance == false && x.IsPaymentCompleted).Sum(x => x.TotalRepaymentAmount), 2),
                    NoOfTotalVillage = group.GroupBy(X => X.ForestFcvVcfId).Count(),
                    TotalPayableAmountTk = Math.Round(group.Sum(x => x.TotalRepaymentAmount), 2),
                    AlreadyPayAmountTk = Math.Round(group.Where(x => x.IsPaymentCompleted == true).Sum(x => x.TotalRepaymentAmount), 2),
                    TotalOutstandingLoanTk = Math.Round((group.Sum(x => x.TotalRepaymentAmount) - group.Where(x => x.IsPaymentCompleted == true).Sum(x => x.TotalRepaymentAmount)), 2),


                })
                .ToList();

            return (ExecutionState.Success, finalResult!, "Returned successfully");
        }

    }
}