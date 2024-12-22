namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

public class SecondFourtyPercentageLDFVM : BaseModel
{
    public long AIGBasicInformationId { get; set; }
    public AIGBasicInformationVM? AIGBasicInformation { get; set; }

    public double LDFAmount { get; set; }
    public double ServiceChargeAmount { get; set; }
    public double SecurityChargeAmount { get; set; }
    public DateTime StartDate { get; set; }
    public long StartRepaymentLDFId { get; set; }

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

    public List<RepaymentLDFVM>? RepaymentLDFs { get; set; }
}
