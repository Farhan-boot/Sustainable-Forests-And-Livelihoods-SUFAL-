using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.Labour;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.Interface.Labour
{
    public interface ILabourDatabaseService : IBaseService<LabourDatabaseVM, LabourDatabase>
    {
        Task<(ExecutionState executionState, PaginationResutl<LabourDatabaseVM> entity, string message)> GetByFilter(LabourDatabaseFilterVM filter);
    }
}
