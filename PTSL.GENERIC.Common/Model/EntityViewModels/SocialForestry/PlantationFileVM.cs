using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;

public class PlantationFileVM : BaseModel
{
    public string FileUrl { get; set; } = string.Empty;
    public FileType FileType { get; set; }

    public long NewRaisedPlantationId { get; set; }
    public NewRaisedPlantationVM? NewRaisedPlantation { get; set; }
}
