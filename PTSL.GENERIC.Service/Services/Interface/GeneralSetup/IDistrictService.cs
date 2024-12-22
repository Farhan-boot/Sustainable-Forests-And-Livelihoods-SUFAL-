﻿using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services
{
    public interface IDistrictService : IBaseService<DistrictVM, District>
    {
        Task<(ExecutionState executionState, IList<DistrictVM> entity, string message)> ListByDivision(long DivisionId);

    }
}