using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Humanizer;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Business.Businesses.Implementation.SocialForestry
{
    public class NewRaisedPlantationBusiness : BaseBusiness<NewRaisedPlantation>, INewRaisedPlantationBusiness
    {
        private readonly GENERICUnitOfWork _unitOfWork;
        private readonly GENERICReadOnlyCtx _readOnlyCtx;
        private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

        public NewRaisedPlantationBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyCtx, GENERICWriteOnlyCtx writeOnlyCtx)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _readOnlyCtx = readOnlyCtx;
            _writeOnlyCtx = writeOnlyCtx;
        }

        public async Task<(ExecutionState executionState, List<NewRaisedPlantation> entity, string message)> ListByFilter(NewRaisedPlantationFilter filter)
        {
            try
            {
                IQueryable<NewRaisedPlantation> query = _readOnlyCtx.Set<NewRaisedPlantation>()
                    .OrderByDescending(x => x.Id);

                // Forest Administration
                query = query.WhereIf(filter.HasForestCircleId, x => x.ForestCircleId == filter.ForestCircleId);
                query = query.WhereIf(filter.HasForestDivisionId, x => x.ForestDivisionId == filter.ForestDivisionId);
                query = query.WhereIf(filter.HasForestRangeId, x => x.ForestRangeId == filter.ForestRangeId);
                query = query.WhereIf(filter.HasForestBeatId, x => x.ForestBeatId == filter.ForestBeatId);
                query = query.WhereIf(filter.HasZoneOrAreaId, x => x.ZoneOrAreaId == filter.ZoneOrAreaId);

                // Civil Administration
                query = query.WhereIf(filter.HasDivisionId, x => x.DivisionId == filter.DivisionId);
                query = query.WhereIf(filter.HasDistrictId, x => x.DistrictId == filter.DistrictId);
                query = query.WhereIf(filter.HasUpazillaId, x => x.UpazillaId == filter.UpazillaId);
                query = query.WhereIf(filter.HasUnionId, x => x.UnionId == filter.UnionId);

                // Includes
                query = query
                    .Include(x => x.PlantedFinancialYear!)
                    .Include(x => x.ProjectType!)
                    .Include(x => x.ForestCircle!)
                    .Include(x => x.ForestDivision!)
                    .Include(x => x.ForestRange!)
                    .Include(x => x.ForestBeat!)
                    .Include(x => x.ZoneOrArea!)
                    .Include(x => x.Division!)
                    .Include(x => x.District!)
                    .Include(x => x.Upazilla!)
                    .Include(x => x.Union!)
                    .Include(x => x.PlantationType!);

                var result = await query
                    .AsSplitQuery()
                    .ToListAsync();

                return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception)
            {
                return (ExecutionState.Failure, new List<NewRaisedPlantation>()!, "Unexpected error occurred.");
            }
        }

        public override Task<(ExecutionState executionState, IQueryable<NewRaisedPlantation> entity, string message)> List(QueryOptions<NewRaisedPlantation> queryOptions = null)
        {
            return base.List(new QueryOptions<NewRaisedPlantation>
            {
                IncludeExpression = e => e
                    .Include(x => x.PlantedFinancialYear!)
                    .Include(x => x.ProjectType!)
                    .Include(x => x.ForestCircle!)
                    .Include(x => x.ForestDivision!)
                    .Include(x => x.ForestRange!)
                    .Include(x => x.ForestBeat!)
                    .Include(x => x.ZoneOrArea!)
                    .Include(x => x.Division!)
                    .Include(x => x.District!)
                    .Include(x => x.Upazilla!)
                    .Include(x => x.Union!)
                    .Include(x => x.PlantationType!),
                SortingExpression = e => e.OrderByDescending(x => x.Id)
            });
        }

        public Task<(ExecutionState executionState, NewRaisedPlantation data, string message)> GetDetails(long id)
        {
            return _unitOfWork.NewRaisedPlantationRepository.GetDetails(id);
        }

        public Task<(ExecutionState executionState, NewRaisedPlantation data, string message)> GetDetailsForEdit(long id)
        {
            return _unitOfWork.NewRaisedPlantationRepository.GetDetailsForEdit(id);
        }

        public override async Task<(ExecutionState executionState, NewRaisedPlantation entity, string message)> CreateAsync(NewRaisedPlantation entity)
        {
            using var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();

            try
            {
                var uniqueIdCount = await _readOnlyCtx.Set<NewRaisedPlantation>().Where(x => x.PlantationId.ToLower() == entity.PlantationId.ToLower()).CountAsync();
                if (uniqueIdCount > 0)
                {
                    return (ExecutionState.Failure, null!, "Plantation Id is not unique");
                }

                var seedlingIds = entity.PlantationPlants?.Select(x => x.NurseryRaisedSeedlingInformationId).ToArray() ?? Enumerable.Empty<long>();
                var seedlings = await _writeOnlyCtx.Set<NurseryRaisedSeedlingInformation>().Where(x => seedlingIds.Contains(x.Id)).ToListAsync();

                foreach (var item in seedlings)
                {
                    var planted = entity.PlantationPlants
                        ?.Where(x => x.NurseryRaisedSeedlingInformationId == item.Id)
                        .Select(x => x.NumberOfSeedlingPlanted)
                        .FirstOrDefault() ?? 0;
                    item.SeedlingRaised -= planted;
                    if (item.SeedlingRaised < 0)
                    {
                        return (ExecutionState.Failure, null!, "Can not plant more than available");
                    }
                }

                foreach (var item in entity.PlantationSocialForestryBeneficiaryMaps ?? Enumerable.Empty<PlantationSocialForestryBeneficiaryMap>())
                {
                    if (item.SocialForestryBeneficiary is not null)
                    {
                        item.SocialForestryBeneficiaryId = item.SocialForestryBeneficiary.Id;
                        item.SocialForestryBeneficiary = null;
                    }
                }

                entity.CurrentRotationNo = entity.RotationNo;

                await _writeOnlyCtx.Set<NewRaisedPlantation>().AddAsync(entity);
                await _writeOnlyCtx.SaveChangesAsync();
                await transaction.CommitAsync();

                return (ExecutionState.Created, entity, "Created successfully");
            }
            catch
            {
                await transaction.RollbackAsync();

                return (ExecutionState.Failure, entity, "Unexpected error occurred");
            }
        }

        public async Task<(ExecutionState execution, string entity, string message)> GetNextRotationNo(long newRaisedPlantation)
        {
            var result = await _readOnlyCtx.Set<NewRaisedPlantation>()
                .Where(x => x.Id == newRaisedPlantation)
                .Select(x => x.CurrentRotationNo)
                .FirstOrDefaultAsync();
            result++;

            return (ExecutionState.Success, result.Ordinalize(), "Success");
        }


        public async Task<(ExecutionState executionState, IList<NewRaisedPlantation> entity, string message)> GetInformationAndDataOnNewlyRaisedPlantationReport(NurseryFilterVM model)
        {
            try
            {
                IQueryable<NewRaisedPlantation> query = _readOnlyCtx.Set<NewRaisedPlantation>()
                    .OrderByDescending(x => x.Id);

                // Forest Administration
                query = query.WhereIf(model.HasForestCircleId, x => x.ForestCircleId == model.ForestCircleId);
                query = query.WhereIf(model.HasForestDivisionId, x => x.ForestDivisionId == model.ForestDivisionId);
                query = query.WhereIf(model.HasForestRangeId, x => x.ForestRangeId == model.ForestRangeId);
                query = query.WhereIf(model.HasForestBeatId, x => x.ForestBeatId == model.ForestBeatId);

                // Civil Administration
                query = query.WhereIf(model.HasDivisionId, x => x.DivisionId == model.DivisionId);
                query = query.WhereIf(model.HasDistrictId, x => x.DistrictId == model.DistrictId);
                query = query.WhereIf(model.HasUpazillaId, x => x.UpazillaId == model.UpazillaId);
                query = query.WhereIf(model.HasUnionId, x => x.UnionId == model.UnionId);

                query = query.WhereIf(model.HasFinancialYearId, x => x.PlantedFinancialYearId == model.FinancialYearId);

                var result = await query.Include(a => a.ForestCircle!)
                                        .Include(a => a.ForestDivision!)
                                        .Include(a => a.ForestRange!)
                                        .Include(a => a.ForestBeat!)
                                        .Include(a => a.Division!)
                                        .Include(a => a.District!)
                                        .Include(a => a.Upazilla!)
                                        .Include(a => a.Union!)
                                        .Include(a => a.LandOwningAgency!)
                                        .Include(a => a.ProjectType!)
                                        .Include(a => a.PlantedFinancialYear!)
                                        .Include(a => a.CostInformation!)
                                        .Include(a => a.LaborInformation!)
                                        .ThenInclude(x=>x.LaborCostType!)
                                        .Include(a => a.PlantationPlants!)
                                        .Include(a => a.PlantationUnit!)
                                        .Include(a => a.PlantationSocialForestryBeneficiaryMaps!)
                                        .ThenInclude(x=>x.SocialForestryBeneficiary!)

                                        .AsSplitQuery()
                                        .ToListAsync();

                return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception)
            {
                return (ExecutionState.Failure, new List<NewRaisedPlantation>()!, "Unexpected error occurred.");
            }
        }




        public async Task<(ExecutionState executionState, IList<NewRaisedPlantation> entity, string message)> GetInformationAndDataOnPlantationsFelledOrCutReport(NurseryFilterVM model)
        {
            try
            {
                IQueryable<NewRaisedPlantation> query = _readOnlyCtx.Set<NewRaisedPlantation>()
                    .OrderByDescending(x => x.Id);

                // Forest Administration
                query = query.WhereIf(model.HasForestCircleId, x => x.ForestCircleId == model.ForestCircleId);
                query = query.WhereIf(model.HasForestDivisionId, x => x.ForestDivisionId == model.ForestDivisionId);
                query = query.WhereIf(model.HasForestRangeId, x => x.ForestRangeId == model.ForestRangeId);
                query = query.WhereIf(model.HasForestBeatId, x => x.ForestBeatId == model.ForestBeatId);

                // Civil Administration
                query = query.WhereIf(model.HasDivisionId, x => x.DivisionId == model.DivisionId);
                query = query.WhereIf(model.HasDistrictId, x => x.DistrictId == model.DistrictId);
                query = query.WhereIf(model.HasUpazillaId, x => x.UpazillaId == model.UpazillaId);
                query = query.WhereIf(model.HasUnionId, x => x.UnionId == model.UnionId);

                query = query.WhereIf(model.HasFinancialYearId, x => x.PlantedFinancialYearId == model.FinancialYearId);
                query = query.WhereIf(model.HasFinancialYearId, x => x.PlantationId.Contains(model.PlantationId));


                var result = await query.Include(a => a.ForestCircle!)
                                        .Include(a => a.ForestDivision!)
                                        .Include(a => a.ForestRange!)
                                        .Include(a => a.ForestBeat!)
                                        .Include(a => a.Division!)
                                        .Include(a => a.District!)
                                        .Include(a => a.Upazilla!)
                                        .Include(a => a.Union!)
                                        .Include(a => a.LandOwningAgency!)
                                        .Include(a => a.ProjectType!)
                                        .Include(a => a.PlantedFinancialYear!)
                                        .Include(a => a.CostInformation!)
                                        .Include(a => a.LaborInformation!)
                                        .ThenInclude(x => x.LaborCostType!)
                                        .Include(a => a.PlantationPlants!)
                                        .Include(a => a.PlantationUnit!)
                                        .Include(a => a.CuttingPlantations!)
                                        .ThenInclude(x=>x.MarkedTimberUnit!)
                                        .Include(a => a.CuttingPlantations!)
                                        .ThenInclude(x => x.MarkedPoleUnit!)
                                        .Include(a => a.CuttingPlantations!)
                                        .ThenInclude(x => x.MarkedFuelWoodUnit!)
                                        .Include(a => a.CuttingPlantations!)
                                        .ThenInclude(x => x.Realizations!)
                                        .Include(a => a.CuttingPlantations!)
                                        .ThenInclude(x => x.ShareDistributions!)



                                        .Include(a => a.PlantationSocialForestryBeneficiaryMaps!)
                                        .ThenInclude(x => x.SocialForestryBeneficiary!)


                                        .AsSplitQuery()
                                        .ToListAsync();

                return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception)
            {
                return (ExecutionState.Failure, new List<NewRaisedPlantation>()!, "Unexpected error occurred.");
            }
        }





    }
}