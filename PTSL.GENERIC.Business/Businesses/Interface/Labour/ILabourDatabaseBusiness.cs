using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.Labour;

namespace PTSL.GENERIC.Business.Businesses.Interface.Labour
{
    public interface ILabourDatabaseBusiness : IBaseBusiness<LabourDatabase>
    {
        Task<(ExecutionState executionState, PaginationResutl<LabourDatabase> entity, string message)> GetByFilter(LabourDatabaseFilterVM filterData);
    }
}
