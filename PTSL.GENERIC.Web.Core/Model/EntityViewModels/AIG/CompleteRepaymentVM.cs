namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

public class CompleteRepaymentVM
{
    public long RepaymentId { get; set; }
    public long AigId { get; set; }
    public double FirstSixtyPercentRepaymentAmountReceived { get; set; }
    public double SecondFortyPercentRepaymentAmountReceived { get; set; }
}
