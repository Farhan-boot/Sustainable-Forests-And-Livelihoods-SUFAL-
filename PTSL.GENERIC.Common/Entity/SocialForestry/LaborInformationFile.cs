using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestry;

public class LaborInformationFile : BaseEntity
{
    public long LaborInformationId { get; set; }
    public LaborInformation? LaborInformation { get; set; }

    public string FileUrl { get; set; } = string.Empty;
    public FileType FileType { get; set; }
}
