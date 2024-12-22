namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

public class NaturalResourcesIncomeAndCostStatusVM : BaseModel
{
    public long? NaturalIncomeSourceTypeId { get; set; }
    public NaturalIncomeSourceTypeVM? NaturalIncomeSourceType { get; set; }

    public int NoOfMale { get; set; }
    public int NoOfFemale { get; set; }
    public int NoOfActiveMonth { get; set; }
    public double AvgNoPersonActivePerMonth { get; set; }
    public double TotalManDaysForCollection { get; set; }
    public string? Unit { get; set; }
    public double TotalProduced { get; set; }
    public double TotalConsumption { get; set; }
    public double QuantitySold { get; set; }
    public double ValueProduceSold { get; set; }
    public double CostOfActivity { get; set; }
    public double ValueSoldPerActivity { get; set; }
    public double ProducedValueSoldActivity { get; set; }
    public double ActivityPerValueSold { get; set; }
    public double TotalNetIncome { get; set; }

    public long SurveyId { get; set; }
    public SurveyVM? Survey { get; set; }
}
