using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;

using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Entity.Capacity
{
    public class DepartmentalTrainingMemberVM : BaseModel
    {
        public string MemberName { get; set; } = string.Empty;
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
