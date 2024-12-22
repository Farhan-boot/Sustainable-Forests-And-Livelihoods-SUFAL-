using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestry;

public class PlantationFile : BaseEntity
{
    public string FileUrl { get; set; } = string.Empty;
    public FileType FileType { get; set; }

    public long NewRaisedPlantationId { get; set; }
    public NewRaisedPlantation? NewRaisedPlantation { get; set; }
}
