using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.SocialForestry;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.SocialForestry.Nursery
{
    public class NurseryRaisedSeedlingInformationBusiness : BaseBusiness<NurseryRaisedSeedlingInformation>, INurseryRaisedSeedlingInformationBusiness
    {
        private readonly GENERICReadOnlyCtx _readOnlyCtx;

        public NurseryRaisedSeedlingInformationBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyCtx)
            : base(unitOfWork)
        {
            _readOnlyCtx = readOnlyCtx;
        }

        public async Task<(ExecutionState executionState, List<NurseryRaisedSeedlingInformation> entity, string message)> GetSeedlingByNurseryId(long id, bool forPlantationOrDistribution)
        {
            var list = await _readOnlyCtx.Set<NurseryRaisedSeedlingInformation>()
                .Where(x => x.NurseryInformationId == id)
                .WhereIf(forPlantationOrDistribution,
                    x => x.NurseryInformation!.NurseryRaisingSector!.RaisingSectorType == RaisingSectorType.ForPlantation || x.NurseryInformation!.NurseryRaisingSector!.RaisingSectorType == RaisingSectorType.ForDistributionAndPlantation)
                .ToListAsync();

            return (ExecutionState.Success, list, "Success");
        }

        public async Task<(ExecutionState executionState, NurseryRaisedSeedlingInformation entity, string message)> SeedlinUpdate(UpdateSeedlingInfoVM model)
        {
            FilterOptions<NurseryRaisedSeedlingInformation> filterOptions = new FilterOptions<NurseryRaisedSeedlingInformation>
            {
                FilterExpression = a => a.NurseryInformationId == model.NurseryId && a.Id == model.SeedlingId
            };
            var seedlingEntity = await base.GetAsync(filterOptions);

            if (seedlingEntity.executionState != ExecutionState.Retrieved)
            {
                return (ExecutionState.Failure, seedlingEntity.entity, seedlingEntity.message);
            }
            if (model.IsAdd)
            {
                seedlingEntity.entity.SeedlingRaised += model.SeedlingNumberToBeDistributed;

            }
            else
            {
                seedlingEntity.entity.SeedlingRaised -= model.SeedlingNumberToBeDistributed;

            }

            var updateSeedlingEntity = await base.UpdateAsync(seedlingEntity.entity);
            if (updateSeedlingEntity.executionState != ExecutionState.Updated)
            {
                return (ExecutionState.Failure, updateSeedlingEntity.entity, updateSeedlingEntity.message);
            }
            return (ExecutionState.Updated, updateSeedlingEntity.entity, updateSeedlingEntity.message);

        }
    }
}