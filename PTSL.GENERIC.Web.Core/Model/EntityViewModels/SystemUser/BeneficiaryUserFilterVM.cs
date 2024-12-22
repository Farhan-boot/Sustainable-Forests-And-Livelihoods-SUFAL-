using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SystemUser;

public class BeneficiaryUserFilterVM : ForestCivilLocationFilter
{
    public Gender? Gender { get; set; }
    public string? PhoneNumber { get; set; }
    public string? NID { get; set; }
    public long? EthnicityId { get; set; }
    public long? NgoId { get; set; }
    public bool IsBeneficiaryUser { get; set; }

    public bool HasGender => Gender.HasValue;
}
