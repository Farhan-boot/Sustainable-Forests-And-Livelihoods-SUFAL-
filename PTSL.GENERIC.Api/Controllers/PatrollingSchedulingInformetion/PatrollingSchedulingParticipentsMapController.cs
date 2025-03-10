﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Common.Model.EntityViewModels.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Service.Services.Interface.Capacity;
using PTSL.GENERIC.Service.Services.Interface.PatrollingSchedulingInformetion;

namespace PTSL.GENERIC.Api.Controllers.PatrollingSchedulingInformetion
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PatrollingSchedulingParticipentsMapController : BaseController<IPatrollingSchedulingParticipentsMapService, PatrollingSchedulingParticipentsMapVM, PatrollingSchedulingParticipentsMap>
    {
        public PatrollingSchedulingParticipentsMapController(IPatrollingSchedulingParticipentsMapService service) :
            base(service)
        { }
    }
}
