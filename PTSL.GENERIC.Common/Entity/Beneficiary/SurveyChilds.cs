using System.Collections.Generic;

using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;

public class SurveyChilds : BaseModel
{
    public List<HouseholdMember>? HouseholdMembers { get; set; }
    public List<LandOccupancy>? LandOccupancies { get; set; }
    public List<LiveStock>? LiveStocks { get; set; }
    public List<Asset>? Assets { get; set; }
    public List<ImmovableAsset>? ImmovableAssets { get; set; }
    public List<EnergyUse>? EnergyUses { get; set; }
    public List<ExistingSkill>? ExistingSkills { get; set; }
    public List<GrossMarginIncomeAndCostStatus>? GrossMarginIncomeAndCosts { get; set; }
    public List<ManualPhysicalWork>? ManualPhysicalWorks { get; set; }
    public List<NaturalResourcesIncomeAndCostStatus>? NaturalResourcesIncomeAndCosts { get; set; }
    public List<OtherIncomeSource>? OtherIncomeSources { get; set; }
    public List<Business>? Businesses { get; set; }
    public List<AnnualHouseholdExpenditure>? AnnualHouseholdExpenditures { get; set; }
    public List<FoodSecurityItem>? FoodSecurityItems { get; set; }
    public List<VulnerabilitySituation>? VulnerabilitySituations { get; set; }
}
