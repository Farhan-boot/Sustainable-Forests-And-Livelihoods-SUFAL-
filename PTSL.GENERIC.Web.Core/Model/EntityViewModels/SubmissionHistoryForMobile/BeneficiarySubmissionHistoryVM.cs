using PTSL.GENERIC.Web.Core.Helper.Enum.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ApprovalLog;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.BeneficiarySavingsAccount;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.InternalLoan;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SubmissionHistoryForMobile
{
    public class BeneficiarySubmissionHistoryVM : BaseModel
    {
        public long? SurveyId { get; set; }
        public SurveyVM? Survey { get; set; }
        public long? AIGBasicInformationId { get; set; }

        //public AIGBasicInformationVM? AIGBasicInformation { get; set; }

        public long? InternalLoanInformationId { get; set; }
        public InternalLoanInformationVM? InternalLoanInformation { get; set; }

        public long? SavingsAccountId { get; set; }
        public SavingsAccountVM? SavingsAccount { get; set; }

        public string? FileUrl { get; set; }
    }
}