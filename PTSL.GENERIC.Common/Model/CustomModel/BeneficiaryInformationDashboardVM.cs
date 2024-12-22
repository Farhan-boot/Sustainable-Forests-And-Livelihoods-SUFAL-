using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.CustomModel
{
    public class BeneficiaryInformationDashboardVM : BaseModel
    {
        public BeneficiaryInformationDashboardVM()
        {

        }

        //Survay
        public string? BeneficiaryName { get; set; }
        public string? BeneficiaryProfileURL { get; set; }

        public long? BeneficiaryId { get; set; }
        public string? Nid { get; set; }
        public string? HouseHoldNo { get; set; }
        public string? ForestCircle { get; set; }
        public string? ForestDivision { get; set; }
        public string? ForestRange { get; set; }
        public string? ForestBeat { get; set; }
        public string? ForestFcvVcf { get; set; }

        //Ldf Loan Info
        public long? LdfLoanInformationId { get; set; }
        public bool? LdfIsPaid { get; set; }
        public double? LdfTotalLoan { get; set; }
        public double? LdfTotalRepaid { get; set; }
        public double? LdfTotalRemaining { get; set; }
        public DateTime? LdfPreviousPaymentDate { get; set; }
        public double? LdfPreviousPaymentAmount { get; set; }
        public DateTime? LdfNextPaymentDate { get; set; }
        public double? LdfNextPaymentAMount { get; set; }

        //Internal Loan Info
        public long? InternalLoanInformationId { get; set; }
        public bool? InternalIsPaid { get; set; }
        public double? InternalTotalLoan { get; set; }
        public double? InternalTotalRepaid { get; set; }
        public double? InternalTotalRemaining { get; set; }
        public DateTime? InternalPreviousPaymentDate { get; set; }
        public double? InternalPreviousPaymentAmount { get; set; }
        public DateTime? InternalNextPaymentDate { get; set; }
        public double? InternalNextPaymentAmount { get; set; }

        //Savings Informetion
        //public bool? SavingsIsPaid { get; set; }
        public long? SavingsInformationId { get; set; }
        public double? SavingsTotalSavings { get; set; }
        public double? SavingsTotalWithdraw { get; set; }
        public double? SavingsTotalRemaining { get; set; }
        public DateTime? SavingsPreviousSavingsDate { get; set; }
        public double? SavingsPreviousSavingsAmount { get; set; }
        public DateTime? SavingsNextSavingsDate { get; set; }
        public double? SavingsNextSavingsAmount { get; set; }

        //List Info
        public List<UpcomingMeetingVM> UpcomingMeetings { get; set; } = new List<UpcomingMeetingVM>();
        public List<UpvomingTrainingVM> UpvomingTrainings { get; set; } = new List<UpvomingTrainingVM>();
        public List<NecessaryLinkVM> NecessaryLinks { get; set; } = new List<NecessaryLinkVM>();

    }

    public class UpcomingMeetingVM
    {
        public string? MeetingTitle { get; set; }
        public DateTime? MeetingDate { get; set; }
        public DateTime? MeetingTime { get; set; }
    }

    public class UpvomingTrainingVM
    {
        public string? TrainingTitle { get; set; }
        public DateTime? TrainingDate { get; set; }
        public string? TrainingVenue { get; set; }
    }

    public class NecessaryLinkVM
    {
        public string? LinkTitle { get; set; }
        public string? LinkUrl { get; set; }
    }
}
