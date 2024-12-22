using System;

using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.AIG;

public class SecondFourtyPercentageLDF : BaseEntity
{
    public long AIGBasicInformationId { get; set; }
    public AIGBasicInformation? AIGBasicInformation { get; set; }

    public double LDFAmount { get; set; }  // 60 percent of allocated loan
    public double ServiceChargeAmount { get; set; }
    public double SecurityChargeAmount { get; set; }
    public DateTime StartDate { get; set; }
    public long? StartRepaymentLDFId { get; set; }

    // Percentage
    public double ServiceChargePercentage { get; set; }
    public double SecurityChargePercentage { get; set; }

    // Land Marks
    public bool HasInvestedSeventyPercentageOfTheLoan { get; set; }
    public bool IsPaidTheLoanInstallmentThreeConsecutiveMonths { get; set; }
    public bool IsAttendedRegularMeetings { get; set; }
    public bool DidNotBreakTheTenPrinciples { get; set; }
    public bool IsLivelihoodDevelopmentFundCertifiedAndApproved { get; set; }
    public bool IncomeExpenditureFundLoansUpdatedAndCertified { get; set; }

    public DateTime DisbursementDate { get; set; }
    public List<RepaymentLDF>? RepaymentLDFs { get; set; }

    public SecondFourtyPercentageLDF SetLDFAmountAndServiceCharge(double totalAllocatedLoan)
    {
        LDFAmount = totalAllocatedLoan * 0.4;
        ServiceChargeAmount = (LDFAmount * ServiceChargePercentage) / 100;

        return this;
    }

    public SecondFourtyPercentageLDF SetLDFAmountAndSecurityCharge(double totalAllocatedLoan)
    {
        LDFAmount = totalAllocatedLoan * 0.4;
        SecurityChargeAmount = (LDFAmount * SecurityChargePercentage) / 100;

        return this;
    }

    public SecondFourtyPercentageLDF SetServiceCharge()
    {
        ServiceChargeAmount = (LDFAmount * ServiceChargePercentage) / 100;

        return this;
    }

    public SecondFourtyPercentageLDF SetSecurityCharge()
    {
        SecurityChargeAmount = (LDFAmount * SecurityChargePercentage) / 100;

        return this;
    }
}
