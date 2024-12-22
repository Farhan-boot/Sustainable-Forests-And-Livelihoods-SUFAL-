using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.Archive;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.CipManagement;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.InternalLoan;
using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Common.Entity.Patrolling;
using PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion;
//using PTSL.GENERIC.Common.Entity.SocialForestry;

using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Entity.GeneralSetup
{
    public class Union : BaseEntity
    {
        public List<SocialForestryTraining.SocialForestryTraining>? SocialForestryTrainings { get; set; }
        public List<SocialForestryMeeting.SocialForestryMeeting>? SocialForestryMeetings { get; set; }
        public string? Name { get; set; }
        public string? NameBn { get; set; }
        public long UpazillaId { get; set; }
        public Upazilla? Upazilla { get; set; }

        public List<CommitteeManagement>? CommitteeManagements { get; set; }
        public List<Cip>? Cips { get; set; }
        public List<AIGBasicInformation>? AIGBasicInformations { get; set; }
        public List<IndividualLDFInfoForm>? IndividualLDFInfoForms { get; set; }
        public List<OtherCommitteeMember>? OtherCommitteeMembers { get; set; }
        public List<OtherLabourMember>? OtherLabourMembers { get; set; }
        public List<LabourDatabase>? LabourDatabases { get; set; }
        public List<Survey>? SurveyPresentUnions { get; set; }
        public List<Survey>? SurveyPermanentUnions { get; set; }
        public List<SavingsAccount>? SavingsAccounts { get; set; }
        public List<CommunityTraining>? CommunityTrainings { get; set; }
        public List<Meeting>? Meetings { get; set; }
        public List<InternalLoanInformation>? InternalLoanInformations { get; set; }
        public List<User>? Users { get; set; }
        public List<GroupLDFInfoForm>? GroupLDFInfoForms { get; set; }
        public List<PatrollingScheduleInformetion>? PatrollingScheduleInformetions { get; set; }
        public List<PatrollingScheduling>? PatrollingSchedulings { get; set; }
        //public List<NewRaisedPlantationUnionMap>? NewRaisedPlantationUnionMaps { get; set; }
        // Archive
        public List<RegistrationArchive>? RegistrationArchives { get; set; }
        // CipManagement
        public List<CipTeam>? CipTeams { get; set; }
    }
}
