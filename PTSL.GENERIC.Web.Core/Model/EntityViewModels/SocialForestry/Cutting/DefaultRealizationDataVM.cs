namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Cutting;

public class DefaultRealizationDataVM
{
    public string PlantationId { get; set; } = string.Empty;
    public int TotalNumberOfLots { get; set; }
    public int NumberOfSoldLots { get; set; }
    public int RemainingNumberOfLots { get; set; }

    public double TotalRealizedAmount { get; set; }
    public double TotalUnrealizedAmount { get; set; }

    public List<RealizationVM> Realizations { get; set; } = new List<RealizationVM>();
}
