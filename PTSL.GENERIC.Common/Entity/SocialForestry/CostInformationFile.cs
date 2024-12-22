using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestry;

public class CostInformationFile : BaseEntity
{
    public long CostInformationId { get; set; }
    public CostInformation? CostInformation { get; set; }

    public string FileUrl { get; set; } = string.Empty;
    public FileType FileType { get; set; }
}
