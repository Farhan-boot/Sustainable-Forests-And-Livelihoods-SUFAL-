using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.InternalLoan;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.InternalLoan;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.InternalLoan
{
    public class InternalLoanInformationBusiness : BaseBusiness<InternalLoanInformation>, IInternalLoanInformationBusiness
    {
        private readonly GENERICUnitOfWork _unitOfWork;
        private readonly GENERICWriteOnlyCtx _writeOnlyCtx;
        private readonly GENERICReadOnlyCtx _readOnlyCtx;
        public InternalLoanInformationBusiness(GENERICUnitOfWork unitOfWork, GENERICWriteOnlyCtx writeOnlyCtx, GENERICReadOnlyCtx readOnlyCtx)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _writeOnlyCtx = writeOnlyCtx;
            _readOnlyCtx = readOnlyCtx;
        }
        public override Task<(ExecutionState executionState, IQueryable<InternalLoanInformation> entity, string message)> List(QueryOptions<InternalLoanInformation> queryOptions = null)
        {
            return base.List(new QueryOptions<InternalLoanInformation>
            {
                IncludeExpression = e => e
                    .Include(x => x.Ngo!)
                    .Include(x => x.RepaymentInternalLoans!)
                    .Include(x => x.Survey!),
                SortingExpression = e => e.OrderByDescending(x => x.Id)
            });
        }

        public async Task<(ExecutionState executionState, InternalLoanAvailableAmountVM entity, string message)> GetInternalLoanAvailableAmount(long fcvVcfId)
        {
            var savingsAmount = await _readOnlyCtx.Set<SavingsAccount>()
                .Include(x => x.SavingsAmountInformations)
                .Include(x => x.WithdrawAmountInformations)
                .Where(x => x.FcvId == fcvVcfId)
                .ToListAsync();

            //Savings
            var totalSavingsAmountByFcvVcf = savingsAmount
                .Select(x => x.SavingsAmountInformations?
                .Sum(x => x.SavingsAmount))
                .Sum();

            //Withdraw
            var totalWithdrawAmountByFcvVcf = savingsAmount
                .Select(x => x.WithdrawAmountInformations?
                .Sum(x => x.WithdrawAmount))
                .Sum();

            var totalInternalLoanAmount = await _readOnlyCtx.Set<InternalLoanInformation>()
                .Where(x => x.ForestFcvVcfId == fcvVcfId)
                .ToListAsync();

            var totalAllocatedLoanAmountByFcvVcf = totalInternalLoanAmount.Sum(x => x.TotalAllocatedLoanAmount);
            var differenceInternalLoanAmount = new InternalLoanAvailableAmountVM
            {
                TotalAccountBalance = totalSavingsAmountByFcvVcf,
                TotalLoanBalance = totalAllocatedLoanAmountByFcvVcf,
                TotalAvailableBalance = totalSavingsAmountByFcvVcf - totalWithdrawAmountByFcvVcf
            };

            return (executionState: ExecutionState.Retrieved, differenceInternalLoanAmount, "Successfully loaded data.");
        }

        public async Task<(ExecutionState executionState, PaginationResutl<InternalLoanInformation> entity, string message)> GetInternalLoanInformationByFilter(AIGBasicInformationFilterVM filter)
        {
            try
            {
                //IQueryable<InternalLoanInformation> query = _readOnlyCtx.Set<InternalLoanInformation>()
                //    .Where(x => x.IsActive && !x.IsDeleted)
                //    .OrderByDescending(x => x.Id);


                if (filter.sSearch != null)
                {
                    IQueryable<InternalLoanInformation> queryTotalSearch = _readOnlyCtx.Set<InternalLoanInformation>()
                   .OrderByDescending(x => x.Id);
                    IQueryable<InternalLoanInformation> querySearch = _readOnlyCtx.Set<InternalLoanInformation>()
                                      .Include(x=>x.Survey)
                                      .Where(x => x.IsActive && !x.IsDeleted)
                                      .OrderByDescending(x => x.Id);

                    querySearch = querySearch.Where(x => x.Survey.BeneficiaryName.Contains(filter.sSearch) || x.Survey.BeneficiaryPhone.Contains(filter.sSearch) || x.Survey.BeneficiaryNid.Contains(filter.sSearch));
                    var resultSearch = await querySearch.ToListAsync();
                    return (ExecutionState.Retrieved, new PaginationResutl<InternalLoanInformation>
                    {
                        aaData = resultSearch,
                        iTotalDisplayRecords = await queryTotalSearch.CountAsync(),
                        iTotalRecords = await queryTotalSearch.CountAsync(),
                    }, "Data returned successfully.");
                }


                IQueryable<InternalLoanInformation> query;
                if (filter.iDisplayStart != null || filter.iDisplayLength != null)
                {
                    query = _readOnlyCtx.Set<InternalLoanInformation>()
                                      .Include(x=>x.Survey)
                                      .OrderByDescending(x => x.Id)
                                      .Skip(filter.iDisplayStart ?? 0)
                                      .Take(filter.iDisplayLength ?? 0);
                }
                else
                {
                    query = _readOnlyCtx.Set<InternalLoanInformation>()
                                       .Include(x => x.Survey)
                                       .OrderByDescending(x => x.Id);
                }
                IQueryable<InternalLoanInformation> queryTotal = _readOnlyCtx.Set<InternalLoanInformation>()
                     .Include(x => x.Survey)
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
                if (filter?.Gender != null && filter.Gender.HasValue)
                {
                    query = query.Where(x => x.Survey!.BeneficiaryGender == filter.Gender);
                }
                if (filter?.PhoneNumber != null)
                {
                    query = query.Where(x => x.Survey!.BeneficiaryPhone == filter.PhoneNumber);
                }
                if (filter?.NID != null)
                {
                    query = query.Where(x => x.Survey!.BeneficiaryNid == filter.NID);
                }
                if (filter?.NgoId != null && filter?.NgoId > 0)
                {
                    query = query.Where(x => x.NgoId == filter.NgoId);
                }

                if (filter?.HasTake == true)
                {
                    query = query.Take(filter.Take ?? Defaults.Take);
                }

                query = query
                    .Include(x => x.Ngo!)
                    .Include(x => x.Survey!);

                var result = await query.ToListAsync();


                return (ExecutionState.Retrieved, new PaginationResutl<InternalLoanInformation>
                {
                    aaData = result,
                    iTotalDisplayRecords = await queryTotal.CountAsync(),
                    iTotalRecords = await queryTotal.CountAsync(),
                }, "Data returned successfully.");


                //return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Failure, new PaginationResutl<InternalLoanInformation>()!, "Unexpected error occurred.");
            }
        }

        public override Task<(ExecutionState executionState, InternalLoanInformation entity, string message)> GetAsync(long key)
        {
            var filterOptions = new FilterOptions<InternalLoanInformation>
            {
                IncludeExpression = x => x
                    .Include(x => x.RepaymentInternalLoans!)
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
                    .Include(x => x.Survey!)
                    .Include(x => x.InternalLoanInformationFiles!),
                FilterExpression = e => e.Id == key
            };

            return base.GetAsync(filterOptions);
        }

        public override async Task<(ExecutionState executionState, InternalLoanInformation entity, string message)> CreateAsync(InternalLoanInformation entity)
        {
            try
            {
                int countMonth = 1;
                var repayments = new List<RepaymentInternalLoan>();

                for (int i = 1; i <= entity.MaximumRepaymentMonth; i++)
                {
                    repayments.Add(new RepaymentInternalLoan
                    {
                        RepaymentAmount = Convert.ToDecimal(entity.TotalAllocatedLoanAmount / entity.MaximumRepaymentMonth),
                        RepaymentStartDate = entity.StartDate,
                        RepaymentEndDate =  entity.StartDate.AddMonths(1),
                        InternalLoanInformationId = entity.Id,
                        RepaymentSerial = i,
                        UpdatedAt = DateTime.Now,
                        IsPaymentCompleted = false,
                    });
                    countMonth++;

                    //entity.StartDate.AddMonths(-1);
                    //entity.StartDate = entity.StartDate.AddMonths(1);
                }
                entity.RepaymentInternalLoans?.AddRange(repayments);

                await _writeOnlyCtx.Set<InternalLoanInformation>().AddRangeAsync(entity);
                await _writeOnlyCtx.SaveChangesAsync();

                return (executionState: ExecutionState.Created, entity!, "Created successfully.");
            }
            catch (Exception)
            {
                return (executionState: ExecutionState.Failure, entity!, "Unexpected error occurred.");
            }
        }
    }
}