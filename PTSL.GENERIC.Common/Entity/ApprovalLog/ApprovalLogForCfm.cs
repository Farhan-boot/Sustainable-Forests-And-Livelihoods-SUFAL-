using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CipManagement;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.InternalLoan;
using PTSL.GENERIC.Common.Enum.ApprovalLog;
using PTSL.GENERIC.Common.Enum.ForestManagement;

using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.GENERIC.Common.Entity.ApprovalLog
{
   public class ApprovalLogForCfm : BaseEntity
    {
        public long? SenderId { get; set; }
        public User? Sender { get; set; }

        public long? ReceiverId { get; set; }
        public User? Receiver { get; set; }

        public DateTime? SendingDate { get; set; }
        public DateTime? SendingTime { get; set; }
        public string? Remark { get; set; }

        //Other Table Relation
        public long? CipId { get; set; }
        public Cip? Cip { get; set; }
        public long? CipTeamId { get; set; }
        public CipTeam? CipTeam { get; set; }
        public long? BeneficiaryProfileId { get; set; }
        public Survey? BeneficiaryProfile { get; set; }
        public long? CommitteeManagementId { get; set; }
        public CommitteeManagement? CommitteeManagement { get; set; }
        public long? InternalLoanInformationId { get; set; }
        public InternalLoanInformation? InternalLoanInformation { get; set; }
        public ApprovalLogForCfmStatus? ApprovalStatusId { get; set; }

        //New Fild add
        public long? SenderRoleId { get; set; }
        public UserRole? SenderRole { get; set; }
        public long? ReceiverRoleId { get; set; }
        public UserRole? ReceiverRole { get; set; }


    }
}
