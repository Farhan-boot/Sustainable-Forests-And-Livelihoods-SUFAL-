using PTSL.GENERIC.Common.Entity.AIG;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.AIG;

public class CompleteRepaymentVM
{
    public long RepaymentId { get; set; }
    public long AigId { get; set; }
    public double FirstSixtyPercentRepaymentAmountReceived { get; set; }
    public double SecondFortyPercentRepaymentAmountReceived { get; set; }

    public (bool isOk, string errorMessage) IsValid(RepaymentLDF repayment)
    {
        if (this.FirstSixtyPercentRepaymentAmountReceived < 1)
        {
            return (false, "Amount can not be negative amount");
        }

        if (repayment.SecondFortyPercentRepaymentAmount > 0 && this.SecondFortyPercentRepaymentAmountReceived < 1)
        {
            return (false, "Amount can not be negative amount");
        }

        if (this.FirstSixtyPercentRepaymentAmountReceived > repayment.FirstSixtyPercentRepaymentAmount)
        {
            return (false, "Amount can not be greater than original amount");
        }

        if (this.SecondFortyPercentRepaymentAmountReceived > repayment.SecondFortyPercentRepaymentAmount)
        {
            return (false, "Amount can not be greater than original amount");
        }

        return (true, string.Empty);
    }

    public bool IsPaymentReceivedIsLessThanExpected(double firstSixtyPercentRepaymentAmount, double secondFortyPercentRepaymentAmount)
    {
        return this.FirstSixtyPercentRepaymentAmountReceived < firstSixtyPercentRepaymentAmount
            || this.SecondFortyPercentRepaymentAmountReceived < secondFortyPercentRepaymentAmount;
    }
}
