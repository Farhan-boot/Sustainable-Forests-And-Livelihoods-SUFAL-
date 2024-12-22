using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.BeneficiarySavingsAccount;

public class SavingsAccountFilterVM : ForestCivilLocationFilter
{
    //Extra Filter
    public Gender? Gender { get; set; }
    public string? PhoneNumber { get; set; }
    public string? NID { get; set; }
    public long? EthnicityId { get; set; }
    public long? NgoId { get; set; }
}
