using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum.ForestManagement;

using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.GENERIC.Common.Entity.CipManagement
{
   public class CipTeamMember : BaseEntity
    {
        //Fk
        public long CipTeamId { get; set; }
        public CipTeam? CipTeam { get; set; }

        //Other Info
        public long? CipId { get; set; }
        public Cip? Cip { get; set; }

        //New Field add
        public string? DesignetionName { get; set; }
        public long? OtherCommitteeMemberId { get; set; }
        public OtherCommitteeMember? OtherCommitteeMember { get; set; }

    }
}
