using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.TransactionMangement;

public class FundTypeVM : BaseModel
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }
    public bool IsCdf { get; set; }

    [SwaggerExclude]
    public List<TransactionVM>? Transactions { get; set; }
}
