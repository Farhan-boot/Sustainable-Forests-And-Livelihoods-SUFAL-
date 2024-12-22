using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;

using System;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.PatrollingSchedulingInformetion
{
    public class PatrollingSchedulingVM : BaseModel
    {
        // Forest administration
        public long ForestCircleId { get; set; }
        [SwaggerExclude]
        public ForestCircle? ForestCircle { get; set; }
        public long ForestDivisionId { get; set; }
        [SwaggerExclude]
        public ForestDivision? ForestDivision { get; set; }
        public long ForestRangeId { get; set; }
        [SwaggerExclude]
        public ForestRange? ForestRange { get; set; }
        public long ForestBeatId { get; set; }
        [SwaggerExclude]
        public ForestBeat? ForestBeat { get; set; }
        public long ForestFcvVcfId { get; set; }
        [SwaggerExclude]
        public ForestFcvVcf? ForestFcvVcf { get; set; }

        // Civil administration
        public long DivisionId { get; set; }
        [SwaggerExclude]
        public Division? Division { get; set; }
        public long DistrictId { get; set; }
        [SwaggerExclude]
        public District? District { get; set; }
        public long UpazillaId { get; set; }
        [SwaggerExclude]
        public Upazilla? Upazilla { get; set; }
        public long UnionId { get; set; }
        [SwaggerExclude]
        public Union? Union { get; set; }
        //New
        public long? NgoId { get; set; }
        [SwaggerExclude]
        public Ngo? Ngos { get; set; }

        // Other Info
        public long? FcvId { get; set; }
        public DateTime? Date { get; set; }
        public string? PatrollingDescription { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? PatrollingArea { get; set; }
        public string? AllocatedAmountMonth { get; set; }

        public int TotalParticipants { get; set; }
        public int TotalMale { get; set; }
        public int TotalFemale { get; set; }

        public string? Remark { get; set; }
      
        public List<PatrollingSchedulingParticipentsMapVM>? PatrollingSchedulingParticipentsMaps { get; set; }
       
        public List<PatrollingSchedulingFileVM>? PatrollingSchedulingFiles { get; set; }
    }
}
