using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.Patrolling;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

using System;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Patrolling
{
    public class OtherPatrollingMemberVM : BaseModel
    {
        public string? FullName { get; set; }
        public string? FatherOrSpouse { get; set; }
        public Gender Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? NID { get; set; }
        public string? Address { get; set; }

        // Forest Administration
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

        public long? EthnicityId { get; set; }
        [SwaggerExclude]
        public Ethnicity? Ethnicity { get; set; }
        [SwaggerExclude]
        public List<PatrollingScheduleInformetion>? PatrollingScheduleInformetions { get; set; }

    }
}