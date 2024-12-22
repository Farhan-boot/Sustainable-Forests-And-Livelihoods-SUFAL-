using PTSL.GENERIC.Web.Core.Helper.Enum.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

public class LDFProgressVM : BaseModel
{
    public long AIGBasicInformationId { get; set; }
    public AIGBasicInformationVM? AIGBasicInformation { get; set; }

    public long RepaymentLDFId { get; set; }
    public RepaymentLDFVM? RepaymentLDF { get; set; }

    public DateTime RepaymentStartDate { get; set; }
    public DateTime RepaymentEndDate { get; set; }
    public int RepaymentSerial { get; set; }

    public double ProgressAmount { get; set; }
    public double GrowthPercentage { get; set; }
    public ProgressGrowthStatus GrowthStatus { get; set; }

    public string? ProgressResource { get; set; }
}

