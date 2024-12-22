using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Model.EntityViewModels.DashBoard;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.BeneficiarySavingsAccount
{
    public class SavingsAccountBusiness : BaseBusiness<SavingsAccount>, ISavingsAccountBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        private readonly GENERICReadOnlyCtx _readOnlyCtx;

        public SavingsAccountBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyCtx)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _readOnlyCtx = readOnlyCtx;
        }

        public override Task<(ExecutionState executionState, IQueryable<SavingsAccount> entity, string message)> List(QueryOptions<SavingsAccount> queryOptions = null)
        {
            var savingsAccount = new QueryOptions<SavingsAccount>
            {
                IncludeExpression = x => x
                    .Include(s => s.SavingsAmountInformations)
                    .Include(w => w.WithdrawAmountInformations)
                    .Include(y => y.Ngos)
                    .Include(x => x.Survey!),
                SortingExpression = s => s.OrderByDescending(x => x.Id)
            };

            return base.List(savingsAccount);
        }

        public override Task<(ExecutionState executionState, SavingsAccount entity, string message)> GetAsync(long key)
        {

            var filterOptions = new FilterOptions<SavingsAccount>
            {
                IncludeExpression = x => x
                .Include(x => x.ForestCircle)
                .Include(x => x.ForestDivision)
                .Include(x => x.ForestRange)
                .Include(x => x.ForestBeat)
                .Include(x => x.Division)
                .Include(x => x.District)
                .Include(x => x.Upazilla)
                .Include(x => x.Union)
                .Include(x => x.Ngos)
                .Include(x => x.Survey)
                .Include(x => x.SavingsAmountInformations)
                .Include(x => x.WithdrawAmountInformations!),
                FilterExpression = e => e.Id == key
            };

            return base.GetAsync(filterOptions);
        }

        public async Task<(ExecutionState executionState, PaginationResutl<SavingsAccount> entity, string message)> GetByFilter(SavingsAccountFilterVM filterData)
        {
            //var query = _readOnlyCtx.Set<SavingsAccount>()
            //    .Where(x => x.IsActive && !x.IsDeleted).Include(x=>x.Survey).ThenInclude(x=>x.ForestCircle)
            //    .Include(x => x.Survey).ThenInclude(x=>x.ForestDivision)
            //    .Include(x => x.Survey).ThenInclude(x=>x.ForestBeat)
            //    .Include(x => x.Survey).ThenInclude(x=>x.ForestRange)
            //    .Include(x => x.Survey).ThenInclude(x=>x.ForestFcvVcf)
            //    .OrderByDescending(x => x.Id)
            //    .AsQueryable();

            if (filterData.sSearch != null)
            {
                IQueryable<SavingsAccount> queryTotalSearch = _readOnlyCtx.Set<SavingsAccount>()
               .OrderByDescending(x => x.Id);
                IQueryable<SavingsAccount> querySearch = _readOnlyCtx.Set<SavingsAccount>()
                                .Where(x => x.IsActive && !x.IsDeleted).Include(x => x.Survey).ThenInclude(x => x.ForestCircle)
                                .Include(x => x.Survey).ThenInclude(x => x.ForestDivision)
                                .Include(x => x.Survey).ThenInclude(x => x.ForestBeat)
                                .Include(x => x.Survey).ThenInclude(x => x.ForestRange)
                                .Include(x => x.Survey).ThenInclude(x => x.ForestFcvVcf)
                                .OrderByDescending(x => x.Id);

                querySearch = querySearch.Where(x => x.Survey.BeneficiaryName.Contains(filterData.sSearch) || x.Survey.BeneficiaryNid.Contains(filterData.sSearch) || x.Ngos.Name.Contains(filterData.sSearch));
                var resultSearch = await querySearch.ToListAsync();
                return (ExecutionState.Retrieved, new PaginationResutl<SavingsAccount>
                {
                    aaData = resultSearch,
                    iTotalDisplayRecords = await queryTotalSearch.CountAsync(),
                    iTotalRecords = await queryTotalSearch.CountAsync(),
                }, "Data returned successfully.");
            }


            IQueryable<SavingsAccount> query;
            if (filterData.iDisplayStart != null || filterData.iDisplayLength != null)
            {
                query = _readOnlyCtx.Set<SavingsAccount>()
                                .Where(x => x.IsActive && !x.IsDeleted).Include(x => x.Survey).ThenInclude(x => x.ForestCircle)
                                .Include(x => x.Survey).ThenInclude(x => x.ForestDivision)
                                .Include(x => x.Survey).ThenInclude(x => x.ForestBeat)
                                .Include(x => x.Survey).ThenInclude(x => x.ForestRange)
                                .Include(x => x.Survey).ThenInclude(x => x.ForestFcvVcf)
                                .OrderByDescending(x => x.Id)
                                .Skip(filterData.iDisplayStart ?? 0)
                                .Take(filterData.iDisplayLength ?? 0);
            }
            else
            {
                query = _readOnlyCtx.Set<SavingsAccount>()
                .Where(x => x.IsActive && !x.IsDeleted).Include(x => x.Survey).ThenInclude(x => x.ForestCircle)
                .Include(x => x.Survey).ThenInclude(x => x.ForestDivision)
                .Include(x => x.Survey).ThenInclude(x => x.ForestBeat)
                .Include(x => x.Survey).ThenInclude(x => x.ForestRange)
                .Include(x => x.Survey).ThenInclude(x => x.ForestFcvVcf)
                .OrderByDescending(x => x.Id);
            }
            IQueryable<SavingsAccount> queryTotal = _readOnlyCtx.Set<SavingsAccount>()
           .OrderByDescending(x => x.Id);




            // Forest Administration
            if (filterData?.ForestCircleId != null && filterData?.ForestCircleId > 0)
            {
                query = query.Where(x => x.ForestCircleId == filterData.ForestCircleId);
            }
            if (filterData?.ForestDivisionId != null && filterData?.ForestDivisionId > 0)
            {
                query = query.Where(x => x.ForestDivisionId == filterData.ForestDivisionId);
            }
            if (filterData?.ForestRangeId != null && filterData?.ForestRangeId > 0)
            {
                query = query.Where(x => x.ForestRangeId == filterData.ForestRangeId);
            }
            if (filterData?.ForestBeatId != null && filterData?.ForestBeatId > 0)
            {
                query = query.Where(x => x.ForestBeatId == filterData.ForestBeatId);
            }
            if (filterData?.ForestFcvVcfId != null && filterData?.ForestFcvVcfId > 0)
            {
                query = query.Where(x => x.FcvId == filterData.ForestFcvVcfId);
            }

            // Civil Administration
            if (filterData?.DivisionId != null && filterData?.DivisionId > 0)
            {
                query = query.Where(x => x.DivisionId == filterData.DivisionId);
            }
            if (filterData?.DistrictId != null && filterData?.DistrictId > 0)
            {
                query = query.Where(x => x.DistrictId == filterData.DistrictId);
            }
            if (filterData?.UpazillaId != null && filterData?.UpazillaId > 0)
            {
                query = query.Where(x => x.UpazillaId == filterData.UpazillaId);
            }


            //Extra Filter

            if (filterData?.Gender != null)
            {
                query = query.Where(x => x.Survey!.BeneficiaryGender == filterData.Gender);
            }

            if (filterData?.PhoneNumber != null)
            {
                query = query.Where(x => x.Survey!.BeneficiaryPhone == filterData.PhoneNumber);
            }

            if (filterData?.NID != null)
            {
                query = query.Where(x => x.Survey!.BeneficiaryNid == filterData.NID);
            }

            if (filterData?.NgoId > 0)
            {
                query = query.Where(x => x.NgoId == filterData.NgoId);
            }

            if (filterData?.HasTake == true)
            {
                query = query.Take(filterData.Take ?? Defaults.Take);
            }

            query = query
                    .OrderByDescending(x => x.Id)
                    .Include(x => x.Ngos)
                    .Include(x => x.Survey)
                    .Include(x => x.SavingsAmountInformations)
                    .Include(x => x.WithdrawAmountInformations!);

            var result = await query.ToListAsync();

            return (ExecutionState.Retrieved, new PaginationResutl<SavingsAccount>
            {
                aaData = result,
                iTotalDisplayRecords = await queryTotal.CountAsync(),
                iTotalRecords = await queryTotal.CountAsync(),
            }, "Data returned successfully.");

           //return (ExecutionState.Retrieved, result, "Data returned successfully.");
        }

        public async Task<(ExecutionState executionState, DashboardSavingsAmountVM entity, string message)> TotalDashboardSavingsAmount(ForestCivilLocationFilter filter)
        {
            var savingsAccountUseContext = _readOnlyCtx.Set<SavingsAccount>().Include(x=>x.SavingsAmountInformations);
            var savingsAccountUseCounts = await savingsAccountUseContext
                .WhereIf(filter.HasForestCircleId, x => x.ForestCircleId == filter.ForestCircleId)
                .WhereIf(filter.HasForestDivisionId, x => x.ForestDivisionId == filter.ForestDivisionId)
                .WhereIf(filter.HasForestRangeId, x => x.ForestRangeId == filter.ForestRangeId)
                .WhereIf(filter.HasForestBeatId, x => x.ForestBeatId == filter.ForestBeatId)
                .WhereIf(filter.HasForestFcvVcfId, x => x.FcvId == filter.ForestFcvVcfId)
                .WhereIf(filter.HasDistrictId, x => x.DistrictId == filter.DistrictId)
                .WhereIf(filter.HasDivisionId, x => x.DivisionId == filter.DivisionId)
                .WhereIf(filter.HasUpazillaId, x => x.UpazillaId == filter.UpazillaId)
                .Select(x => x.SavingsAmountInformations!.Select(x => x.SavingsAmount)).ToListAsync();
              
            if (savingsAccountUseCounts.Count == 0)
            {
                var resultEmpty = new DashboardSavingsAmountVM
                {
                    TotalSavingsAmount = 0,
                };

                return (ExecutionState.Retrieved, resultEmpty, "Successfully retrieved data.");
            }

            var result = new DashboardSavingsAmountVM
            {
                TotalSavingsAmount = savingsAccountUseCounts.SelectMany(x => x).Sum(),
            };

            return (ExecutionState.Retrieved, result, "Successfully retrieved data.");
        }
    }
}
