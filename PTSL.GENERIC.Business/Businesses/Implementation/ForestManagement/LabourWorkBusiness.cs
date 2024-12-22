using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.Labour;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.Labour;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.Labour
{
    public class LabourWorkBusiness : BaseBusiness<LabourWork>, ILabourWorkBusiness
    {
        private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

        public LabourWorkBusiness(GENERICUnitOfWork unitOfWork, GENERICWriteOnlyCtx writeOnlyCtx)
            : base(unitOfWork)
        {
            _writeOnlyCtx = writeOnlyCtx;
        }

        public async Task<(ExecutionState executionState, List<LabourWork> entity, string message)> ListByFilter(LabourWorkFilterVM filter)
        {
            if (filter.HasLabourDatabaseId == false)
            {
                return (ExecutionState.Failure, new List<LabourWork>(), "Labour database Id is not valid");
            }

            var result = await _writeOnlyCtx.Set<LabourWork>()
                .Where(x => x.LabourDatabaseId == filter.LabourDatabaseId)
                .ToListAsync();

            return (ExecutionState.Retrieved, result, "Data returned successfully");
        }

        public override Task<(ExecutionState executionState, LabourWork entity, string message)> CreateAsync(LabourWork entity)
        {
            entity.TotalAmount = entity.PaymentAmountPerDay * entity.ManDays;

            return base.CreateAsync(entity);
        }

        public override Task<(ExecutionState executionState, LabourWork entity, string message)> UpdateAsync(LabourWork entity)
        {
            entity.TotalAmount = entity.PaymentAmountPerDay * entity.ManDays;

            return base.UpdateAsync(entity);
        }
    }
}