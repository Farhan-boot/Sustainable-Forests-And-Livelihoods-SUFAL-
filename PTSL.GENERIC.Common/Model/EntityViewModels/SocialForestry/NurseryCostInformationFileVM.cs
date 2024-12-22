using System;

using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;

public class NurseryCostInformationFileVM : BaseModel
{
    public long NurseryCostInformationId { get; set; }
    public NurseryCostInformationVM? CostInformation { get; set; }

    public string FileUrl { get; set; } = string.Empty;
    public FileType FileType { get; set; }
}
