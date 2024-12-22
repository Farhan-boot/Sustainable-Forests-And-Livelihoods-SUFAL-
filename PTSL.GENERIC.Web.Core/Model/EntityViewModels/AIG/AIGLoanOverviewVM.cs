namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

public class AIGLoanOverviewVM
{
    public long TotalLoan { get; set; }
    public double RegularPercentage { get; set; }
    public double UnderObservationPercentage { get; set; }
    public double InferiorWealthPercentage { get; set; }
    public double SuspiciousWealthPercentage { get; set; }
    public double EvilWealthPercentage { get; set; }
}
