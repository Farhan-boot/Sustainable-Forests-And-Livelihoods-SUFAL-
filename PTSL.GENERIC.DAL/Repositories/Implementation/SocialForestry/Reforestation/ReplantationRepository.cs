using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestry.Reforestation;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestry.Reforestation
{
    public class ReplantationRepository : BaseRepository<Replantation>, IReplantationRepository
    {
        private readonly GENERICReadOnlyCtx _readOnlyCtx;

        public ReplantationRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx)
        {
            _readOnlyCtx = readOnlyCtx;
        }

        public async Task<(ExecutionState executionState, Replantation data, string message)> GetDetails(long id)
        {
            var data = await _readOnlyCtx.Set<Replantation>()
                .Include(x => x.FinancialYear)
                .Include(x => x.PlantationType)
                .Include(x => x.ReplantationNurseryInfos).ThenInclude(x => x.NurseryInformation)
                .Include(x => x.ReplantationNurseryInfos).ThenInclude(x => x.NurseryRaisedSeedlingInformation)
                .Include(x => x.ReplantationCostInfos).ThenInclude(x => x.CostType)
                .Include(x => x.ReplantationLaborInfos).ThenInclude(x => x.LaborCostType)
                .Include(x => x.ReplantationSocialForestryBeneficiaryMaps).ThenInclude(x => x.SocialForestryBeneficiary).ThenInclude(x => x.Ethnicity)
                .Include(x => x.ReplantationDamageInfos).ThenInclude(x => x.PlantationCauseOfDamage)
                .Include(x => x.ReplantationInspectionMaps).ThenInclude(x => x.InspectionDetails)
                .Include(x => x.ReplantationInspectionMaps).ThenInclude(x => x.InspectionDetails).ThenInclude(x => x.SocialForestryDesignation)

                .AsSplitQuery()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (data is null)
            {
                return (ExecutionState.Failure, null!, "Not found");
            }

            return (ExecutionState.Success, data, "Data returned successfully");
        }
    }
}