namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

public class LaborInformationVM : BaseModel
{
    public long LaborCostTypeId { get; set; }
    public LaborCostTypeVM? LaborCostType { get; set; }

    public DateTime LaborCostDate { get; set; }
    public int TotalMale { get; set; }
    public int TotalFemale { get; set; }
    public string? Remarks { get; set; }

    public IReadOnlyList<IFormFile>? FormFiles { get; set; }
    public List<LaborInformationFileVM>? LaborInformationFiles { get; set; }

    public int Index { get; set; }
}
