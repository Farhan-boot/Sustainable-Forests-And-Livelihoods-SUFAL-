namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;

public class NewRaisedPlantationFilter : ForestCivilLocationFilter
{
    public long? ZoneOrAreaId { get; set; }
    public bool HasZoneOrAreaId => ZoneOrAreaId.HasValue && ZoneOrAreaId.Value > 0;
}

