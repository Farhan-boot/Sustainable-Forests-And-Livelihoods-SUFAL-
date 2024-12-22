using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;

using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestry;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestry
{
    public class NewRaisedPlantationRepository : BaseRepository<NewRaisedPlantation>, INewRaisedPlantationRepository
    {
        private readonly GENERICReadOnlyCtx _readOnlyCtx;

        public NewRaisedPlantationRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx)
        {
            _readOnlyCtx = readOnlyCtx;
        }

        public async Task<(ExecutionState executionState, NewRaisedPlantation data, string message)> GetDetails(long id)
        {
            var data = await _readOnlyCtx.Set<NewRaisedPlantation>()
                .Include(x => x.ForestCircle)
                .Include(x => x.ForestBeat)
                .Include(x => x.ForestRange)
                .Include(x => x.ForestDivision)
                .Include(x => x.ZoneOrArea)

                .Include(x => x.Division)
                .Include(x => x.District)
                .Include(x => x.Upazilla)
                .Include(x => x.Union)

                .Include(x => x.LandOwningAgency)
                .Include(x => x.PlantationType)
                .Include(x => x.PlantationUnit)
                .Include(x => x.PlantationTopography)

                .Include(x => x.SocialForestryNgo)
                .Include(x => x.PlantedFinancialYear)
                .Include(x => x.ProjectType)
                .Include(x => x.PlantationFiles)
                .Include(x => x.PlantationPlants).ThenInclude(y => y.NurseryInformation)
                .Include(x => x.PlantationPlants).ThenInclude(y => y.NurseryRaisedSeedlingInformation)
                .Include(x => x.CostInformation).ThenInclude(x => x.CostInformationFiles)
                .Include(x => x.CostInformation).ThenInclude(x => x.CostType)
                .Include(x => x.LaborInformation).ThenInclude(x => x.LaborInformationFiles)
                .Include(x => x.LaborInformation).ThenInclude(x => x.LaborCostType)
                .Include(x => x.PlantationSocialForestryBeneficiaryMaps).ThenInclude(x => x.SocialForestryBeneficiary).ThenInclude(x => x.Ethnicity)
                .Include(x => x.PlantationDamageInformation).ThenInclude(x => x.PlantationCauseOfDamage)
                .Include(x => x.ConcernedOfficialMap).ThenInclude(x => x.ConcernedOfficial).ThenInclude(x => x.Designation)
                .Include(x => x.InspectionDetailsMap).ThenInclude(x => x.InspectionDetails)
                .Include(x => x.InspectionDetailsMap).ThenInclude(x => x.InspectionDetails).ThenInclude(x => x.SocialForestryDesignation)

                .AsSplitQuery()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (data is null)
            {
                return (ExecutionState.Failure, null!, "Not found");
            }

            return (ExecutionState.Success, data, "Data returned successfully");
        }

        public async Task<(ExecutionState executionState, NewRaisedPlantation data, string message)> GetDetailsForEdit(long id)
        {
            var data = await _readOnlyCtx.Set<NewRaisedPlantation>()
                .Include(x => x.PlantationFiles)
                .Include(x => x.PlantationPlants).ThenInclude(x => x.NurseryInformation)
                .Include(x => x.PlantationPlants).ThenInclude(x => x.NurseryRaisedSeedlingInformation)
                .Include(x => x.CostInformation).ThenInclude(x => x.CostInformationFiles)
                .Include(x => x.CostInformation).ThenInclude(x => x.CostType)
                .Include(x => x.LaborInformation).ThenInclude(x => x.LaborInformationFiles)
                .Include(x => x.PlantationSocialForestryBeneficiaryMaps).ThenInclude(x => x.SocialForestryBeneficiary)
                .Include(x => x.PlantationDamageInformation)
                .Include(x => x.ConcernedOfficialMap).ThenInclude(x => x.ConcernedOfficial).ThenInclude(x => x.Designation)
                .Include(x => x.InspectionDetailsMap).ThenInclude(x => x.InspectionDetails).ThenInclude(x => x.SocialForestryDesignation)

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