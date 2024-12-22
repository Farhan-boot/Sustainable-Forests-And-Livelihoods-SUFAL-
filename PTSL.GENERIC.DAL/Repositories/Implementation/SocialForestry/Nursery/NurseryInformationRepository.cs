using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestry.Nursery;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestry.Nursery
{
    public class NurseryInformationRepository : BaseRepository<NurseryInformation>, INurseryInformationRepository
    {
        private readonly GENERICReadOnlyCtx _readOnlyCtx;

        public NurseryInformationRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx)
        {
            _readOnlyCtx = readOnlyCtx;
        }
        public async Task<(ExecutionState executionState, NurseryInformation entity, string message)> GetNursaryInformationAsync(long id)
        {
            DbSet<NurseryInformation> readOnlySet = _readOnlyCtx.Set<NurseryInformation>();
            NurseryInformation entity = await readOnlySet.Where(x => x.Id.Equals(id) && x.IsDeleted != true)
                                                    .Include(a => a.ForestCircle)
                                                    .Include(a => a.ForestDivision)
                                                    .Include(a => a.ForestBeat)
                                                    .Include(a => a.ForestRange)
                                                    .Include(a => a.ForestFcvVcf)

                                                    .Include(a => a.Division)
                                                    .Include(a => a.District)
                                                    .Include(a => a.Upazilla)
                                                    .Include(a => a.Union)

                                                    .Include(a => a.FinancialYear)
                                                    .Include(a => a.ProjectType)
                                                    .Include(a => a.NurseryType)
                                                    .Include(a => a.NurseryRaisingSector)

                                                    .Include(a => a.NurseryRaisedSeedlingInformation)
                                                    .Include(a => a.ConcernedOfficialMap).ThenInclude(m => m.ConcernedOfficial).ThenInclude(a=>a.Designation)
                                                    .Include(a => a.InspectionDetailsMap).ThenInclude(m => m.InspectionDetails)
                                                    .Include(a => a.CostInformations)
                                                    .Include(a=>a.NurseryDistributionDetails)
                                                    .AsSplitQuery()
                                                    .FirstOrDefaultAsync();
            if (entity != null)
            {
                return (ExecutionState.Retrieved, entity, "Retireved Successfully");
            }
            return (ExecutionState.Failure, null, "Nursary Information Not found");

        }
    }
}