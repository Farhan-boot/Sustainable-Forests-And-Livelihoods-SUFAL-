using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.AIG;

public class GroupLDFInfoFormMember : BaseEntity
{
    public long GroupLDFInfoFormId { get; set; }
    public GroupLDFInfoForm? GroupLDFInfoForm { get; set; }

    public long IndividualLDFInfoFormId { get; set; }
    public IndividualLDFInfoForm? IndividualLDFInfoForm { get; set; }
}
