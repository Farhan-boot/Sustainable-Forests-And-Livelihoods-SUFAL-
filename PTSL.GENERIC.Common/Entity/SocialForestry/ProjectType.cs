using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestry;

// Source of Funding / Name of Project
public class ProjectType : BaseEntity
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }

    public List<NewRaisedPlantation>? NewRaisedPlantations { get; set; }
}
