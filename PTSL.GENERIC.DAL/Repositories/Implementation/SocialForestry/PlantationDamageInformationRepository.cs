using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestry;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestry
{
    public class PlantationDamageInformationRepository : BaseRepository<PlantationDamageInformation>, IPlantationDamageInformationRepository
    {
        public PlantationDamageInformationRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}