namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

public class OtherIncomeSourceVM : BaseModel
{
    public long? OtherIncomeSourceTypeId { get; set; }
    public OtherIncomeSourceTypeVM? OtherIncomeSourceType { get; set; }
    public string? OtherIncomeSourceTypeTxt { get; set; }

    public double GrossValueOfSales { get; set; }
    public double TotalCashCosts { get; set; }
    public double TotalNetIncome { get; set; }

    public long SurveyId { get; set; }
    public SurveyVM? Survey { get; set; }
}
