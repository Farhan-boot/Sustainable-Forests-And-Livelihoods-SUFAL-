
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.BeneficiarySavingsAccount
{
   public class WithdrawAmountInformationVM : BaseModel
    {
        // WithdrawAmountInformation
        public long? SavingsAccountId { get; set; }
        [SwaggerExclude]
        public SavingsAccount? SavingsAccounts { get; set; }
        public DateTime? WithdrawDate { get; set; }
        public Double? WithdrawAmount { get; set; }
        public string? Remark { get; set; }
        //New Added 
        public long? DfoStatusId { get; set; }
        public string? DfoRemark { get; set; }
        public string? DocumentFileUrl { get; set; }
    }
}
