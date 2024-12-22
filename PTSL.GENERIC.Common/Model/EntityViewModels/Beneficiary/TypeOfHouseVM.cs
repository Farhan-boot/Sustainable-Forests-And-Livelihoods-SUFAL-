using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;

public class TypeOfHouseVM : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string? NameBn { get; set; }
}
