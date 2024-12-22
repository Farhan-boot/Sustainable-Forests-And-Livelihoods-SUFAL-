using System.Collections.Generic;

using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;

namespace PTSL.GENERIC.Common.Model
{
    public class BankAccountsInformationVM : BaseModel
    {
        public long? UserId { get; set; }
        public long? AccountId { get; set; }

        [SwaggerExclude]
        public UserVM? User { get; set; }
       
        [SwaggerExclude]
        public AccountVM? Account { get; set; }
    }
}
