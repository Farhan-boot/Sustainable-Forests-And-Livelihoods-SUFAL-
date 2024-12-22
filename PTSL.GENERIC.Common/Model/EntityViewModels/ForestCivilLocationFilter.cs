namespace PTSL.GENERIC.Common.Model.EntityViewModels;

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

    // Boolean properties to check if the corresponding property is not null and the value is greater than 0
    public bool HasForestCircleId => ForestCircleId.HasValue && ForestCircleId.Value > 0;
    public bool HasForestDivisionId => ForestDivisionId.HasValue && ForestDivisionId.Value > 0;
    public bool HasForestRangeId => ForestRangeId.HasValue && ForestRangeId.Value > 0;
    public bool HasForestBeatId => ForestBeatId.HasValue && ForestBeatId.Value > 0;
    public bool HasForestFcvVcfId => ForestFcvVcfId.HasValue && ForestFcvVcfId.Value > 0;
    public bool HasDivisionId => DivisionId.HasValue && DivisionId.Value > 0;
    public bool HasDistrictId => DistrictId.HasValue && DistrictId.Value > 0;
    public bool HasUpazillaId => UpazillaId.HasValue && UpazillaId.Value > 0;
    public bool HasUnionId => UnionId.HasValue && UnionId.Value > 0;

    public bool HasTake => Take.HasValue && Take.Value > 0;

    public int? iDisplayStart { get; set; }
    public int? iDisplayLength { get; set; }
    public string? sSearch { get; set; }
}

