using System.Collections.Generic;

using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;

public class SurveyChildsVM : BaseModel
{
    public List<HouseholdMemberVM>? HouseholdMembers { get; set; }
    public List<LandOccupancyVM>? LandOccupancies { get; set; }
    public List<LiveStockVM>? LiveStocks { get; set; }
    public List<AssetVM>? Assets { get; set; }
    public List<ImmovableAssetVM>? ImmovableAssets { get; set; }
    public List<EnergyUseVM>? EnergyUses { get; set; }
    public List<ExistingSkillVM>? ExistingSkills { get; set; }
    public List<GrossMarginIncomeAndCostStatusVM>? GrossMarginIncomeAndCosts { get; set; }
    public List<ManualPhysicalWorkVM>? ManualPhysicalWorks { get; set; }
    public List<NaturalResourcesIncomeAndCostStatusVM>? NaturalResourcesIncomeAndCosts { get; set; }
    public List<OtherIncomeSourceVM>? OtherIncomeSources { get; set; }
    public List<BusinessVM>? Businesses { get; set; }
    public List<AnnualHouseholdExpenditureVM>? AnnualHouseholdExpenditures { get; set; }
    public List<FoodSecurityItemVM>? FoodSecurityItems { get; set; }
    public List<VulnerabilitySituationVM>? VulnerabilitySituations { get; set; }
}
