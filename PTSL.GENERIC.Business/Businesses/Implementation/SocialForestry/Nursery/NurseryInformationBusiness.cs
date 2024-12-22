using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Nursery;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Business.Businesses.Implementation.SocialForestry.Nursery
{
    public class NurseryInformationBusiness : BaseBusiness<NurseryInformation>, INurseryInformationBusiness
    {
        private readonly GENERICUnitOfWork _unitOfWork;
        private GENERICReadOnlyCtx _readOnlyCtx { get; }
        public NurseryInformationBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx ReadOnlyCtx)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _readOnlyCtx = ReadOnlyCtx;
        }

        public override async Task<(ExecutionState executionState, NurseryInformation entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, NurseryInformation entity, string message) result = await _unitOfWork.NurseryInformationRepository.GetNursaryInformationAsync(id);

            return result;
        }

        public async Task<(ExecutionState executionState, IList<NurseryInformation> entity, string message)> GetFilterData(NurseryFilterVM model)
        {
            try
            {
                IQueryable<NurseryInformation> query = _readOnlyCtx.Set<NurseryInformation>()
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

                query = query.WhereIf(model.HasFinancialYearId, x => x.FinancialYearId == model.FinancialYearId);
                query = query.WhereIf(model.HasNurseryId, x => x.Id == model.NurseryId);

                var result = await query.Include(p => p.ProjectType)
                                        .Include(c => c.NurseryType)
                                        .Include(k => k.FinancialYear)
                                        .Include(k => k.NurseryRaisingSector)
                                        .ToListAsync();

                return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception)
            {
                return (ExecutionState.Failure, new List<NurseryInformation>()!, "Unexpected error occurred.");
            }
        }

        public override Task<(ExecutionState executionState, IQueryable<NurseryInformation> entity, string message)> List(QueryOptions<NurseryInformation> queryOptions = null)
        {
            queryOptions = new QueryOptions<NurseryInformation>
            {
                IncludeExpression = a => a.Include(p => p.ProjectType)
                                          .Include(c => c.NurseryType)
                                          .Include(k => k.FinancialYear)
                                          .Include(k => k.NurseryRaisingSector)

            };
            return base.List(queryOptions);
        }

        public async Task<(ExecutionState executionState, IList<SocialForestryReport> entity, string message)> GetNurseryReport(NurseryFilterVM model)
        {
            try
            {
                IQueryable<NurseryInformation> query = _readOnlyCtx.Set<NurseryInformation>()
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

                query = query.WhereIf(model.HasFinancialYearId, x => x.FinancialYearId == model.FinancialYearId);
                query = query.WhereIf(model.HasNurseryId, x => x.Id == model.NurseryId);

                var result = await query.Include(a => a.ForestCircle)
                                        .Include(a => a.ForestDivision)
                                        .Include(a => a.ForestRange)
                                        .Include(a => a.ForestBeat)
                                        .Include(a => a.Division)
                                        .Include(a => a.District)
                                        .Include(a => a.Upazilla)
                                        .Include(a => a.Union)
                                        .Include(a => a.NurseryRaisedSeedlingInformation)
                                        .AsSplitQuery()
                                        .ToListAsync();
                var nurseryInformationList = new List<SocialForestryReport>();

                foreach (var item in result)
                {
                    var nurseryInformationReport = new SocialForestryReport();

                    nurseryInformationReport.NurseryInformation = item;
                    nurseryInformationList.Add(nurseryInformationReport);

                }
                return (ExecutionState.Retrieved, nurseryInformationList, "Data returned successfully.");
            }
            catch (Exception)
            {
                return (ExecutionState.Failure, new List<SocialForestryReport>()!, "Unexpected error occurred.");
            }
        }


        public async Task<(ExecutionState executionState, IList<SocialForestryReport> entity, string message)> GetNurseryDistributionReport(NurseryFilterVM model)
        {
            try
            {

                IQueryable<NurseryDistribution> nurseryDistribution = _readOnlyCtx.Set<NurseryDistribution>();

                // Forest Administration
                nurseryDistribution = nurseryDistribution.WhereIf(model.HasForestCircleId, x => x.NurseryInformation.ForestCircleId == model.ForestCircleId);
                nurseryDistribution = nurseryDistribution.WhereIf(model.HasForestDivisionId, x => x.NurseryInformation.ForestDivisionId == model.ForestDivisionId);
                nurseryDistribution = nurseryDistribution.WhereIf(model.HasForestRangeId, x => x.NurseryInformation.ForestRangeId == model.ForestRangeId);
                nurseryDistribution = nurseryDistribution.WhereIf(model.HasForestBeatId, x => x.NurseryInformation.ForestBeatId == model.ForestBeatId);

                // Civil Administration
                nurseryDistribution = nurseryDistribution.WhereIf(model.HasDivisionId, x => x.NurseryInformation.DivisionId == model.DivisionId);
                nurseryDistribution = nurseryDistribution.WhereIf(model.HasDistrictId, x => x.NurseryInformation.DistrictId == model.DistrictId);
                nurseryDistribution = nurseryDistribution.WhereIf(model.HasUpazillaId, x => x.NurseryInformation.UpazillaId == model.UpazillaId);
                nurseryDistribution = nurseryDistribution.WhereIf(model.HasUnionId, x => x.NurseryInformation.UnionId == model.UnionId);

                nurseryDistribution = nurseryDistribution.WhereIf(model.HasNurseryId, x => x.NurseryInformation.Id == model.NurseryId);

                nurseryDistribution = nurseryDistribution.WhereIf(model.HasDistributionDateFrom, x => x.DistributionDate.Date >= model.DistributionDateFrom.Value.Date);
                nurseryDistribution = nurseryDistribution.WhereIf(model.HasDistributionDateTo, x => x.DistributionDate.Date <= model.DistributionDateTo.Value.Date);

                var result = await nurseryDistribution
                                            .Include(a => a.NurseryInformation.ForestCircle)
                                            .Include(a => a.NurseryInformation.ForestDivision)
                                            .Include(a => a.NurseryInformation.ForestRange)
                                            .Include(a => a.NurseryInformation.ForestBeat)
                                            .Include(a => a.NurseryInformation.Division)
                                            .Include(a => a.NurseryInformation.District)
                                            .Include(a => a.NurseryInformation.Upazilla)
                                            .Include(a => a.NurseryInformation.Union)
                                            .Include(a => a.NurseryRaisedSeedling)
                                            .AsSplitQuery()
                                            .ToListAsync();
                var nurseryInformationList = new List<SocialForestryReport>();

                foreach (var item in result)
                {
                    var nurseryInformationReport = new SocialForestryReport();
                    nurseryInformationReport.NurseryDistribution = item;
                    nurseryInformationList.Add(nurseryInformationReport);

                }
                return (ExecutionState.Retrieved, nurseryInformationList, "Data returned successfully.");
            }
            catch (Exception)
            {
                return (ExecutionState.Failure, new List<SocialForestryReport>()!, "Unexpected error occurred.");
            }
        }
        public async Task<(ExecutionState executionState, IList<SocialForestryReport> entity, string message)> GetNurseryDistributionByBeneficiaryReport(NurseryFilterVM model)
        {
            try
            {

                IQueryable<NurseryDistribution> nurseryDistribution = _readOnlyCtx.Set<NurseryDistribution>();

                // Forest Administration
                nurseryDistribution = nurseryDistribution.WhereIf(model.HasForestCircleId, x => x.NurseryInformation.ForestCircleId == model.ForestCircleId);
                nurseryDistribution = nurseryDistribution.WhereIf(model.HasForestDivisionId, x => x.NurseryInformation.ForestDivisionId == model.ForestDivisionId);
                nurseryDistribution = nurseryDistribution.WhereIf(model.HasForestRangeId, x => x.NurseryInformation.ForestRangeId == model.ForestRangeId);
                nurseryDistribution = nurseryDistribution.WhereIf(model.HasForestBeatId, x => x.NurseryInformation.ForestBeatId == model.ForestBeatId);

                // Civil Administration
                nurseryDistribution = nurseryDistribution.WhereIf(model.HasDivisionId, x => x.NurseryInformation.DivisionId == model.DivisionId);
                nurseryDistribution = nurseryDistribution.WhereIf(model.HasDistrictId, x => x.NurseryInformation.DistrictId == model.DistrictId);
                nurseryDistribution = nurseryDistribution.WhereIf(model.HasUpazillaId, x => x.NurseryInformation.UpazillaId == model.UpazillaId);
                nurseryDistribution = nurseryDistribution.WhereIf(model.HasUnionId, x => x.NurseryInformation.UnionId == model.UnionId);

                nurseryDistribution = nurseryDistribution.WhereIf(model.HasNurseryId, x => x.NurseryInformation.Id == model.NurseryId);

                nurseryDistribution = nurseryDistribution.WhereIf(model.HasDistributionDateFrom, x => x.DistributionDate.Date >= model.DistributionDateFrom.Value.Date);
                nurseryDistribution = nurseryDistribution.WhereIf(model.HasDistributionDateTo, x => x.DistributionDate.Date <= model.DistributionDateTo.Value.Date);

                nurseryDistribution = nurseryDistribution.WhereIf(model.HasBeneficiaryName, x => x.DistributedTo.ToLower() == model.BeneficiaryName.ToLower());
                nurseryDistribution = nurseryDistribution.WhereIf(model.HasBeneficiaryNid, x => x.BeneficiaryNid.ToLower() == model.BeneficiaryNid.ToLower());

                var result = await nurseryDistribution
                                            .Include(a => a.NurseryInformation.ForestCircle)
                                            .Include(a => a.NurseryInformation.ForestDivision)
                                            .Include(a => a.NurseryInformation.ForestRange)
                                            .Include(a => a.NurseryInformation.ForestBeat)
                                            .Include(a => a.NurseryInformation.Division)
                                            .Include(a => a.NurseryInformation.District)
                                            .Include(a => a.NurseryInformation.Upazilla)
                                            .Include(a => a.NurseryInformation.Union)
                                            .Include(a => a.NurseryRaisedSeedling)
                                            .AsSplitQuery()
                                            .ToListAsync();
                var nurseryInformationList = new List<SocialForestryReport>();

                foreach (var item in result)
                {
                    var nurseryInformationReport = new SocialForestryReport();
                    nurseryInformationReport.NurseryDistribution = item;
                    nurseryInformationList.Add(nurseryInformationReport);

                }
                return (ExecutionState.Retrieved, nurseryInformationList, "Data returned successfully.");
            }
            catch (Exception)
            {
                return (ExecutionState.Failure, new List<SocialForestryReport>()!, "Unexpected error occurred.");
            }
        }



    }
}