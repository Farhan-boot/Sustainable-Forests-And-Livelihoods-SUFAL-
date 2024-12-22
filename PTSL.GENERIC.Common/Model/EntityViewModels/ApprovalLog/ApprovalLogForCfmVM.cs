using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CipManagement;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.InternalLoan;
using PTSL.GENERIC.Common.Enum.ApprovalLog;
using PTSL.GENERIC.Common.Enum.ForestManagement;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.ApprovalLog
{
   public class ApprovalLogForCfmVM : BaseModel
    {
        public long? SenderId { get; set; }
        [SwaggerExclude]
        public User? Sender { get; set; }

        public long? ReceiverId { get; set; }
        [SwaggerExclude]
        public User? Receiver { get; set; }

        public DateTime? SendingDate { get; set; }
        public DateTime? SendingTime { get; set; }
        public string? Remark { get; set; }

        //Other Table Relation
        public long? CipId { get; set; }
        [SwaggerExclude]
        public Cip? Cip { get; set; }
        public long? CipTeamId { get; set; }
        [SwaggerExclude]
        public CipTeam? CipTeam { get; set; }
        public long? BeneficiaryProfileId { get; set; }
        [SwaggerExclude]
        public Survey? BeneficiaryProfile { get; set; }
        public long? CommitteeManagementId { get; set; }
        [SwaggerExclude]
        public CommitteeManagement? CommitteeManagement { get; set; }
        public long? InternalLoanInformationId { get; set; }
        [SwaggerExclude]
        public InternalLoanInformation? InternalLoanInformation { get; set; }
        public ApprovalLogForCfmStatus? ApprovalStatusId { get; set; }

        //New Fild add
        public long? SenderRoleId { get; set; }
        public UserRole? SenderRole { get; set; }
        public long? ReceiverRoleId { get; set; }
        public UserRole? ReceiverRole { get; set; }
    }
}
