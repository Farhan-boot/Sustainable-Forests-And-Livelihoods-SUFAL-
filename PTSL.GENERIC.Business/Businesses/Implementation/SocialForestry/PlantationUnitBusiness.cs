using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.SocialForestry;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.SocialForestry
{
    public class PlantationUnitBusiness : BaseBusiness<PlantationUnit>, IPlantationUnitBusiness
    {
        private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

        public PlantationUnitBusiness(GENERICUnitOfWork unitOfWork, GENERICWriteOnlyCtx writeOnlyCtx)
            : base(unitOfWork)
        {
            _writeOnlyCtx = writeOnlyCtx;
        }

        public async Task<(ExecutionState executionState, List<PlantationUnit> entity, string message)> ListByType(UnitType unitType)
        {
            var units = await _writeOnlyCtx
                .Set<PlantationUnit>()
                .Where(x => x.UnitType == unitType)
                .ToListAsync();

            return (ExecutionState.Success, units, "Ok");
        }
    }
}