using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.SocialForestry
{
    public class SocialForestryBeneficiaryBusiness : BaseBusiness<SocialForestryBeneficiary>, ISocialForestryBeneficiaryBusiness
    {
        private readonly GENERICReadOnlyCtx _readOnlyCtx;

        public SocialForestryBeneficiaryBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyCtx)
            : base(unitOfWork)
        {
            _readOnlyCtx = readOnlyCtx;
        }

        public override Task<(ExecutionState executionState, IQueryable<SocialForestryBeneficiary> entity, string message)> List(QueryOptions<SocialForestryBeneficiary>? queryOptions = null)
        {
            queryOptions = new QueryOptions<SocialForestryBeneficiary>
            {
                IncludeExpression = p => p.Include(a => a.Ethnicity!)
            };
            return base.List(queryOptions);
        }

        public Task<(ExecutionState executionState, SocialForestryBeneficiary entity, string message)> GetByIdAsync(long id, FilterOptions<SocialForestryBeneficiary>? filterOptions)
        {
            filterOptions = new FilterOptions<SocialForestryBeneficiary>
            {
                FilterExpression = p => p.Id == id,
                IncludeExpression = p => p.Include(a => a.Ethnicity!)
            };
            return base.GetAsync(filterOptions);
        }

        public async Task<(ExecutionState executionState, List<SocialForestryBeneficiary?> entity, string message)> GetBeneficiariesByNewRaisedId(long newRaisedId, bool hasPbsa = false)
        {
            var query = _readOnlyCtx.Set<PlantationSocialForestryBeneficiaryMap>()
                .WhereIf(newRaisedId > 0, x => x.NewRaisedPlantationId == newRaisedId)
                .Include(x => x.SocialForestryBeneficiary)
                .WhereIf(hasPbsa, x => x.PBSAGroupId != null || x.PBSAGroupId!.Equals(string.Empty) == false)
                .Select(x => x!.SocialForestryBeneficiary);

            var result = await query.ToListAsync();

            return (ExecutionState.Success, result.DistinctBy(x => x!.Id).ToList(), "Data returned successfully");
        }
    }
}
