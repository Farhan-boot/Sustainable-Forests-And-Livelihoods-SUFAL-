﻿using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup
{
    public interface IDivisionService
    {
        (ExecutionState executionState, List<DivisionVM> entity, string message) List();
        (ExecutionState executionState, DivisionVM entity, string message) Create(DivisionVM model);
        (ExecutionState executionState, DivisionVM entity, string message) GetById(long? id);
        (ExecutionState executionState, DivisionVM entity, string message) Update(DivisionVM model);
        (ExecutionState executionState, DivisionVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
