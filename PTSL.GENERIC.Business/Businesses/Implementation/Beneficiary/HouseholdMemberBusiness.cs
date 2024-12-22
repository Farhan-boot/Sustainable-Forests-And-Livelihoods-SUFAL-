using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.Beneficiary;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.DashBoard;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Implementation.Beneficiary
{
    public class HouseholdMemberBusiness : BaseBusiness<HouseholdMember>, IHouseholdMemberBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        private readonly GENERICReadOnlyCtx _context;
        public HouseholdMemberBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx context)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public override Task<(ExecutionState executionState, IQueryable<HouseholdMember> entity, string message)> List(QueryOptions<HouseholdMember> queryOptions = null)
        {
            queryOptions = new QueryOptions<HouseholdMember>
            {
                SortingExpression = x => x.OrderByDescending(y => y.Id)
            };

            return base.List(queryOptions);
        }

        public async Task<(ExecutionState executionState, DashboardHouseholdVM entity, string message)> TotalHouseholdWithPercentage(ForestCivilLocationFilter filter)
        {
            var houseUseContext = _context.Set<Survey>();
            var houseTypeContext = _context.Set<Survey>();

            var houseTypes = EnumHelper.GetEnumDropdowns<HouseType>().ToList();
            var houseUseCounts = houseTypeContext
                .WhereIf(filter.HasForestCircleId, x => x.ForestCircleId == filter.ForestCircleId)
                .WhereIf(filter.HasForestDivisionId, x => x.ForestDivisionId == filter.ForestDivisionId)
                .WhereIf(filter.HasForestRangeId, x => x.ForestRangeId == filter.ForestRangeId)
                .WhereIf(filter.HasForestBeatId, x => x.ForestBeatId == filter.ForestBeatId)
                .WhereIf(filter.HasForestFcvVcfId, x => x.ForestFcvVcfId == filter.ForestFcvVcfId)
                .WhereIf(filter.HasDistrictId, x => x.PresentDistrictId == filter.DistrictId)
                .WhereIf(filter.HasDivisionId, x => x.PresentDivisionId == filter.DivisionId)
                .WhereIf(filter.HasUpazillaId, x => x.PresentUpazillaId == filter.UpazillaId)
                .GroupBy(x => x.BeneficiaryHouseType)
                .Select(x => new { BeneficiaryHouseType = x.Key, HouseUseCounts = x.Count() });
            var totalHouseHoldMember = await _context.Set<HouseholdMember>()
                .WhereIf(filter.HasForestCircleId, x => x.Survey!.ForestCircleId == filter.ForestCircleId)
                .WhereIf(filter.HasForestDivisionId, x => x.Survey!.ForestDivisionId == filter.ForestDivisionId)
                .WhereIf(filter.HasForestRangeId, x => x.Survey!.ForestRangeId == filter.ForestRangeId)
                .WhereIf(filter.HasForestBeatId, x => x.Survey!.ForestBeatId == filter.ForestBeatId)
                .WhereIf(filter.HasForestFcvVcfId, x => x.Survey!.ForestFcvVcfId == filter.ForestFcvVcfId)
                .WhereIf(filter.HasDistrictId, x => x.Survey!.PresentDistrictId == filter.DistrictId)
                .WhereIf(filter.HasDivisionId, x => x.Survey!.PresentDivisionId == filter.DivisionId)
                .WhereIf(filter.HasUpazillaId, x => x.Survey!.PresentUpazillaId == filter.UpazillaId)
                .CountAsync(x => x.IsDeleted == false && x.IsActive);
            var total = houseUseCounts.Sum(x => x.HouseUseCounts);
            var result = new DashboardHouseholdVM
            {
                TotalHouseholdMember = totalHouseHoldMember,
            };

            foreach (var item in houseUseCounts)
            {
                double percentage = (double)(item.HouseUseCounts * 100) / total;

                result.HouseConditionPercentages.Add(new HouseConditionPercentage()
                {
                    HouseType = item.BeneficiaryHouseType,
                    Percentage = Math.Round(percentage, 2),
                    HouseTypeName = houseTypes.Find(x => x.Id == (int)item.BeneficiaryHouseType)?.Name ?? string.Empty,
                });
            }

            if (result.HouseConditionPercentages.Count == 0)
            {
                foreach (var item in houseTypes)
                {
                    result.HouseConditionPercentages.Add(new HouseConditionPercentage()
                    {
                        Percentage = 0,
                        HouseTypeName = item.Name,
                    });
                }
            }
            else
            {
                if (result.HouseConditionPercentages.Count > 0 && result.HouseConditionPercentages.Count != houseTypes.Count)
                {
                    var percentages = result.HouseConditionPercentages.Select(x => (int)x.HouseType);
                    var remainingTypes = houseTypes.Where(x => percentages.Contains(x.Id) == false).ToList();

                    foreach (var item in remainingTypes)
                    {
                        result.HouseConditionPercentages.Add(new HouseConditionPercentage()
                        {
                            Percentage = 0,
                            HouseTypeName = item.Name,
                        });
                    }
                }
            }

            result.HouseConditionPercentages = result.HouseConditionPercentages.OrderByDescending(x => x.Percentage).ToList();

            return (ExecutionState.Retrieved, result, "Successfully retrieved data.");
        }


        public async Task<(ExecutionState executionState, TotalHouseholdMemberVM entity, string message)> GetTotalHouseholdMember()
        {
            var countOptionsTotalHouseholdMember = new CountOptions<HouseholdMember>
            {
            };
            var resultTotalHouseholdMember = await _unitOfWork.HouseholdMemberRepo.CountAsync(countOptionsTotalHouseholdMember);

            TotalHouseholdMemberVM totalHouseholdMemberVM = new TotalHouseholdMemberVM();
            totalHouseholdMemberVM.TotalHouseholdMember = resultTotalHouseholdMember.entityCount;

            return (executionState: ExecutionState.Success, entity: totalHouseholdMemberVM, message: "Success");
        }
    }
}
