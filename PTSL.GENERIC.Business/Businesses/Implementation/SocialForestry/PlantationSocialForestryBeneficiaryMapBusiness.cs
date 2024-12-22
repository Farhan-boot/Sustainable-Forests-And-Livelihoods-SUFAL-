using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry;
using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.SocialForestry
{
    public class PlantationSocialForestryBeneficiaryMapBusiness : BaseBusiness<PlantationSocialForestryBeneficiaryMap>, IPlantationSocialForestryBeneficiaryMapBusiness
    {
        public PlantationSocialForestryBeneficiaryMapBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
        public override Task<(ExecutionState executionState, IQueryable<PlantationSocialForestryBeneficiaryMap> entity, string message)> List(QueryOptions<PlantationSocialForestryBeneficiaryMap> queryOptions = null)
        {
            queryOptions ??= new QueryOptions<PlantationSocialForestryBeneficiaryMap>
            {
                IncludeExpression = x => x.Include(a => a.SocialForestryBeneficiary)
                                          .ThenInclude(a => a.Ethnicity)
                                          .Include(a => a.NewRaisedPlantation)
            };
            return base.List(queryOptions);
        }
        public override Task<(ExecutionState executionState, PlantationSocialForestryBeneficiaryMap entity, string message)> GetAsync(long key)
        {
            FilterOptions<PlantationSocialForestryBeneficiaryMap> filterOptions = new FilterOptions<PlantationSocialForestryBeneficiaryMap>
            {
                FilterExpression = a => a.Id == key,
                IncludeExpression = a => a.Include(a => a.SocialForestryBeneficiary)
                                          .ThenInclude(a => a.Ethnicity)
                                          .Include(a => a.NewRaisedPlantation)

            };
            return base.GetAsync(filterOptions);

        }
    }
}