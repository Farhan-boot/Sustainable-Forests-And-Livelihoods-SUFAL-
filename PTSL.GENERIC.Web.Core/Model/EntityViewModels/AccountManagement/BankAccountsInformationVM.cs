using PTSL.GENERIC.Web.Core.Helper.Enum.AccountManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AccountManagement;

public class BankAccountsInformationVM : BaseModel
{
    public long? UserId { get; set; }
    public long? AccountId { get; set; }

    public UserVM? User { get; set; }

    public AccountVM? Account { get; set; }
}
