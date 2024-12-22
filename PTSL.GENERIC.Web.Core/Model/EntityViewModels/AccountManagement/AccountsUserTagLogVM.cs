using PTSL.GENERIC.Web.Core.Helper.Enum.AccountManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AccountManagement;

public class AccountsUserTagLogVM : BaseModel
{
    // Map To Account into User Log
    public long? AccountsId { get; set; }
    public AccountVM? Accounts { get; set; }

    public long? UserId { get; set; }
    public UserVM? Users { get; set; }
    public DateTime CreatedDate { get; set; }
}
