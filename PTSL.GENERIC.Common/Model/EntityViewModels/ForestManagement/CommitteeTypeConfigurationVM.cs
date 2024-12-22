﻿using PTSL.GENERIC.Common.Entity.Beneficiary;
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
   public class CommitteeTypeConfigurationVM : BaseModel
    {
        public long? FcvOrVcfTypeId { get; set; }
        public string? CommitteeTypeName { get; set; }
        [SwaggerExclude]
        public List<CommitteesConfigurationVM>? CommitteesConfigurations { get; set; }
    }
}