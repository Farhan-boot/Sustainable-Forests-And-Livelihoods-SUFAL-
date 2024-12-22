using PTSL.GENERIC.Common.Entity.Archive;
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

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Archive
{
   public class RegistrationArchiveVM : BaseModel
    {

        // Forest administration
        public long? ForestCircleId { get; set; }
        [SwaggerExclude]
        public ForestCircleVM? ForestCircle { get; set; }
        public long? ForestDivisionId { get; set; }
        [SwaggerExclude]
        public ForestDivisionVM? ForestDivision { get; set; }
        public long? ForestRangeId { get; set; }
        [SwaggerExclude]
        public ForestRangeVM? ForestRange { get; set; }
        public long? ForestBeatId { get; set; }
        [SwaggerExclude]
        public ForestBeatVM? ForestBeat { get; set; }
        public long? ForestFcvVcfId { get; set; }
        [SwaggerExclude]
        public ForestFcvVcfVM? ForestFcvVcf { get; set; }

        // Civil administration
        public long? DivisionId { get; set; }
        [SwaggerExclude]
        public DivisionVM? Division { get; set; }
        public long? DistrictId { get; set; }
        [SwaggerExclude]
        public DistrictVM? District { get; set; }
        public long? UpazillaId { get; set; }
        [SwaggerExclude]
        public UpazillaVM? Upazilla { get; set; }
        public long? UnionId { get; set; }
        public UnionVM? Union { get; set; }

        //Other Info
        public string? ArchiveName { get; set; }
        public string? DocumentDescription { get; set; }
        public DateTime? UploadDate { get; set; }
        [SwaggerExclude]
        public List<RegistrationArchiveFile>? RegistrationArchiveFiles { get; set; }

    }
}
