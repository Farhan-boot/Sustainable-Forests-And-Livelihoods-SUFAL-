using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.ApprovalLog;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.InternalLoan;
using PTSL.GENERIC.Common.Enum.ForestManagement;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SubmissionHistoryForMobile
{
   public class BeneficiarySubmissionHistoryVM : BaseModel
    {
        public long? SurveyId { get; set; }
        [SwaggerExclude]
        public SurveyVM? Survey { get; set; }

        public long? AIGBasicInformationId { get; set; }
        //[SwaggerExclude]
        //public AIGBasicInformationVM? AIGBasicInformation { get; set; }

        public long? InternalLoanInformationId { get; set; }
        [SwaggerExclude]
        public InternalLoanInformationVM? InternalLoanInformation { get; set; }

        public long? SavingsAccountId { get; set; }
        [SwaggerExclude]
        public SavingsAccountVM? SavingsAccount { get; set; }

        public string? FileUrl { get; set; }

    }
}
