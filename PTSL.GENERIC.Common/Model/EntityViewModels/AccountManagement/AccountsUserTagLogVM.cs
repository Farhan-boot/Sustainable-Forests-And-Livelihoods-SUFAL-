using System;

using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Enum.AccountManagement;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;

public class AccountsUserTagLogVM : BaseModel
{
    // Map To Account into User Log
    public long? AccountsId { get; set; }
    [SwaggerExclude]
    public Account? Accounts { get; set; }

    public long? UserId { get; set; }
    [SwaggerExclude]
    public User? Users { get; set; }
    public DateTime CreatedDate { get; set; }
}
