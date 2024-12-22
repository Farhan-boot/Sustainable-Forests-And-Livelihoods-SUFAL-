using System.Collections.Generic;

using Microsoft.Identity.Client;

using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.ApprovalLog;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.PermissionSettings;

namespace PTSL.GENERIC.Common.Entity
{
    public class BankAccountsInformation : BaseEntity
    {
        public long? UserId { get; set; }
        public User? User { get; set; }

        public long? AccountId { get; set; }
        public Account? Account { get; set; }
    }
}
