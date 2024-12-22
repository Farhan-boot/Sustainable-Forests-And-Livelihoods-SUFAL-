using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.SocialForestry.Cutting
{
    public class LotWiseSellingInformationBusiness : BaseBusiness<LotWiseSellingInformation>, ILotWiseSellingInformationBusiness
    {
        private readonly GENERICReadOnlyCtx _readOnlyCtx;

        public LotWiseSellingInformationBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyCtx)
            : base(unitOfWork)
        {
            _readOnlyCtx = readOnlyCtx;
        }

        public async Task<(ExecutionState executionState, List<LotWiseSellingInformation> data, string message)> GetLotInfoByCuttingId(long id)
        {
            var list = await _readOnlyCtx.Set<LotWiseSellingInformation>().Where(x => x.CuttingPlantationId == id).ToListAsync();

            return (ExecutionState.Success, list, "Success");
        }

        public async Task<(ExecutionState executionState, LotWiseSellingInformation data, string message)> GetLotInfoByLotNumber(string lotNumber)
        {
            var list = await _readOnlyCtx.Set<LotWiseSellingInformation>().Where(x => x.LotNumber == lotNumber).SingleOrDefaultAsync();
            if (list is null)
            {
                return (ExecutionState.Failure, null!, "Success");
            }

            return (ExecutionState.Success, list, "Success");
        }
    }
}