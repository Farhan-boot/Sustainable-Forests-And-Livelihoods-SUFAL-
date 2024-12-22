using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;

namespace PTSL.GENERIC.Common.Entity.AIG;

public class GroupLDFInfoFormMemberVM : BaseModel
{
    public long GroupLDFInfoFormId { get; set; }
    [SwaggerExclude]
    public GroupLDFInfoFormVM? GroupLDFInfoForm { get; set; }

    public long IndividualLDFInfoFormId { get; set; }
    [SwaggerExclude]
    public IndividualLDFInfoFormVM? IndividualLDFInfoForm { get; set; }
}
