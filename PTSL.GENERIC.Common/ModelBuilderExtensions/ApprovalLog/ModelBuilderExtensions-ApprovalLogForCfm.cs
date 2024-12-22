using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.ApprovalLog;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.PermissionSettings;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureApprovalLogForCfm(this ModelBuilder builder)
        {
          builder.Entity<ApprovalLogForCfm>(ac =>
            {
                ac.ToTable("ApprovalLogForCfm", "ApprovalLog");
                //ac.Property(a => a.CommitteeApprovalBy)
                //.IsRequired(false);
            });

            //Approval Log For Cfm

          builder.Entity<ApprovalLogForCfm>()
                .HasOne(x => x.Sender)
                .WithMany(x => x.ApprovalLogForCfmsSender)
                .HasForeignKey(x => x.SenderId)
                .IsRequired(false);

          builder.Entity<ApprovalLogForCfm>()
               .HasOne(x => x.Receiver)
               .WithMany(x => x.ApprovalLogForCfmsReceiver)
               .HasForeignKey(x => x.ReceiverId)
               .IsRequired(false);

          builder.Entity<ApprovalLogForCfm>()
             .HasOne(x => x.Cip)
             .WithMany(x => x.ApprovalLogForCfms)
             .HasForeignKey(x => x.CipId)
             .IsRequired(false);

          builder.Entity<ApprovalLogForCfm>()
              .HasOne(x => x.CipTeam)
              .WithMany(x => x.ApprovalLogForCfms)
              .HasForeignKey(x => x.CipTeamId)
              .IsRequired(false);

          builder.Entity<ApprovalLogForCfm>()
            .HasOne(x => x.BeneficiaryProfile)
            .WithMany(x => x.ApprovalLogForCfms)
            .HasForeignKey(x => x.BeneficiaryProfileId)
            .IsRequired(false);

          builder.Entity<ApprovalLogForCfm>()
           .HasOne(x => x.CommitteeManagement)
           .WithMany(x => x.ApprovalLogForCfms)
           .HasForeignKey(x => x.CommitteeManagementId)
           .IsRequired(false);

           builder.Entity<ApprovalLogForCfm>()
             .HasOne(x => x.InternalLoanInformation)
             .WithMany(x => x.ApprovalLogForCfms)
             .HasForeignKey(x => x.InternalLoanInformationId)
             .IsRequired(false);

           //New Field Add
            builder.Entity<ApprovalLogForCfm>()
               .HasOne(x => x.SenderRole)
               .WithMany(x => x.ApprovalLogForCfmsSenderRole)
               .HasForeignKey(x => x.SenderRoleId)
               .IsRequired(false);

            builder.Entity<ApprovalLogForCfm>()
             .HasOne(x => x.ReceiverRole)
             .WithMany(x => x.ApprovalLogForCfmsReceiverRole)
             .HasForeignKey(x => x.ReceiverRoleId)
             .IsRequired(false);

        }
    }
}
