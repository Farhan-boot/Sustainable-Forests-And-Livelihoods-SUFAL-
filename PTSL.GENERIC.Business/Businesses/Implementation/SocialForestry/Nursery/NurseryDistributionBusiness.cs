using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Nursery;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace PTSL.GENERIC.Business.Businesses.Implementation.SocialForestry.Nursery
{
    public class NurseryDistributionBusiness : BaseBusiness<NurseryDistribution>, INurseryDistributionBusiness
    {
        private readonly GENERICReadOnlyCtx _readOnlyCtx;
        private readonly GENERICWriteOnlyCtx _writeOnlyCtx;
        private readonly INurseryRaisedSeedlingInformationBusiness _nurseryRaisedSeedlingInformationBusiness;

        public NurseryDistributionBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyCtx, INurseryRaisedSeedlingInformationBusiness nurseryRaisedSeedlingInformationBusiness, GENERICWriteOnlyCtx writeOnlyCtx)
            : base(unitOfWork)
        {
            _readOnlyCtx = readOnlyCtx;
            _nurseryRaisedSeedlingInformationBusiness = nurseryRaisedSeedlingInformationBusiness;
            _writeOnlyCtx = writeOnlyCtx;
        }

        public async Task<(ExecutionState executionState, IList<NurseryDistribution> entity, string message)> GetByNurseryAsync(long id)
        {
            IList<NurseryDistribution> result = await _readOnlyCtx.Set<NurseryDistribution>().Where(x => x.NurseryInformationId == id)
                                           .ToListAsync();


            if (result != null)
            {
                return (ExecutionState.Retrieved, result, "Success");
            }
            return (ExecutionState.Failure, null!, "No data found");
        }

        public async Task<(ExecutionState executionState, List<DistributionVM> entity, string message)> ListByNurseryId(long nurseryId, QueryOptions<NurseryDistribution> queryOptions = null)
        {
            List<DistributionVM> query = _readOnlyCtx.Set<NurseryDistribution>()
                                    .Where(a => a.NurseryInformationId == nurseryId)
                                    .Join(_readOnlyCtx.Set<NurseryInformation>(),
                                        distribution => distribution.NurseryInformationId,
                                        nurseryInfo => nurseryInfo.Id,
                                        (distribution, nurseryInfo) => new { distribution, nurseryInfo })
                                    .Join(_readOnlyCtx.Set<NurseryRaisedSeedlingInformation>(),
                                        joined => joined.distribution.NurseryRaisedSeedlingId,
                                        raisedSeedlingInfo => raisedSeedlingInfo.Id,
                                        (joined, raisedSeedlingInfo) => new { joined, raisedSeedlingInfo })
                                    .GroupBy(
                                        grouped => new
                                        {
                                            grouped.joined.nurseryInfo.NurseryName,
                                            grouped.joined.distribution.DistributionDate

                                        })
                                    .Select(grouped => new DistributionVM
                                    {
                                        NurseryName = grouped.Key.NurseryName,
                                        DistributionDate = grouped.Key.DistributionDate,
                                        TotalNumberOfSeedlingToBeDistributed = (long)grouped.Sum(x => x.joined.distribution.NumberOfSeedlingToBeDistributed ?? 0)
                                    }).ToList();

            List<NurseryRaisedSeedlingInformation> nuseryRaisedSeedlingInfo = _readOnlyCtx.Set<NurseryRaisedSeedlingInformation>().Where(n => n.NurseryInformationId == nurseryId).ToList();
            int seedlingInfo = 0;
            if (nuseryRaisedSeedlingInfo.Count > 0 && nuseryRaisedSeedlingInfo != null)
            {
                seedlingInfo = nuseryRaisedSeedlingInfo.GroupBy(n => n.NurseryInformationId)
                                                                                 .Select(g => new
                                                                                 {
                                                                                     NurseryInformationId = g.Key,
                                                                                     TotalSeedlingRaised = g.Sum(n => n.SeedlingRaised)
                                                                                 })
                                                                                  .FirstOrDefault().TotalSeedlingRaised;

            }



            if (query.Count >= 0 && query != null)
            {
                if (query.Count > 0)
                {
                    query.ForEach(a => a.TotalSeedlingRaised = seedlingInfo);
                    return (ExecutionState.Success, query, "Success");

                }
                else if (query.Count == 0)
                {
                    var dummy = new List<DistributionVM>();
                    dummy.Add(new DistributionVM { TotalSeedlingRaised = seedlingInfo });
                    return (ExecutionState.Success, dummy, "Success");

                }


            }

            return (ExecutionState.Failure, new List<DistributionVM>(), "Failure");

        }


        public async Task<(ExecutionState executionState, List<NurseryDistribution> entity, string message)> CreateRangeAsync(List<NurseryDistribution> model)
        {
            try
            {

                _writeOnlyCtx.Set<NurseryDistribution>().UpdateRange(model);
                var returnResponse = await _writeOnlyCtx.SaveChangesAsync();
                if (returnResponse > 0)
                {
                    return (ExecutionState.Created, model, "Success");
                }
                else
                {
                    return (ExecutionState.Failure, null!, "Failed");
                }
            }
            catch (Exception ex)
            {
                return (ExecutionState.Failure, null!, ex.Message);
            }
        }
        public async Task<(ExecutionState executionState, List<NurseryDistribution> entity, string message)> UpdateRangeAsync(List<NurseryDistribution> model)
        {
            try
            {

                _writeOnlyCtx.Set<NurseryDistribution>().UpdateRange(model);
                var returnResponse = await _writeOnlyCtx.SaveChangesAsync();
                if (returnResponse > 0)
                {
                    return (ExecutionState.Created, model, "Success");
                }
                else
                {
                    return (ExecutionState.Failure, null!, "Failed");
                }
            }
            catch (Exception ex)
            {
                return (ExecutionState.Failure, null!, ex.Message);
            }
        }
        public override Task<(ExecutionState executionState, NurseryDistribution entity, string message)> GetAsync(long key)
        {
            FilterOptions<NurseryDistribution> filterOptions = new FilterOptions<NurseryDistribution>
            {
                FilterExpression = x => x.Id == key,
                IncludeExpression = x => x.Include(y => y.NurseryInformation).ThenInclude(y => y.NurseryRaisedSeedlingInformation)
            };
            return base.GetAsync(filterOptions);
        }

        public async Task<(ExecutionState executionState, IQueryable<NurseryDistribution> entity, string message)> ListByDistributionById(long id, QueryOptions<NurseryDistribution> queryOptions = null)
        {

            queryOptions = queryOptions ?? new QueryOptions<NurseryDistribution>
            {
                FilterExpression = x => x.Id == id,
                IncludeExpression = x => x.Include(y => y.NurseryInformation).ThenInclude(y => y.NurseryRaisedSeedlingInformation)
            };

            return await base.List(queryOptions);
        }

        public async Task<(ExecutionState executionState, IQueryable<NurseryDistribution> entity, string message)> GetFilterData(DistributionFilter model)
        {
            QueryOptions<NurseryDistribution> queryOptions = new QueryOptions<NurseryDistribution>
            {
                FilterExpression = x => x.NurseryInformationId == model.NurseryId && x.DistributionDate.Date == model.DistributionDate.Date,
                IncludeExpression = x => x.Include(y => y.NurseryInformation).ThenInclude(y => y.NurseryRaisedSeedlingInformation)
            };
            return await base.List(queryOptions);
        }

        public async Task<(ExecutionState executionState, IList<DistributionVM> entity, string message)> GetFilterByDate(long nurseryId, NurseryFilterVM model)
        {
            try
            {
                IQueryable<NurseryDistribution> query = _readOnlyCtx.Set<NurseryDistribution>()
                    .OrderByDescending(x => x.Id);

                query = query.WhereIf(model.HasDistributionDate, x => x.DistributionDate.Date == model.DistributionDate.Value.Date);

                var result = await query.Join(_readOnlyCtx.Set<NurseryInformation>(),
                                        distribution => distribution.NurseryInformationId,
                                        nurseryInfo => nurseryInfo.Id,
                                        (distribution, nurseryInfo) => new { distribution, nurseryInfo })
                                    .Join(_readOnlyCtx.Set<NurseryRaisedSeedlingInformation>(),
                                        joined => joined.distribution.NurseryRaisedSeedlingId,
                                        raisedSeedlingInfo => raisedSeedlingInfo.Id,
                                        (joined, raisedSeedlingInfo) => new { joined, raisedSeedlingInfo })
                                    .GroupBy(
                                        grouped => new
                                        {
                                            grouped.joined.nurseryInfo.NurseryName,
                                            grouped.joined.distribution.DistributionDate

                                        })
                                    .Select(grouped => new DistributionVM
                                    {
                                        NurseryName = grouped.Key.NurseryName,
                                        DistributionDate = grouped.Key.DistributionDate,
                                        TotalNumberOfSeedlingToBeDistributed = (long)grouped.Sum(x => x.joined.distribution.NumberOfSeedlingToBeDistributed ?? 0)
                                    }).ToListAsync();

                int seedlingInfo = _readOnlyCtx.Set<NurseryRaisedSeedlingInformation>().Where(n => n.NurseryInformationId == nurseryId)
                                                                             .GroupBy(n => n.NurseryInformationId)
                                                                             .Select(g => new
                                                                             {
                                                                                 NurseryInformationId = g.Key,
                                                                                 TotalSeedlingRaised = g.Sum(n => n.SeedlingRaised)
                                                                             })
                                                                              .FirstOrDefault().TotalSeedlingRaised;

                result.ForEach(a => a.TotalSeedlingRaised = seedlingInfo);
                return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception)
            {
                return (ExecutionState.Failure, new List<DistributionVM>()!, "Unexpected error occurred.");
            }
        }
    }
}