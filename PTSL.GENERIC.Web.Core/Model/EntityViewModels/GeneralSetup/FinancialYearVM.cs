using PTSL.GENERIC.Web.Core.Model.EntityViewModels.TransactionMangement;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.GeneralSetup;

public class FinancialYearVM : BaseModel
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }

    public int StartYear { get; set; }
    public int EndYear { get; set; }

    public bool IsCurrent { get; set; }

    public List<TransactionVM>? Transactions { get; set; }
}
