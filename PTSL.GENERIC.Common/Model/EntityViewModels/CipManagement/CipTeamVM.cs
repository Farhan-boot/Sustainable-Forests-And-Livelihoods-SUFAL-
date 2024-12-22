using PTSL.GENERIC.Common.Entity.ApprovalLog;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CipManagement;
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

namespace PTSL.GENERIC.Common.Model.EntityViewModels.CipManagement
{
   public class CipTeamVM : BaseModel
    {
        // Forest administration
        public long ForestCircleId { get; set; }
        [SwaggerExclude]
        public ForestCircleVM? ForestCircle { get; set; }
        public long ForestDivisionId { get; set; }
        [SwaggerExclude]
        public ForestDivisionVM? ForestDivision { get; set; }
        public long ForestRangeId { get; set; }
        [SwaggerExclude]
        public ForestRangeVM? ForestRange { get; set; }
        public long ForestBeatId { get; set; }
        [SwaggerExclude]
        public ForestBeatVM? ForestBeat { get; set; }
        public long ForestFcvVcfId { get; set; }
        [SwaggerExclude]
        public ForestFcvVcfVM? ForestFcvVcf { get; set; }

        // Civil administration
        public long DivisionId { get; set; }
        [SwaggerExclude]
        public DivisionVM? Division { get; set; }
        public long DistrictId { get; set; }
        [SwaggerExclude]
        public DistrictVM? District { get; set; }
        public long UpazillaId { get; set; }
        [SwaggerExclude]
        public UpazillaVM? Upazilla { get; set; }
        public long UnionId { get; set; }
        [SwaggerExclude]
        public UnionVM? Union { get; set; }
        public long NgoId { get; set; }
        [SwaggerExclude]
        public NgoVM? Ngo { get; set; }

        //Other Info
        public string? TeamName { get; set; }
        public string? DocumentUrl { get; set; }
        public string? Remark { get; set; }
        [SwaggerExclude]
        public List<CipTeamMember>? CipTeamMembers { get; set; }

        //Approval Status
        public long? ApprovalStatus { get; set; }
        [SwaggerExclude]
        public List<ApprovalLogForCfm>? ApprovalLogForCfms { get; set; }
    }
}
