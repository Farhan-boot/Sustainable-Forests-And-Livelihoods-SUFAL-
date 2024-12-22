using System;

using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Enum.AccountManagement;

namespace PTSL.GENERIC.Common.Entity.AccountManagement;

public class AccountsUserTagLog : BaseEntity
{
    // Map To Account into User Log
    public long? AccountsId { get; set; }
    public Account? Accounts { get; set; }

    public long? UserId { get; set; }
    public User? Users { get; set; }
    public DateTime CreatedDate { get; set; }
}
