namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels;

public class ForestCivilLocationFilter
{
    // Forest Administration
    public long? ForestCircleId { get; set; }
    public long? ForestDivisionId { get; set; }
    public long? ForestRangeId { get; set; }
    public long? ForestBeatId { get; set; }
    public long? ForestFcvVcfId { get; set; }

    // Civil Administration
    public long? DivisionId { get; set; }
    public long? DistrictId { get; set; }
    public long? UpazillaId { get; set; }
    public long? UnionId { get; set; }

    public int? Take { get; set; }
}

