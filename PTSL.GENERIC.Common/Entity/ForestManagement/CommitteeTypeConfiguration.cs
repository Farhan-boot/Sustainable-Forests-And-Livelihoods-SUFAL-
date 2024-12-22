using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum.ForestManagement;

using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.GENERIC.Common.Entity.ForestManagement
{
   public class CommitteeTypeConfiguration : BaseEntity
    {
        public long? FcvOrVcfTypeId { get; set; }
        public string? CommitteeTypeName { get; set; }
        public List<CommitteesConfiguration>? CommitteesConfigurations { get; set; }
        public List<CommitteeManagement>? CommitteeManagements { get; set; }
    }
}
