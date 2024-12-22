using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.ApprovalLog;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.InternalLoan;
using PTSL.GENERIC.Common.Enum.ForestManagement;

using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.GENERIC.Common.Entity.SubmissionHistoryForMobile
{
   public class BeneficiarySubmissionHistory : BaseEntity
    {
        public long? SurveyId { get; set; }
        public Survey? Survey { get; set; }

        public long? AIGBasicInformationId { get; set; }
        public AIGBasicInformation? AIGBasicInformation { get; set; }

        public long? InternalLoanInformationId { get; set; }
        public InternalLoanInformation? InternalLoanInformation { get; set; }

        public long? SavingsAccountId { get; set; }
        public SavingsAccount? SavingsAccount { get; set; }

        public string? FileUrl { get; set; }
    }
}
