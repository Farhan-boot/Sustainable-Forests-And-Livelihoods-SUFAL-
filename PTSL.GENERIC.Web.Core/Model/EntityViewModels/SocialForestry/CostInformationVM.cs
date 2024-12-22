using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Nursery;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

public class CostInformationVM : BaseModel
{
    public long NewRaisedPlantationId { get; set; }
    public NewRaisedPlantationVM? NewRaisedPlantation { get; set; }
    
    public long NurseryInformationId { get; set; }
    public NurseryInformationVM? NurseryInformationVM { get; set; }

    public long CostTypeId { get; set; }
    public CostTypeVM? CostType { get; set; }
    public DateTime CostDate { get; set; }
    public double CostAmount { get; set; }
    public string Remarks { get; set; } = string.Empty;

    public IReadOnlyList<IFormFile>? FormFiles { get; set; }
    public List<CostInformationFileVM>? CostInformationFiles { get; set; }

    public int Index { get; set; }
}
