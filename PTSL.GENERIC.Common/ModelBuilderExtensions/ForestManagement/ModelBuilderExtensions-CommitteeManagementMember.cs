using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureCommitteeManagementMember(this ModelBuilder builder)
        {
            builder.Entity<CommitteeManagementMember>(ac =>
            {
                ac.ToTable("CommitteeManagementMember", "BEN");

                ac.Property(a => a.Name)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.NameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);

            });

            builder.Entity<CommitteeManagementMember>()
              .HasOne(x => x.CommitteeManagement)
              .WithMany(x => x.CommitteeManagementMembers)
              .HasForeignKey(x => x.CommitteeManagementId)
              .IsRequired(false);

            //Forest
            //builder.Entity<CommitteeManagementMember>()
            //    .HasOne(x => x.CommitteeDesignation)
            //    .WithMany(x => x.CommitteeManagementMembers)
            //    .HasForeignKey(x => x.CommitteeDesignationId)
            //    .IsRequired(false);

            builder.Entity<CommitteeManagementMember>()
              .HasOne(x => x.CommitteeDesignationsConfiguration)
              .WithMany(x => x.CommitteeManagementMembers)
              .HasForeignKey(x => x.CommitteeDesignationsConfigurationId)
              .IsRequired(false);


            builder.Entity<CommitteeManagementMember>()
               .HasOne(x => x.Survey)
               .WithMany(x => x.CommitteeManagementMembers)
               .HasForeignKey(x => x.SurveyId)
               .IsRequired(false);


            builder.Entity<CommitteeManagementMember>()
             .HasOne(x => x.OtherCommitteeMember)
             .WithMany(x => x.CommitteeManagementMembers)
             .HasForeignKey(x => x.OtherCommitteeMemberId)
             .IsRequired(false);


        }
    }
}
