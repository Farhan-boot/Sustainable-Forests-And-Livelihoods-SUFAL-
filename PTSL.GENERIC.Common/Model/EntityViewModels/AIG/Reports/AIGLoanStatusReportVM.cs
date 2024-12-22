using System;

using Humanizer;

using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum.AIG;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.AIG.Reports;

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

    public FirstSixtyPercentageLDF? FirstSixtyPercentageLDF { get; set; }
    public SecondFourtyPercentageLDF? SecondFourtyPercentageLDF { get; set; }
    public double FirstSixtyPercentageLDFLDFAmount => FirstSixtyPercentageLDF?.LDFAmount ?? 0;
    public double SecondFourtyPercentageLDFLDFAmount => SecondFourtyPercentageLDF?.LDFAmount ?? 0;
    public double TotalLoanTakenAmount => Math.Round(FirstSixtyPercentageLDFLDFAmount + SecondFourtyPercentageLDFLDFAmount, 2);
    public double TotalLoanRepaymentAmount { get; set; }

    public double TotalLoanRepaymentsNumber { get; set; }
    public double TotalLoanRepaymentsNotCompletedNumber { get; set; }

    public int LDFCountNumber { get; set; }
    public string LDFCount => LDFCountNumber.Ordinalize();
    public BadLoanType? BadLoanType { get; set; }
}

