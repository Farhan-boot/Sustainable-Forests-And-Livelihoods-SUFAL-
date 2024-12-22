using System;
using System.Linq;

using Humanizer;

using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum.AIG;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.AIG;

public class AIGBeneficiaryCheckEligibilityVM
{
    public List<AIGBeneficiaryCheckEligibilityPreviousLoan> AIGBeneficiaryCheckEligibilityPreviousLoans { get; set; } = new List<AIGBeneficiaryCheckEligibilityPreviousLoan>();

    public bool AllPreviousLoanCompleted => AIGBeneficiaryCheckEligibilityPreviousLoans.All(x => x.IsRepaymentClear);
}

public class AIGBeneficiaryCheckEligibilityPreviousLoan
{
    public long AIGBasicInformationId { get; set; }
    public int LDFRound { get; set; }
    public string LDFRoundInWords => LDFRound.Ordinalize();
    public DateTime LoanStartDate { get; set; }
    public DateTime LoanEndDate { get; set; }

    public FirstSixtyPercentageLDF? FirstSixtyPercentageLDF { get; set; }
    public SecondFourtyPercentageLDF? SecondFourtyPercentageLDF { get; set; }
    public double FirstSixtyPercentageLDFLDFAmount => FirstSixtyPercentageLDF?.LDFAmount ?? 0;
    public double SecondFourtyPercentageLDFLDFAmount => SecondFourtyPercentageLDF?.LDFAmount ?? 0;
    public double TotalAllocatedLoanAmount { get; set; }
    public double TotalLoanTakenAmount => Math.Round(FirstSixtyPercentageLDFLDFAmount + SecondFourtyPercentageLDFLDFAmount, 2);
    public double TotalLoanRepaymentAmount { get; set; }

    public BadLoanType BadLoanType { get; set; }
    public double TotalLoanRepaymentsNumber { get; set; }
    public double TotalLoanRepaymentsNotCompletedNumber { get; set; }

    public bool IsRepaymentClear => TotalAllocatedLoanAmount <= TotalLoanRepaymentAmount;
}
