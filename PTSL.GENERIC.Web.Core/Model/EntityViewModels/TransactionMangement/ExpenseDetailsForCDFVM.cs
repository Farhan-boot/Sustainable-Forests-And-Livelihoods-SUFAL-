namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.TransactionMangement;

public class ExpenseDetailsForCDFVM : BaseModel
{
    public long TransactionId { get; set; }
    public TransactionVM? Transaction { get; set; }

    public string? ExpenseScheme { get; set; } // Project or Khat
    public double ExpenseAmount { get; set; }
    public DateTime ExpenseDate { get; set; }

    public string? DocumentFileURL { get; set; }
    public string? Remarks { get; set; }
}
