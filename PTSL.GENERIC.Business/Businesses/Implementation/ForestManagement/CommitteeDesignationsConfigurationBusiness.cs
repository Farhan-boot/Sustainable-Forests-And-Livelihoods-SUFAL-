using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.ForestManagement;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;
using PTSL.GENERIC.Common.Entity;

namespace PTSL.GENERIC.Business.Businesses.Implementation.ForestManagement
{
    public class CommitteeDesignationsConfigurationBusiness : BaseBusiness<CommitteeDesignationsConfiguration>, ICommitteeDesignationsConfigurationBusiness
    {
        private readonly GENERICReadOnlyCtx _readOnlyContext;
        public CommitteeDesignationsConfigurationBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyContext)
            : base(unitOfWork)
        {
            _readOnlyContext = readOnlyContext;
        }

        public override Task<(ExecutionState executionState, IQueryable<CommitteeDesignationsConfiguration> entity, string message)> List(QueryOptions<CommitteeDesignationsConfiguration> queryOptions = null)
        {
            return base.List(new QueryOptions<CommitteeDesignationsConfiguration>()
            {
                IncludeExpression = e => e.Include(x => x.CommitteesConfiguration!),
                SortingExpression = x => x.OrderByDescending(y => y.Id)
            });
        }

        public override Task<(ExecutionState executionState, CommitteeDesignationsConfiguration entity, string message)> GetAsync(long id)
        {
            var filterOptions = new FilterOptions<CommitteeDesignationsConfiguration>
            {
                IncludeExpression = x => x
                    .Include(x => x.CommitteesConfiguration!),
                FilterExpression = e => e.Id == id
            };
            return base.GetAsync(filterOptions);
        }


        public async Task<(ExecutionState executionState, List<CommitteeDesignationsConfiguration> entity, string message)> GetCommitteeDesignationsConfigurationByCommitteesConfigurationId(long id)
        {
            try
            {
                var query = _readOnlyContext.Set<CommitteeDesignationsConfiguration>()
                    .Where(x => x.IsActive && !x.IsDeleted)
                    .OrderByDescending(x => x.Id)
                    .AsQueryable();

                query = query.Where(x => x.CommitteesConfigurationId == id);
                var result = query.ToListAsync();

                return (ExecutionState.Retrieved, result.Result, "Data returned successfully.");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Failure, new List<CommitteeDesignationsConfiguration>()!, "Unexpected error occurred.");
            }
        }



    }
}