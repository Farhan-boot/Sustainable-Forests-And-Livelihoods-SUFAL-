﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Service.Services.Interface;

namespace PTSL.GENERIC.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingTypeController : BaseController<IMeetingTypeService, MeetingTypeVM, MeetingType>
    {
        public MeetingTypeController(IMeetingTypeService service) :
            base(service)
        { }
    }
}