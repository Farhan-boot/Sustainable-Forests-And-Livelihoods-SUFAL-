namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryTraining;

public class FinancialYearForTrainingVM : BaseModel
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }

    public int StartYear { get; set; }
    public int EndYear { get; set; }
}

