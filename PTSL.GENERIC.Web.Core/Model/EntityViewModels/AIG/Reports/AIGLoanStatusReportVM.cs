using PTSL.GENERIC.Web.Core.Helper.Enum.AIG;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG.Reports;

public class AIGLoanStatusReportVM : ForestCivilLocationFilter
{
    public string? BeneficiaryName { get; set; }
    public string? BeneficiaryNid { get; set; }
    public string? BeneficiaryPhoneNumber { get; set; }

    public string? BeneficiaryForestCircle { get; set; }
    public string? BeneficiaryForestDivision { get; set; }
    public string? BeneficiaryForestRange { get; set; }
    public string? BeneficiaryForestBeat { get; set; }
    public string? BeneficiaryForestFcvVcf { get; set; }
    public bool? BeneficiaryForestFcvVcfIsFcv { get; set; }

    public double FirstSixtyPercentageLDFLDFAmount { get; set; }
    public double SecondFourtyPercentageLDFLDFAmount { get; set; }
    public double TotalLoanTakenAmount => FirstSixtyPercentageLDFLDFAmount + SecondFourtyPercentageLDFLDFAmount;
    public double TotalLoanRepaymentAmount { get; set; }

    public double TotalLoanRepaymentsNumber { get; set; }
    public double TotalLoanRepaymentsNotCompletedNumber { get; set; }

    public string? LDFCount { get; set; }
    public BadLoanType? BadLoanType { get; set; }
}

