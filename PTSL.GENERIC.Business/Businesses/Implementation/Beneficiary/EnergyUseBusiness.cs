using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Enum;
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
    public class EnergyUseBusiness : BaseBusiness<EnergyUse>, IEnergyUseBusiness
    {
        private readonly GENERICReadOnlyCtx _context;

        public EnergyUseBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx context)
            : base(unitOfWork)
        {
            _context = context;
        }

        public override Task<(ExecutionState executionState, IQueryable<EnergyUse> entity, string message)> List(QueryOptions<EnergyUse> queryOptions = null)
        {
            queryOptions = new QueryOptions<EnergyUse>
            {
                SortingExpression = x => x.OrderByDescending(y => y.Id)
            };

            return base.List(queryOptions);
        }

        public async Task<(ExecutionState executionState, IList<EnergyUsesPercentageVM> entity, string message)> GetEnergyUsesPercentage(ForestCivilLocationFilter filter)
        {
            var energyUseContext = _context.Set<EnergyUse>();
            var energyTypeContext = _context.Set<EnergyType>();

            var energyTypes = await energyTypeContext.ToListAsync();
            var energyUseCounts = energyUseContext
                .WhereIf(filter.HasForestCircleId, x => x.Survey!.ForestCircleId == filter.ForestCircleId)
                .WhereIf(filter.HasForestDivisionId, x => x.Survey!.ForestDivisionId == filter.ForestDivisionId)
                .WhereIf(filter.HasForestRangeId, x => x.Survey!.ForestRangeId == filter.ForestRangeId)
                .WhereIf(filter.HasForestBeatId, x => x.Survey!.ForestBeatId == filter.ForestBeatId)
                .WhereIf(filter.HasForestFcvVcfId, x => x.Survey!.ForestFcvVcfId == filter.ForestFcvVcfId)
                .WhereIf(filter.HasDistrictId, x => x.Survey!.PresentDistrictId == filter.DistrictId)
                .WhereIf(filter.HasDivisionId, x => x.Survey!.PresentDivisionId == filter.DivisionId)
                .WhereIf(filter.HasUpazillaId, x => x.Survey!.PresentUpazillaId == filter.UpazillaId)
                .GroupBy(x => x.EnergyTypeId)
                .Select(x => new { EnergyTypeId = x.Key, EnergyTypeCount = x.Count() });
            var total = energyUseCounts.Sum(x => x.EnergyTypeCount);
            var result = new List<EnergyUsesPercentageVM>();

            if (energyUseCounts.Count() == 0)
            {
                foreach (var item in energyTypes)
                {
                    result.Add(new EnergyUsesPercentageVM()
                    {
                        EnergyTypeId = item.Id,
                        Percentage = 0,
                        EnergyTypeName = item.Name,
                    });
                }
            }
            else
            {
                foreach (var item in energyUseCounts)
                {
                    double percentage = (double)(item.EnergyTypeCount * 100) / total;

                    result.Add(new EnergyUsesPercentageVM()
                    {
                        EnergyTypeId = item.EnergyTypeId,
                        Percentage = Math.Round(percentage, 2),
                        EnergyTypeName = energyTypes.Find(x => x.Id == item.EnergyTypeId)?.Name,
                    });
                }
            }

            return (ExecutionState.Retrieved, result, "Successfully retrieved data.");
        }
    }
}
