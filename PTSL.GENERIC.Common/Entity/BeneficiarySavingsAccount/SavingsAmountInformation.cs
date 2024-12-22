using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount
{
   public class SavingsAmountInformation : BaseEntity
    {
        // SavingsAmountInformation
        public long? SavingsAccountId { get; set; }
        public SavingsAccount SavingsAccounts { get; set; }
        public DateTime? SavingsDate { get; set; }
        public Double? SavingsAmount { get; set; }
        public string? Remark { get; set; }
        public string? DocumentFileUrl { get; set; }
    }
}
