using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.TransactionMangement;
using PTSL.GENERIC.Common.Model.EntityViewModels.TransactionMangement;
using PTSL.GENERIC.Service.Services.TransactionMangement;

namespace PTSL.GENERIC.Api.Controllers.TransactionMangement
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionFilesController : BaseController<ITransactionFilesService, TransactionFilesVM, TransactionFiles>
    {
        public TransactionFilesController(ITransactionFilesService service) :
            base(service)
        {
        }
    }
}