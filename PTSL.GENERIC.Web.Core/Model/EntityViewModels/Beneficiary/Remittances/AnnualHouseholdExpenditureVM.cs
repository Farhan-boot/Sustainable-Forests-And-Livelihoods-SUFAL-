namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

public class AnnualHouseholdExpenditureVM : BaseModel
{
    public long? ExpenditureTypeId { get; set; }
    public ExpenditureTypeVM? ExpenditureType { get; set; }
    public string ExpenditureTypeTxt { get; set; }

    public double ExpenditureCost { get; set; }
    public string ExpenditureRemarks { get; set; }

    public long SurveyId { get; set; }
    public SurveyVM? Survey { get; set; }
}