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
   public class CommitteeDesignationsConfigurationVM : BaseModel
    {
        public long? CommitteesConfigurationId { get; set; }
        public string? DesignationName { get; set; }
        [SwaggerExclude]
        public CommitteesConfiguration? CommitteesConfiguration { get; set; }
    }
}
