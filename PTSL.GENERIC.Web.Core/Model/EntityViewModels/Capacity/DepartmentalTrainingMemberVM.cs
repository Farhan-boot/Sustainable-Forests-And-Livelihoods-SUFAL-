using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity
{
    public class DepartmentalTrainingMemberVM : BaseModel
    {
        public string? MemberName { get; set; } = string.Empty;
        public string? MemberPhoneNumber { get; set; }
        public Gender MemberGender { get; set; }
        public string? MemberGenderString { get; set; }
        public string? MemberEmail { get; set; }
        public string? MemberNID { get; set; }
        public string? MemberDesignation { get; set; }
        public string? MemberOrganization { get; set; }
        public string? MemberAddress { get; set; }

        public long? EthnicityId { get; set; }
        public EthnicityVM? Ethnicity { get; set; }

        public List<DepartmentalTrainingParticipentsMapVM>? DepartmentalTrainingParticipentsMaps { get; set; }
    }
}
