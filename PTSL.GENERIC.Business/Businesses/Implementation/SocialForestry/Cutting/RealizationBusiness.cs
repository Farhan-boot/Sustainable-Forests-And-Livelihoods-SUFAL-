using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.SocialForestry.Cutting
{
    public class RealizationBusiness : BaseBusiness<Realization>, IRealizationBusiness
    {
        private readonly GENERICReadOnlyCtx _readOnlyCtx;

        public RealizationBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyCtx)
            : base(unitOfWork)
        {
            _readOnlyCtx = readOnlyCtx;
        }

        public override Task<(ExecutionState executionState, IQueryable<Realization> entity, string message)> List(QueryOptions<Realization> queryOptions = null)
        {
            return base.List(new QueryOptions<Realization>
            {
                IncludeExpression = e => e.Include(x => x.LotWiseSellingInformation!)
            });
        }

        public async Task<(ExecutionState executionState, DefaultRealizationDataVM data, string message)> GetDefaultRealizationData(long cuttingPlantationId)
        {
            var cuttingInfo = await _readOnlyCtx.Set<CuttingPlantation>()
                .Where(x => x.Id == cuttingPlantationId)
                .Include(x => x.NewRaisedPlantation)
                .Include(x => x.LotWiseSellingInformation!)
                .Include(x => x.Realizations!)
                .Select(x => new { x.NewRaisedPlantation!.PlantationId, x.TotalNumberOfLots, x.Realizations, x.LotWiseSellingInformation })
                .AsSplitQuery()
                .FirstOrDefaultAsync();
            if (cuttingInfo is null)
            {
                return (ExecutionState.Failure, null!, "Felling information not found");
            }

            var totalRealizedAmount = cuttingInfo.Realizations?.Sum(x => x.TotalSaleValue) ?? 0;
            var totalLotAmount = cuttingInfo.LotWiseSellingInformation?.Sum(x => x.TotalSaleValue) ?? 0;
            var totalNumberOfLots = cuttingInfo.TotalNumberOfLots;
            var numberOfSoldLots = cuttingInfo.LotWiseSellingInformation?.Count ?? 0;

            var result = new DefaultRealizationDataVM
            {
                PlantationId = cuttingInfo.PlantationId,
                TotalRealizedAmount = totalRealizedAmount,
                TotalUnrealizedAmount = totalLotAmount - totalRealizedAmount,
                TotalNumberOfLots = totalNumberOfLots,
                NumberOfSoldLots = numberOfSoldLots,
                RemainingNumberOfLots = totalNumberOfLots - numberOfSoldLots,
            };
            var resultData = await _readOnlyCtx.Set<Realization>()
                .Where(x => x.CuttingPlantationId == cuttingPlantationId)
                .Include(x => x.LotWiseSellingInformation)
                .ToListAsync();
            result.RealizationEntities = resultData;

            return (ExecutionState.Success, result, "Success");
        }

        public async Task<(ExecutionState executionState, List<Realization> data, string message)> GetRealizationsByCuttingId(long id)
        {
            var list = await _readOnlyCtx.Set<Realization>()
                .Where(x => x.CuttingPlantationId == id)
                .Include(x => x.LotWiseSellingInformation)
                .ToListAsync();

            return (ExecutionState.Success, list, "Success");
        }

        public override async Task<(ExecutionState executionState, Realization entity, string message)> CreateAsync(Realization entity)
        {
            var alreadyAddedCount = await _readOnlyCtx.Set<Realization>()
                .Where(x => x.LotWiseSellingInformationId == entity.LotWiseSellingInformationId)
                .CountAsync();
            if (alreadyAddedCount > 0)
            {
                return (ExecutionState.Failure, null!, "This lot realization information is already added");
            }

            var lotWiseSelling = await _readOnlyCtx.Set<LotWiseSellingInformation>()
                .Where(x => x.Id == entity.LotWiseSellingInformationId)
                .FirstOrDefaultAsync();
            if (lotWiseSelling is null)
            {
                return (ExecutionState.Failure, null!, "Lot not found");
            }

            entity.SaleValueOfLot = lotWiseSelling.SaleValueOfLot;
            entity.SaleValueOfVatPercentage = lotWiseSelling.SaleValueOfVatPercentage;
            entity.SaleValueOfTaxPercentage = lotWiseSelling.SaleValueOfTaxPercentage;
            entity.TotalSaleValue = lotWiseSelling.TotalSaleValue;

            return await base.CreateAsync(entity);
        }


        public override Task<(ExecutionState executionState, Realization entity, string message)> GetAsync(long id)
        {
            var filterOptions = new FilterOptions<Realization>
            {
                IncludeExpression = x => x
                    .Include(x => x.LotWiseSellingInformation!),
                FilterExpression = e => e.Id == id
            };
            return base.GetAsync(filterOptions);
        }







    }
}