using System;

using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.AIG;

public class FirstSixtyPercentageLDF : BaseEntity
{
    public long AIGBasicInformationId { get; set; }
    public AIGBasicInformation? AIGBasicInformation { get; set; }

    public bool HasGrace { get; set; }
    public int GraceMonth { get; set; }

    public double LDFAmount { get; set; } // 60 percent of allocated loan
    public double ServiceChargeAmount { get; set; }
    public double SecurityChargeAmount { get; set; }

    // Percentage
    public double ServiceChargePercentage { get; set; }
    public double SecurityChargePercentage { get; set; }

    // Land Marks
    public bool IsAgreeToInvestInOwnIncomeActivities { get; set; }
    public bool ShallAdhereTheCOM { get; set; }
    public bool IsAttendedEightyPercentageOfMeetings { get; set; }
    public bool IsFirstInstallmentIsCertifiedBySocialAuditCommittee { get; set; }
    public bool HasBankAccountInHisOwnName { get; set; }
    public bool IsPayingRegularIncomingInstallments { get; set; }
    public bool IsAgreedToKeepIncomeAndExpenditureFund { get; set; }

    public DateTime DisbursementDate { get; set; }

    public List<RepaymentLDF>? RepaymentLDFs { get; set; }

    public FirstSixtyPercentageLDF SetLDFAmountAndServiceCharge(double totalAllocatedLoan)
    {
        LDFAmount = totalAllocatedLoan * 0.6;
        ServiceChargeAmount = (LDFAmount * ServiceChargePercentage) / 100;

        return this;
    }

    public FirstSixtyPercentageLDF SetLDFAmountAndSecurityCharge(double totalAllocatedLoan)
    {
        LDFAmount = totalAllocatedLoan * 0.6;
        SecurityChargeAmount = (LDFAmount * SecurityChargePercentage) / 100;

        return this;
    }

    public FirstSixtyPercentageLDF SetServiceCharge()
    {
        ServiceChargeAmount = (LDFAmount * ServiceChargePercentage) / 100;

        return this;
    }

    public FirstSixtyPercentageLDF SetSecurityCharge()
    {
        SecurityChargeAmount = (LDFAmount * SecurityChargePercentage) / 100;

        return this;
    }
}
