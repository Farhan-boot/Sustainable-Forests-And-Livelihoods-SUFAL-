using PTSL.GENERIC.Web.Core.Helper.Enum.AIG;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

public class AIGBeneficiaryCheckEligibilityVM
{
    public List<AIGBeneficiaryCheckEligibilityPreviousLoan> AIGBeneficiaryCheckEligibilityPreviousLoans { get; set; } = new List<AIGBeneficiaryCheckEligibilityPreviousLoan>();

    public bool AllPreviousLoanCompleted { get; set; }
}

public class AIGBeneficiaryCheckEligibilityPreviousLoan
{
    public long AIGBasicInformationId { get; set; }
    public string? LDFRoundInWords { get; set; }
    public DateTime LoanStartDate { get; set; }
    public DateTime LoanEndDate { get; set; }

    public double FirstSixtyPercentageLDFLDFAmount { get; set; }
    public double SecondFourtyPercentageLDFLDFAmount { get; set; }
    public double TotalLoanTakenAmount { get; set; }
    public double TotalLoanRepaymentAmount { get; set; }

    public BadLoanType BadLoanType { get; set; }
    public double TotalLoanRepaymentsNumber { get; set; }
    public double TotalLoanRepaymentsNotCompletedNumber { get; set; }

    public bool IsRepaymentClear { get; set; }
}
