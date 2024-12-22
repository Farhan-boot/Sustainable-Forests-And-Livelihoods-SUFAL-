namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

public class GroupLDFInfoFormMemberVM : BaseModel
{
    public long GroupLDFInfoFormId { get; set; }
    public GroupLDFInfoFormVM? GroupLDFInfoForm { get; set; }

    public long IndividualLDFInfoFormId { get; set; }
    public IndividualLDFInfoFormVM? IndividualLDFInfoForm { get; set; }
}
