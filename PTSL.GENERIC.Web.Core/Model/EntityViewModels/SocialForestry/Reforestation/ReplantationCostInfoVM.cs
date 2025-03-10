namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Reforestation;

public class ReplantationCostInfoVM : BaseModel
{
    public long ReplantationId { get; set; }
    public ReplantationVM? Replantation { get; set; }

    public long CostTypeId { get; set; }
    public CostTypeVM? CostType { get; set; }

    public DateTime CostDate { get; set; }
    public double CostAmount { get; set; }
    public string Remarks { get; set; } = string.Empty;
}
