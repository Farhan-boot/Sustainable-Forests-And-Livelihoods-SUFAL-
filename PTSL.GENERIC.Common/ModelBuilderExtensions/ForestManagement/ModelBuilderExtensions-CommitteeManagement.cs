using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureCommitteeManagement(this ModelBuilder builder)
        {
            builder.Entity<CommitteeManagement>(ac =>
            {
                ac.ToTable("CommitteeManagement", "BEN");

                ac.Property(a => a.Name)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.NameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);

                ac.Property(a => a.CommitteeApprovalBy)
                   .IsRequired(false);
                ac.Property(a => a.CommitteeApprovalDate)
                 .IsRequired(false);
                ac.Property(a => a.CommitteeApprovalStatus)
                .IsRequired(false);

            });

            //Forest
            builder.Entity<CommitteeManagement>()
                .HasOne(x => x.ForestCircle)
                .WithMany(x => x.CommitteeManagements)
                .HasForeignKey(x => x.ForestCircleId)
                .IsRequired(false);

            builder.Entity<CommitteeManagement>()
               .HasOne(x => x.ForestDivision)
               .WithMany(x => x.CommitteeManagements)
               .HasForeignKey(x => x.ForestDivisionId)
               .IsRequired(false);

            builder.Entity<CommitteeManagement>()
             .HasOne(x => x.ForestRange)
             .WithMany(x => x.CommitteeManagements)
             .HasForeignKey(x => x.ForestRangeId)
             .IsRequired(false);

            builder.Entity<CommitteeManagement>()
              .HasOne(x => x.ForestBeat)
              .WithMany(x => x.CommitteeManagements)
              .HasForeignKey(x => x.ForestBeatId)
              .IsRequired(false);


            //Civil
            builder.Entity<CommitteeManagement>()
                     .HasOne(x => x.Division)
                     .WithMany(x => x.CommitteeManagements)
                     .HasForeignKey(x => x.DivisionId)
                     .IsRequired(false);

            builder.Entity<CommitteeManagement>()
                    .HasOne(x => x.District)
                    .WithMany(x => x.CommitteeManagements)
                    .HasForeignKey(x => x.DistrictId)
                    .IsRequired(false);

            builder.Entity<CommitteeManagement>()
                   .HasOne(x => x.Upazilla)
                   .WithMany(x => x.CommitteeManagements)
                   .HasForeignKey(x => x.UpazillaId)
                   .IsRequired(false);

            builder.Entity<CommitteeManagement>()
                   .HasOne(x => x.Union)
                   .WithMany(x => x.CommitteeManagements)
                   .HasForeignKey(x => x.UnionId)
                   .IsRequired(false);

            builder.Entity<CommitteeManagement>()
             .HasOne(x => x.Ngo)
             .WithMany(x => x.CommitteeManagements)
             .HasForeignKey(x => x.NgoId)
             .IsRequired(false);


          builder.Entity<CommitteeManagement>()
           .HasOne(x => x.ForestFcvVcf)
           .WithMany(x => x.CommitteeManagements)
           .HasForeignKey(x => x.ForestFcvVcfId)
           .IsRequired(false);



          // New Fild Add for new committee logic add
         builder.Entity<CommitteeManagement>()
          .HasOne(x => x.CommitteeTypeConfiguration)
          .WithMany(x => x.CommitteeManagements)
          .HasForeignKey(x => x.CommitteeTypeConfigurationId)
          .IsRequired(false);

         builder.Entity<CommitteeManagement>()
            .HasOne(x => x.CommitteesConfiguration)
            .WithMany(x => x.CommitteeManagements)
            .HasForeignKey(x => x.CommitteesConfigurationId)
            .IsRequired(false);

         builder.Entity<CommitteeManagement>()
            .HasOne(x => x.CommitteeDesignationsConfiguration)
            .WithMany(x => x.CommitteeManagements)
            .HasForeignKey(x => x.CommitteeDesignationsConfigurationId)
            .IsRequired(false);

        }
    }
}
