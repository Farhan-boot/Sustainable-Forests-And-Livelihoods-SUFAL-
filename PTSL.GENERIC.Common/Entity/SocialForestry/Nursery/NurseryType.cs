using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;

public class NurseryType : BaseEntity
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }

    public List<NurseryInformation>? NurseryInformation { get; set; }
}
