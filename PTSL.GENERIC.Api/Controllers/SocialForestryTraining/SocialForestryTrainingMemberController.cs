using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.SocialForestryTraining;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestryTraining;
using PTSL.GENERIC.Service.Services;
using PTSL.GENERIC.Service.Services.SocialForestryTraining;

namespace PTSL.GENERIC.Api.Controllers.SocialForestryTraining
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SocialForestryTrainingMemberController : BaseController<ISocialForestryTrainingMemberService, SocialForestryTrainingMemberVM, SocialForestryTrainingMember>
    {
        public SocialForestryTrainingMemberController(ISocialForestryTrainingMemberService service) :
            base(service)
        {
        }
    }
}