using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount
{
   public class WithdrawAmountInformation : BaseEntity
    {
        // WithdrawAmountInformation
        public long? SavingsAccountId { get; set; }
        public SavingsAccount SavingsAccounts { get; set; }
        public DateTime? WithdrawDate { get; set; }
        public Double? WithdrawAmount { get; set; }
        public string? Remark { get; set; }
        //New Added 
        public long? DfoStatusId { get; set; }
        public string? DfoRemark { get; set; }

        public string? DocumentFileUrl { get; set; }

    }
}
