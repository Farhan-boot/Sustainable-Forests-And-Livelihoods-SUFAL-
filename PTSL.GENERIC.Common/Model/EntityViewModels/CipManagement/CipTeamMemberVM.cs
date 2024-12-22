using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CipManagement;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum.ForestManagement;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.CipManagement
{
   public class CipTeamMemberVM : BaseModel
    {
        //Fk
        public long CipTeamId { get; set; }
        [SwaggerExclude]
        public CipTeamVM? CipTeam { get; set; }

        //Other Info
        public long? CipId { get; set; }
        [SwaggerExclude]
        public CipVM? Cip { get; set; }

        //New Field add
        public string? DesignetionName { get; set; }
        public long? OtherCommitteeMemberId { get; set; }
        [SwaggerExclude]
        public OtherCommitteeMemberVM? OtherCommitteeMember { get; set; }

    }
}
