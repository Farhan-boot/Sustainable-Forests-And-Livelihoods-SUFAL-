namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG.Reports;

public class BorrowerPerVillageVM
{
    public string? ForestCircle { get; set; }
    public string? ForestDivision { get; set; }
    public string? ForestRange { get; set; }
    public string? ForestBeat { get; set; }
    public string? ForestFcvVcf { get; set; }

    public long TotalBorrower { get; set; }
    public long TotalVillage { get; set; }
    public double BorrowerPerVillage { get; set; }
}
