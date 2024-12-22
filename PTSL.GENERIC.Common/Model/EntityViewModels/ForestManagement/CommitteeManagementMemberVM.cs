using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum.ForestManagement;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement
{
   public class CommitteeManagementMemberVM : BaseModel
    {

        public string? Name { get; set; }
        public string? NameBn { get; set; }
        //Fk
        public long CommitteeManagementId { get; set; }
        [SwaggerExclude]
        public CommitteeManagementVM? CommitteeManagement { get; set; }

        //Other Info
        public long? CommitteeDesignationId { get; set; }
        [SwaggerExclude]
        public CommitteeDesignationVM? CommitteeDesignation { get; set; }

        public long? SurveyId { get; set; }
        [SwaggerExclude]
        public SurveyVM? Survey { get; set; }
        public long? OtherCommitteeMemberId { get; set; }
        [SwaggerExclude]
        public OtherCommitteeMemberVM? OtherCommitteeMember { get; set; }

        public long? CommitteeDesignationsConfigurationId { get; set; }
        [SwaggerExclude]
        public CommitteeDesignationsConfiguration? CommitteeDesignationsConfiguration { get; set; }
    }
}
