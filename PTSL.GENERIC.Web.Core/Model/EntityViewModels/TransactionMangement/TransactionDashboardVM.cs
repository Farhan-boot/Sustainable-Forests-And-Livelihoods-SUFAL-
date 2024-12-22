namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.TransactionMangement;

public class TransactionDashboardVM
{
    public double TotalProjectTarget { get; set; }
    public double TotalProjectExpense { get; set; }
    public double MonthlyExpensePercentage { get; set; }
    public double CurrentProjectTarget { get; set; }
    public double MonthlyProjectExpense { get; set; }
}
