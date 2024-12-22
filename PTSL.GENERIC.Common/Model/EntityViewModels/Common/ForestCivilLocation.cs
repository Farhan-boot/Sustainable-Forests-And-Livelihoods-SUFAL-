namespace PTSL.GENERIC.Common.Model.EntityViewModels.Common
{
    public class ForestCivilLocationVM
    {
        // Forest Administration
        public long? ForestCircleId { get; set; }
        public long? ForestDivisionId { get; set; }
        public long? ForestRangeId { get; set; }
        public long? ForestBeatId { get; set; }
        public long? ForestFcvVcfId { get; set; }

        // Civil Administration
        public long? PresentDivisionId { get; set; }
        public long? PresentDistrictId { get; set; }
        public long? PresentUpazillaId { get; set; }
        public long? PresentUnionId { get; set; }

        public int? Take { get; set; }

        // Boolean properties to check if the corresponding property is not null and the value is greater than 0
        public bool HasForestCircleId => ForestCircleId.HasValue && ForestCircleId.Value > 0;
        public bool HasForestDivisionId => ForestDivisionId.HasValue && ForestDivisionId.Value > 0;
        public bool HasForestRangeId => ForestRangeId.HasValue && ForestRangeId.Value > 0;
        public bool HasForestBeatId => ForestBeatId.HasValue && ForestBeatId.Value > 0;
        public bool HasForestFcvVcfId => ForestFcvVcfId.HasValue && ForestFcvVcfId.Value > 0;
        public bool HasDivisionId => PresentDivisionId.HasValue && PresentDivisionId.Value > 0;
        public bool HasDistrictId => PresentDistrictId.HasValue && PresentDistrictId.Value > 0;
        public bool HasUpazillaId => PresentUpazillaId.HasValue && PresentUpazillaId.Value > 0;
        public bool HasUnionId => PresentUnionId.HasValue && PresentUnionId.Value > 0;
        public bool HasTake => Take.HasValue && Take.Value > 0;
    }
}
