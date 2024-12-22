using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum.ForestManagement;

using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.GENERIC.Common.Entity.ForestManagement
{
   public class CommitteeManagementMember : BaseEntity
    {
        public string? Name { get; set; }
        public string? NameBn { get; set; }
        //Fk
        public long CommitteeManagementId { get; set; }
        public CommitteeManagement? CommitteeManagement { get; set; }

        //Other Info
        public long? CommitteeDesignationId { get; set; }
        public CommitteeDesignation? CommitteeDesignation { get; set; }

        public long? CommitteeDesignationsConfigurationId { get; set; }
        public CommitteeDesignationsConfiguration? CommitteeDesignationsConfiguration { get; set; }
        
        public long? SurveyId { get; set; }
        public Survey? Survey { get; set; }
        public long? OtherCommitteeMemberId { get; set; }
        public OtherCommitteeMember? OtherCommitteeMember { get; set; }
        
    }
}
