using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;

public class CommunityTrainingFilterByBeneficiaryVM : ForestCivilLocationFilter
{
    public Gender? Gender { get; set; }
    public string? PhoneNumber { get; set; }
    public string? NID { get; set; }
    public long? NgoId { get; set; }
    public string? BeneficiaryName { get; set; }

    public bool HasGender => Gender.HasValue;
    public bool HasPhoneNumber => string.IsNullOrEmpty(PhoneNumber) == false;
    public bool HasNID => string.IsNullOrEmpty(NID) == false;
    public bool HasNgoId => NgoId.HasValue && NgoId.Value > 0;
}
