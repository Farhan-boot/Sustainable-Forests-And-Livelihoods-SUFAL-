namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.TransactionMangement;

public class FundTypeVM : BaseModel
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }
    public bool IsCdf { get; set; }

    public List<TransactionVM>? Transactions { get; set; }
}
