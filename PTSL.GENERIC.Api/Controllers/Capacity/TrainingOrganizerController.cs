using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Service.Services.Interface.Capacity;

namespace PTSL.GENERIC.Api.Controllers.Capacity
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingOrganizerController : BaseController<ITrainingOrganizerService, TrainingOrganizerVM, TrainingOrganizer>
    {
        public TrainingOrganizerController(ITrainingOrganizerService service) :
            base(service)
        { }
    }
}
