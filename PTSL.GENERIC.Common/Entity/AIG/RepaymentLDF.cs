using System;

using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.AIG;

public class RepaymentLDF : BaseEntity
{
    public long? FirstSixtyPercentageLDFId { get; set; }
    public FirstSixtyPercentageLDF? FirstSixtyPercentageLDF { get; set; }
    public long? SecondFourtyPercentageLDFId { get; set; }
    public SecondFourtyPercentageLDF? SecondFourtyPercentageLDF { get; set; }
    public long AIGBasicInformationId { get; set; }
    public AIGBasicInformation? AIGBasicInformation { get; set; }

    public double FirstSixtyPercentRepaymentAmount { get; set; }
    public double SecondFortyPercentRepaymentAmount { get; set; }

    public double FirstSixtyPercentRepaymentAmountReceived { get; set; }
    public double SecondFortyPercentRepaymentAmountReceived { get; set; }

    public DateTime RepaymentStartDate { get; set; }
    public DateTime RepaymentEndDate { get; set; }
    public int RepaymentSerial { get; set; }

    public bool IsPaymentCompleted { get; set; }
    public DateTime? PaymentCompletedDateTime { get; set; }
    public bool IsPaymentCompletedLate { get; set; }
    public bool IsLocked { get; set; }

    public LDFProgress? LDFProgress { get; set; }
    public List<RepaymentLDFHistory>? RepaymentLDFHistories { get; set; }
    public List<RepaymentLDFFile>? RepaymentLDFFiles { get; set; }

    public (bool isOk, string errorMessage) IsRepaymentValidForCompletePayment()
    {
        if (this.IsLocked) return (false, "Repayment is locked");
        if (this.IsPaymentCompleted) return (false, "Payment is already completed");

        return (true, "");
    }
}
