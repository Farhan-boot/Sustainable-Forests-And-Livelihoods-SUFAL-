using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Business.Businesses.Implementation.SocialForestry.Cutting
{
    public class CuttingPlantationBusiness : BaseBusiness<CuttingPlantation>, ICuttingPlantationBusiness
    {
        private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

        public CuttingPlantationBusiness(GENERICUnitOfWork unitOfWork, GENERICWriteOnlyCtx writeOnlyCtx)
            : base(unitOfWork)
        {
            _writeOnlyCtx = writeOnlyCtx;
        }

        public override Task<(ExecutionState executionState, IQueryable<CuttingPlantation> entity, string message)> List(QueryOptions<CuttingPlantation> queryOptions = null)
        {
            return base.List(new QueryOptions<CuttingPlantation>
            {
                IncludeExpression = e => e.Include(x => x.NewRaisedPlantation!)
                .ThenInclude(x=>x.PlantationType!)
                .Include(x=>x.NewRaisedPlantation!)
                .ThenInclude(x=>x.ProjectType!)
                .Include(x => x.LotWiseSellingInformation!),
                SortingExpression = e => e.OrderByDescending(x => x.Id)
            });
        }

        public async Task<(ExecutionState executionState, IQueryable<CuttingPlantation> entity, string message)> ListByNewRaised(long newRaisedId)
        {
            return await base.List(new QueryOptions<CuttingPlantation>
            {
                FilterExpression = e => e.NewRaisedPlantationId == newRaisedId,
                IncludeExpression = e => e.Include(x => x.NewRaisedPlantation!),
                SortingExpression = e => e.OrderByDescending(x => x.Id)
            });
        }

        public override async Task<(ExecutionState executionState, CuttingPlantation entity, string message)> GetAsync(long key)
        {
            var cutting = await _writeOnlyCtx.Set<CuttingPlantation>()
                .Include(x=>x.NewRaisedPlantation!)
                .ThenInclude(x=>x.ForestCircle!)
                .ThenInclude(x=>x.ForestDivisions!)
                .ThenInclude(x=>x.ForestRanges!)
                .ThenInclude(x=>x.ForestBeats!)
                .Include(x => x.NewRaisedPlantation!)
                .ThenInclude(x=>x.ZoneOrArea)
                .Include(x => x.NewRaisedPlantation!)
                .ThenInclude(x=>x.Union!)
                .ThenInclude(x=>x.Upazilla)
                .ThenInclude(x => x.District)
                .ThenInclude(x => x.Division)
               .Include(x => x.NewRaisedPlantation!)
               .ThenInclude(x=>x.SocialForestryNgo)


                .Where(x => x.Id == key)
                .Include(x => x.MarkedTimberUnit!)
                .Include(x => x.MarkedPoleUnit!)
                .Include(x => x.MarkedFuelWoodUnit!)

                .Include(x => x.ProducedTimberUnit!)
                .Include(x => x.ProducedPoleUnit!)
                .Include(x => x.ProducedFuelWoodUnit!)

                .Include(x => x.LotWiseSellingInformation!)
                .ThenInclude(x => x.LotWiseFuelWoodUnit)
                .Include(x => x.LotWiseSellingInformation!)
                .ThenInclude(x => x.LotWisePoleUnit)
                .Include(x => x.LotWiseSellingInformation!)
                .ThenInclude(x => x.LotWiseTimberUnit)
                .Include(x => x.FinancialYear!)

                .AsSplitQuery()
                .FirstOrDefaultAsync();

            return (ExecutionState.Retrieved, cutting!, "Ok");
        }

        public override async Task<(ExecutionState executionState, CuttingPlantation entity, string message)> CreateAsync(CuttingPlantation entity)
        {
            try
            {
                using var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();

                var newRaisedPlantation = await _writeOnlyCtx.Set<NewRaisedPlantation>()
                    .FirstOrDefaultAsync(x => x.Id == entity.NewRaisedPlantationId);
                if (newRaisedPlantation is null)
                {
                    return (ExecutionState.Failure, null!, "Invalid new raised plantation");
                }

                entity.RotationNo = newRaisedPlantation.CurrentRotationNo;

                _writeOnlyCtx.Set<CuttingPlantation>().Add(entity);
                await _writeOnlyCtx.SaveChangesAsync();
                await transaction.CommitAsync();

                return (ExecutionState.Created, entity, "Created");
            }
            catch
            {
                return (ExecutionState.Failure, null!, "Unexpected error occurred");
            }
        }


        //New add filter
        public async Task<(ExecutionState executionState, List<CuttingPlantation> entity, string message)> ListByFilter(NewRaisedPlantationFilter filter)
        {
            try
            {
                IQueryable<CuttingPlantation> query = _writeOnlyCtx.Set<CuttingPlantation>()
                    .Include(x=>x.NewRaisedPlantation)
                    .OrderByDescending(x => x.Id);

                // Forest Administration
                query = query.WhereIf(filter.HasForestCircleId, x => x.NewRaisedPlantation.ForestCircleId == filter.ForestCircleId);
                query = query.WhereIf(filter.HasForestDivisionId, x => x.NewRaisedPlantation.ForestDivisionId == filter.ForestDivisionId);
                query = query.WhereIf(filter.HasForestRangeId, x => x.NewRaisedPlantation.ForestRangeId == filter.ForestRangeId);
                query = query.WhereIf(filter.HasForestBeatId, x => x.NewRaisedPlantation.ForestBeatId == filter.ForestBeatId);
                query = query.WhereIf(filter.HasZoneOrAreaId, x => x.NewRaisedPlantation.ZoneOrAreaId == filter.ZoneOrAreaId);

                // Civil Administration
                query = query.WhereIf(filter.HasDivisionId, x => x.NewRaisedPlantation.DivisionId == filter.DivisionId);
                query = query.WhereIf(filter.HasDistrictId, x => x.NewRaisedPlantation.DistrictId == filter.DistrictId);
                query = query.WhereIf(filter.HasUpazillaId, x => x.NewRaisedPlantation.UpazillaId == filter.UpazillaId);
                query = query.WhereIf(filter.HasUnionId, x => x.NewRaisedPlantation.UnionId == filter.UnionId);

                // Includes
                query = query
                    .Include(x => x.NewRaisedPlantation!)
                    .Include(x=>x.LotWiseSellingInformation)
                    .Include(x => x.NewRaisedPlantation.ForestCircle!)
                    .Include(x => x.NewRaisedPlantation.ForestDivision!)
                    .Include(x => x.NewRaisedPlantation.ForestRange!)
                    .Include(x => x.NewRaisedPlantation.ForestBeat!)
                    .Include(x => x.NewRaisedPlantation.ZoneOrArea!)
                    .Include(x => x.NewRaisedPlantation.Division!)
                    .Include(x => x.NewRaisedPlantation.District!)
                    .Include(x => x.NewRaisedPlantation.Upazilla!)
                    .Include(x => x.NewRaisedPlantation.Union!)
                    .Include(x => x.NewRaisedPlantation.PlantationType!)
                    .Include(x => x.NewRaisedPlantation.ProjectType!);

                var result = await query
                    .AsSplitQuery()
                    .ToListAsync();

                return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception)
            {
                return (ExecutionState.Failure, new List<CuttingPlantation>()!, "Unexpected error occurred.");
            }
        }



    }
}
