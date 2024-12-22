using System.Linq;

using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.Beneficiary;

public class TypeOfHouse : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? NameBn { get; set; }

    public List<Cip> Cips { get; set; } = new List<Cip>();
    public List<Survey> Surveys { get; set; } = new List<Survey>();
}
