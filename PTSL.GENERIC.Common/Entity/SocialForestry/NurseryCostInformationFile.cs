using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestry;

public class NurseryCostInformationFile : BaseEntity
{
    public long NurseryCostInformationId { get; set; }
    public NurseryCostInformation? CostInformation { get; set; }

    public string FileUrl { get; set; } = string.Empty;
    public FileType FileType { get; set; }
}
