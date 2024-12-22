using PTSL.GENERIC.Web.Core.Helper;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.TransactionMangement;

public class TransactionDateVM
{
    public long Id { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public string FromToDate => $"({FromDate.ToShortDateString()})-({ToDate.ToShortDateString()})";
}
