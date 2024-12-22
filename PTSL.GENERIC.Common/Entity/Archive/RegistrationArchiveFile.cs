using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum.ForestManagement;

using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.GENERIC.Common.Entity.Archive
{
   public class RegistrationArchiveFile : BaseEntity
    {
        //Fk
        public long RegistrationArchiveId { get; set; }
        public RegistrationArchive? RegistrationArchive { get; set; }
        public string? FileName { get; set; }
        public string? DocumentUrl { get; set; }
    }
}
