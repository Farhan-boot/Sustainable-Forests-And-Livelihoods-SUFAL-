using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Trade
{
    public class TradeVM : BaseModel
    {
        public string? Name { get; set; }
        public string? NameBn { get; set; }
    }
}