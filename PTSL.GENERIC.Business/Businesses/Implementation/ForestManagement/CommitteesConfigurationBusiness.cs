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
    public class CommitteesConfigurationBusiness : BaseBusiness<CommitteesConfiguration>, ICommitteesConfigurationBusiness
    {
        private readonly GENERICReadOnlyCtx _readOnlyContext;
        public CommitteesConfigurationBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyContext)
            : base(unitOfWork)
        {
            _readOnlyContext = readOnlyContext;
        }

        public override Task<(ExecutionState executionState, IQueryable<CommitteesConfiguration> entity, string message)> List(QueryOptions<CommitteesConfiguration> queryOptions = null)
        {
            return base.List(new QueryOptions<CommitteesConfiguration>()
            {
                IncludeExpression = e => e.Include(x => x.CommitteeTypeConfiguration!),
                SortingExpression = x => x.OrderByDescending(y => y.Id)
            });
        }
        public override Task<(ExecutionState executionState, CommitteesConfiguration entity, string message)> GetAsync(long id)
        {
            var filterOptions = new FilterOptions<CommitteesConfiguration>
            {
                IncludeExpression = x => x
                    .Include(x => x.CommitteeTypeConfiguration!),
                FilterExpression = e => e.Id == id
            };
            return base.GetAsync(filterOptions);
        }

        public async Task<(ExecutionState executionState, List<CommitteesConfiguration> entity, string message)> GetCommitteesConfigurationByCommitteeTypeConfigurationId(long id)
        {
            try
            {
                var query = _readOnlyContext.Set<CommitteesConfiguration>()
                    .Where(x => x.IsActive && !x.IsDeleted)
                    .OrderByDescending(x => x.Id)
                    .AsQueryable();

                query = query.Where(x => x.CommitteeTypeConfigurationId == id);
                var result = query.ToListAsync();

                return (ExecutionState.Retrieved, result.Result, "Data returned successfully.");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Failure, new List<CommitteesConfiguration>()!, "Unexpected error occurred.");
            }
        }






    }
}