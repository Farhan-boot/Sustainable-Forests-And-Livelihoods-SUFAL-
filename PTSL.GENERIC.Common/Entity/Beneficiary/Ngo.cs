using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.CipManagement;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.InternalLoan;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Common.Entity.Patrolling;
using PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion;
//using PTSL.GENERIC.Common.Entity.SocialForestry;

using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Entity.Beneficiary
{
    public class Ngo : BaseEntity
    {
        public List<SocialForestryMeeting.SocialForestryMeeting>? SocialForestryMeetings { get; set; }
        public string? Name { get; set; }
        public string? NameBn { get; set; }

        public List<long>? ForestCircleIdList { get; set; }
        public List<long>? ForestDivisionIdList { get; set; }

        public List<CommitteeManagement>? CommitteeManagements { get; set; } 
        public List<SavingsAccount>? SavingsAccounts { get; set; }
        public List<AIGBasicInformation>? AIGBasicInformations { get; set; }
        public List<PatrollingScheduleInformetion>? PatrollingScheduleInformetions { get; set; }
        public List<IndividualLDFInfoForm>? IndividualLDFInfoForms { get; set; }
        public List<GroupLDFInfoForm>? GroupLDFInfoForms { get; set; }
        public List<Survey>? Surveys { get; set; }

        //InternalLoanInformation
        public List<InternalLoanInformation>? InternalLoanInformations { get; set; }
        public List<Meeting>? Meetings { get; set; }

        //PatrollingScheduling
        public List<PatrollingScheduling>? PatrollingSchedulings { get; set; }
        //public List<NewRaisedPlantation>? NewRaisedPlantations { get; set; }

        // CipManagement
        public List<CipTeam>? CipTeams { get; set; }
    }
}