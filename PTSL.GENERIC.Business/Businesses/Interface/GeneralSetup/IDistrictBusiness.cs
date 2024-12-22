using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Interface
{
    public interface IDistrictBusiness : IBaseBusiness<District>
    {
        Task<(ExecutionState executionState, IQueryable<District> entity, string message)> ListByDivision(long DivisionId);
    }
}
