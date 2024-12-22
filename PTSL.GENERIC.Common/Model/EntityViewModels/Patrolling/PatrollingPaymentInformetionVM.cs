using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.Patrolling;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

using System;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Patrolling
{
    public class PatrollingPaymentInformetionVM : BaseModel
    {
        public long? PatrollingScheduleInformetionId { get; set; }
        [SwaggerExclude]
        public PatrollingScheduleInformetion? PatrollingScheduleInformetions { get; set; }
        public long? SurveyId { get; set; }
        [SwaggerExclude]
        public Survey? Surveys { get; set; }

        public long? OtherPatrollingMemberId { get; set; }
        [SwaggerExclude]
        public OtherPatrollingMember? OtherPatrollingMembers { get; set; }

        public string? ParticipentName { get; set; }
        public long? GenderId { get; set; }
        public string? PhoneNo { get; set; }

        public double? AmountOfHonoraryAllowance { get; set; }
        public string? Remark { get; set; }
    }
}