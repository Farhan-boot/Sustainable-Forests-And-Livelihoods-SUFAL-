using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.AIG
{
    public class IndividualGroupFormSetupBusiness : BaseBusiness<IndividualGroupFormSetup>, IIndividualGroupFormSetupBusiness
    {
        private readonly GENERICReadOnlyCtx _readOnlyCtx;

        public IndividualGroupFormSetupBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyCtx)
            : base(unitOfWork)
        {
            _readOnlyCtx = readOnlyCtx;
        }

        public override async Task<(ExecutionState executionState, IndividualGroupFormSetup entity, string message)> CreateAsync(IndividualGroupFormSetup entity)
        {
            var count = await _readOnlyCtx.Set<IndividualGroupFormSetup>().CountAsync();

            if (count > 0)
            {
                return (ExecutionState.Failure, null!, "Document already added.");
            }

            return await base.CreateAsync(entity);
        }
    }
}