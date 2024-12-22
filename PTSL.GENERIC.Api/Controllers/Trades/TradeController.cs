using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.Trades;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.Trade;
using PTSL.GENERIC.Service.Services.Beneficiary;
using PTSL.GENERIC.Service.Services.ForestManagement;
using PTSL.GENERIC.Service.Services.Trades;

namespace PTSL.GENERIC.Api.Controllers.Trades
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TradeController : BaseController<ITradeService, TradeVM, Trade>
    {
        public TradeController(ITradeService service) :
            base(service)
        { }

        //Implement here new api, if we want.
    }
}
