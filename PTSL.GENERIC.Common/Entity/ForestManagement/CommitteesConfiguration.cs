using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum.ForestManagement;

using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.GENERIC.Common.Entity.ForestManagement
{
   public class CommitteesConfiguration : BaseEntity
    {
        public long? CommitteeTypeConfigurationId { get; set; }
        public string? CommitteeName { get; set; }
        public CommitteeTypeConfiguration? CommitteeTypeConfiguration { get; set; }
        public List<CommitteeDesignationsConfiguration>? CommitteeDesignationsConfigurations { get; set; }

        public List<CommitteeManagement>? CommitteeManagements { get; set; }
    }
}
