﻿namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

public class ManualPhysicalWorkVM : BaseModel
{
    public long? ManualIncomeSourceTypeId { get; set; }
    public ManualIncomeSourceTypeVM? ManualIncomeSourceType { get; set; }
    public string? ManualIncomeSourceTypeTxt { get; set; }

    public int NoOfMale { get; set; }
    public int NoOfFemale { get; set; }
    public int NoOfActiveMonth { get; set; }
    public int AvgNoPersonActivePerMonth { get; set; }
    public double AvgDailyIncome { get; set; }
    public double TotalPerson { get; set; }
    public double TotalAnnualIncome { get; set; }

    public long SurveyId { get; set; }
    public SurveyVM? Survey { get; set; }
}