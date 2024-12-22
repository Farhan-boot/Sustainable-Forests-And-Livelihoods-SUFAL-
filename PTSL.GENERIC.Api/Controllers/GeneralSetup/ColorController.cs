using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Service.Services.Interface.GeneralSetup;

namespace PTSL.GENERIC.Api.Controllers.GeneralSetup
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : BaseController<IColorService, ColorVM, Color>
    {
        public ColorController(IColorService ColorService) :
            base(ColorService)
        { }

        //Implement here new api, if we want.
    }
}