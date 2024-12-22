using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.SocialForestry.Cutting
{
    public class DistributionPercentageBusiness : BaseBusiness<DistributionPercentage>, IDistributionPercentageBusiness
    {
        private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

        public DistributionPercentageBusiness(GENERICUnitOfWork unitOfWork, GENERICWriteOnlyCtx writeOnlyCtx)
            : base(unitOfWork)
        {
            _writeOnlyCtx = writeOnlyCtx;
        }

        public async Task<(ExecutionState executionState, List<DistributionPercentage> entity, string message)> CreateRangeAsync(List<DistributionPercentage> model)
        {
            try
            {

                await _writeOnlyCtx.Set<DistributionPercentage>().AddRangeAsync(model);
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
                if (ex.InnerException.Message.Contains("23505"))
                {

                    return (ExecutionState.Failure, null!, "Distribution Information already exists");
                }
                else
                {

                    return (ExecutionState.Failure, null!, ex.Message);
                }
            }
        }
        public async Task<(ExecutionState executionState, List<DistributionPercentage> entity, string message)> UpdateRangeAsync(long id, List<DistributionPercentage> model)
        {
            try
            {
                await _writeOnlyCtx.Set<DistributionPercentage>().Where(a => a.PlantationTypeId == id).ExecuteDeleteAsync();

                await _writeOnlyCtx.Set<DistributionPercentage>().AddRangeAsync(model);

                var returnResponse = await _writeOnlyCtx.SaveChangesAsync();

                if (returnResponse > 0)
                {
                    return (ExecutionState.Updated, model, "Success");
                }
                else
                {
                    return (ExecutionState.Failure, null!, "Failed");
                }


            }

            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("23505"))
                {

                    return (ExecutionState.Failure, null!, "Distribution Information already exists");
                }
                return (ExecutionState.Failure, null!, ex.Message);
            }
        }

        public async Task<(ExecutionState executionState, IQueryable<DistributionPercentage> entity, string message)> GetByPlantationTypeId(long? id)
        {
            QueryOptions<DistributionPercentage> options = new QueryOptions<DistributionPercentage>
            {
                FilterExpression = e => e.PlantationTypeId == id,
                IncludeExpression = p => p.Include(a => a.DistributionFundType)
                                          .Include(a => a.PlantationType)
            };

            return await base.List(options);
        }

        public override Task<(ExecutionState executionState, IQueryable<DistributionPercentage> entity, string message)> List(QueryOptions<DistributionPercentage> queryOptions = null)
        {
            queryOptions = new QueryOptions<DistributionPercentage>
            {
                IncludeExpression = p => p.Include(a => a.DistributionFundType)
                                          .Include(a => a.PlantationType)
            };
            return base.List(queryOptions);
        }
    }
}