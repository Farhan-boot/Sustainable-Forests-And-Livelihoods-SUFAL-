namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG.Reports;

public class BorrowerCoverageVM
{
    public string? ForestCircle { get; set; }
    public string? ForestDivision { get; set; }
    public string? ForestRange { get; set; }
    public string? ForestBeat { get; set; }
    public string? ForestFcvVcf { get; set; }

    public long CurrentBorrower { get; set; }
    public long CurrentMember { get; set; }
    public double BorrowerPerVillage { get; set; }
}
