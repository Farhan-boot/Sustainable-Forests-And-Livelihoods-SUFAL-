using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;

public class DefaultRealizationDataVM
{
    public string PlantationId { get; set; } = string.Empty;
    public int TotalNumberOfLots { get; set; }
    public int NumberOfSoldLots { get; set; }
    public int RemainingNumberOfLots { get; set; }

    public double TotalRealizedAmount { get; set; }
    public double TotalUnrealizedAmount { get; set; }

    public List<RealizationVM> Realizations { get; set; } = new List<RealizationVM>();
    public List<Realization> RealizationEntities { get; set; } = new List<Realization>();
}
