using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.Archive;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.CipManagement;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.InternalLoan;
using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Common.Entity.Patrolling;
using PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Common.Entity.PermissionSettings;
//using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Entity.TransactionMangement;

using System;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Entity.Beneficiary
{
    public class ForestFcvVcf : BaseEntity
    {
        public string? Name { get; set; }
        public string? NameBn { get; set; }
        public long ForestBeatId { get; set; }
        public ForestBeat? ForestBeat { get; set; }
        public DateTime? FormedTime { get; set; }

        public List<Cip>? Cips { get; set; }
        public List<CommunityTraining>? CommunityTrainings { get; set; }
        public List<DepartmentalTraining>? DepartmentalTrainings { get; set; }
        public List<Survey>? Surveys { get; set; }
        public bool IsFcv { get; set; }
        public List<OtherCommitteeMember>? OtherCommitteeMembers { get; set; }

        public List<OtherLabourMember>? OtherLabourMembers { get; set; }
        public List<LabourDatabase>? LabourDatabases { get; set; }
        public List<Meeting>? Meetings { get; set; }
        public List<AIGBasicInformation>? AIGBasicInformations { get; set; }
        public List<OtherPatrollingMember>? OtherPatrollingMembers { get; set; }
        public List<IndividualLDFInfoForm>? IndividualLDFInfoForms { get; set; }
        public List<InternalLoanInformation>? InternalLoanInformations { get; set; }
        public List<GroupLDFInfoForm>? GroupLDFInfoForms { get; set; }
        public List<User>? Users { get; set; }

        //PatrollingScheduling
        public List<PatrollingScheduling>? PatrollingSchedulings { get; set; }
        //public List<NewRaisedPlantation>? NewRaisedPlantations { get; set; }
        public List<CommitteeManagement>? CommitteeManagements { get; set; }

        // Archive
        public List<RegistrationArchive>? RegistrationArchives { get; set; }

        // CipManagement
        public List<CipTeam>? CipTeams { get; set; }
        public List<PermissionHeaderSettings>? PermissionHeaderSettings { get; set; }
    }
}