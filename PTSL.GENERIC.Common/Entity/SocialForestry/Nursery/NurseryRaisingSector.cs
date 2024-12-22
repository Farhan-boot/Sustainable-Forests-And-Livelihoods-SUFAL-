using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Enum.SocialForestry;

namespace PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;

public class NurseryRaisingSector : BaseEntity
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }
    public RaisingSectorType? RaisingSectorType { get; set; }
    public List<NurseryInformation>? NurseryInformation { get; set; }
}
