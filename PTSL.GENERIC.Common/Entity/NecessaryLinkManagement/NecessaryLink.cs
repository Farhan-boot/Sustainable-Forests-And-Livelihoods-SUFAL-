using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum.ForestManagement;

using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.GENERIC.Common.Entity.NecessaryLinkManagement
{
   public class NecessaryLink : BaseEntity
    {
        public string? LinkTitleEn { get; set; }
        public string? LinkTitleBn { get; set; }
        public string? SiteLink { get; set; }
    }
}
