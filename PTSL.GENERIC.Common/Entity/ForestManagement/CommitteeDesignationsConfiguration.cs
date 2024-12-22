using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum.ForestManagement;

using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.GENERIC.Common.Entity.ForestManagement
{
   public class CommitteeDesignationsConfiguration : BaseEntity
    {
        public long? CommitteesConfigurationId { get; set; }
        public string? DesignationName { get; set; }
        public CommitteesConfiguration? CommitteesConfiguration { get; set; }
        public List<CommitteeManagement>? CommitteeManagements { get; set; }

        public List<CommitteeManagementMember>? CommitteeManagementMembers { get; set; }
    }
}
