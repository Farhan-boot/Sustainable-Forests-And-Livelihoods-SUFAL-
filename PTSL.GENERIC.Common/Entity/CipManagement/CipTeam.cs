﻿using PTSL.GENERIC.Common.Entity.ApprovalLog;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum.ForestManagement;

using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.GENERIC.Common.Entity.CipManagement
{
   public class CipTeam : BaseEntity
    {

        // Forest administration
        public long ForestCircleId { get; set; }
        public ForestCircle? ForestCircle { get; set; }
        public long ForestDivisionId { get; set; }
        public ForestDivision? ForestDivision { get; set; }
        public long ForestRangeId { get; set; }
        public ForestRange? ForestRange { get; set; }
        public long ForestBeatId { get; set; }
        public ForestBeat? ForestBeat { get; set; }
        public long ForestFcvVcfId { get; set; }
        public ForestFcvVcf? ForestFcvVcf { get; set; }

        // Civil administration
        public long DivisionId { get; set; }
        public Division? Division { get; set; }
        public long DistrictId { get; set; }
        public District? District { get; set; }
        public long UpazillaId { get; set; }
        public Upazilla? Upazilla { get; set; }
        public long UnionId { get; set; }
        public Union? Union { get; set; }
        public long NgoId { get; set; }
        public Ngo? Ngo { get; set; }

        //Other Info
        public string? TeamName { get; set; }
        public string? DocumentUrl { get; set; }
        public string? Remark { get; set; }
        public List<CipTeamMember>? CipTeamMembers { get; set; }

        //Approval Status
        public long? ApprovalStatus { get; set; }

        public List<ApprovalLogForCfm>? ApprovalLogForCfms { get; set; }

    }
}