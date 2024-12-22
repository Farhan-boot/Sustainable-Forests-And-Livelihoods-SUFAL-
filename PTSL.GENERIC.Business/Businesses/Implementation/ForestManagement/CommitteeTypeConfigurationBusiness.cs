using System.Collections.Generic;
using System.Threading.Tasks;
using System;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.ForestManagement;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.DAL.UnitOfWork;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PTSL.GENERIC.Business.Businesses.Implementation.ForestManagement
{
    public class CommitteeTypeConfigurationBusiness : BaseBusiness<CommitteeTypeConfiguration>, ICommitteeTypeConfigurationBusiness
    {
        private readonly GENERICReadOnlyCtx _readOnlyContext;

        public CommitteeTypeConfigurationBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyContext)
            : base(unitOfWork)
        {
            _readOnlyContext = readOnlyContext;
        }

        public async Task<(ExecutionState executionState, List<CommitteeTypeConfiguration> entity, string message)> GetCommitteeTypeConfigurationByFcvOrVcfId(long id)
        {
            try
            {
                var query = _readOnlyContext.Set<CommitteeTypeConfiguration>()
                    .Where(x => x.IsActive && !x.IsDeleted)
                    .OrderByDescending(x => x.Id)
                    .AsQueryable();

                query = query.Where(x => x.FcvOrVcfTypeId == id);
                var result = query.ToListAsync();

                return (ExecutionState.Retrieved, result.Result, "Data returned successfully.");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Failure, new List<CommitteeTypeConfiguration>()!, "Unexpected error occurred.");
            }
        }


    }
}