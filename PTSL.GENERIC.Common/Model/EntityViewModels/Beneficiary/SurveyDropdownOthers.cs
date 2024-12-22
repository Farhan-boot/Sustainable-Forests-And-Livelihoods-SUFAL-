using System.Collections.Generic;
using System.Linq;

using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;

public class SurveyDropdownOthers
{
    public IEnumerable<DropdownLongVM> Ngo { get; set; } = Enumerable.Empty<DropdownLongVM>();
    public IEnumerable<DropdownVM> Gender { get; set; } = Enumerable.Empty<DropdownVM>();
    public IEnumerable<DropdownLongVM> Ethnicity { get; set; } = Enumerable.Empty<DropdownLongVM>();
    public IEnumerable<DropdownLongVM> RelationWithHeadHouseHoldType { get; set; } = Enumerable.Empty<DropdownLongVM>();
    public IEnumerable<DropdownVM> MaritalStatus { get; set; } = Enumerable.Empty<DropdownVM>();
    public IEnumerable<DropdownVM> EducationLevel { get; set; } = Enumerable.Empty<DropdownVM>();
    public IEnumerable<DropdownLongVM> Occupation { get; set; } = Enumerable.Empty<DropdownLongVM>();
    public IEnumerable<DropdownLongVM> BFDAssociation { get; set; } = Enumerable.Empty<DropdownLongVM>();
    public IEnumerable<DropdownLongVM> DisabilityType { get; set; } = Enumerable.Empty<DropdownLongVM>();
    public IEnumerable<DropdownLongVM> SafetyNet { get; set; } = Enumerable.Empty<DropdownLongVM>();
    public IEnumerable<DropdownVM> LandClassification { get; set; } = Enumerable.Empty<DropdownVM>();
    public IEnumerable<DropdownVM> BeneficiaryHouseType { get; set; } = Enumerable.Empty<DropdownVM>();
    public IEnumerable<DropdownLongVM> LiveStockType { get; set; } = Enumerable.Empty<DropdownLongVM>();
    public IEnumerable<DropdownLongVM> AssetType { get; set; } = Enumerable.Empty<DropdownLongVM>();
    public IEnumerable<DropdownLongVM> ImmovableAssetType { get; set; } = Enumerable.Empty<DropdownLongVM>();
    public IEnumerable<DropdownLongVM> EnergyType { get; set; } = Enumerable.Empty<DropdownLongVM>();
    public IEnumerable<DropdownVM> DrinkingWaterResource { get; set; } = Enumerable.Empty<DropdownVM>();
    public IEnumerable<DropdownVM> EducationalInstituteAccessibility { get; set; } = Enumerable.Empty<DropdownVM>();
    public IEnumerable<DropdownVM> SanitationFacilities { get; set; } = Enumerable.Empty<DropdownVM>();
    public IEnumerable<DropdownVM> SkillLevel { get; set; } = Enumerable.Empty<DropdownVM>();
    public IEnumerable<DropdownVM> SatisfactionLevel { get; set; } = Enumerable.Empty<DropdownVM>();
    public IEnumerable<DropdownVM> ForestDependency { get; set; } = Enumerable.Empty<DropdownVM>();
    public IEnumerable<DropdownVM> GenderMF { get; set; } = Enumerable.Empty<DropdownVM>();
    public IEnumerable<DropdownLongVM> ManualIncomeSourceType { get; set; } = Enumerable.Empty<DropdownLongVM>();
    public IEnumerable<DropdownLongVM> NaturalIncomeSourceType { get; set; } = Enumerable.Empty<DropdownLongVM>();
    public IEnumerable<DropdownLongVM> OtherIncomeSourceType { get; set; } = Enumerable.Empty<DropdownLongVM>();
    public IEnumerable<DropdownLongVM> BusinessIncomeSourceType { get; set; } = Enumerable.Empty<DropdownLongVM>();
    public IEnumerable<DropdownLongVM> ExpenditureType { get; set; } = Enumerable.Empty<DropdownLongVM>();
    public IEnumerable<DropdownVM> FoodCondition { get; set; } = Enumerable.Empty<DropdownVM>();
    public IEnumerable<DropdownVM> FoodyPersonInFoodCrisis { get; set; } = Enumerable.Empty<DropdownVM>();
    public IEnumerable<DropdownLongVM> FoodItem { get; set; } = Enumerable.Empty<DropdownLongVM>();
    public IEnumerable<DropdownLongVM> VulnerabilitySituationType { get; set; } = Enumerable.Empty<DropdownLongVM>();
}
