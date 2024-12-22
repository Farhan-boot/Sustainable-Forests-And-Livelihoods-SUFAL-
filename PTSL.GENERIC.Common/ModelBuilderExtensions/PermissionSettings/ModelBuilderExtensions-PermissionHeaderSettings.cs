using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.PermissionSettings;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigurePermissionHeaderSettings(this ModelBuilder builder)
        {
            builder.Entity<PermissionHeaderSettings>(ac =>
            {
                ac.ToTable("PermissionHeaderSettings", "PermissionSettings");
                //ac.Property(a => a.CommitteeApprovalBy)
                //   .IsRequired(false);
            });

            //Forest
            builder.Entity<PermissionHeaderSettings>()
                .HasOne(x => x.ForestCircle)
                .WithMany(x => x.PermissionHeaderSettings)
                .HasForeignKey(x => x.ForestCircleId)
                .IsRequired(false);

            builder.Entity<PermissionHeaderSettings>()
               .HasOne(x => x.ForestDivision)
               .WithMany(x => x.PermissionHeaderSettings)
               .HasForeignKey(x => x.ForestDivisionId)
               .IsRequired(false);

            builder.Entity<PermissionHeaderSettings>()
             .HasOne(x => x.ForestRange)
             .WithMany(x => x.PermissionHeaderSettings)
             .HasForeignKey(x => x.ForestRangeId)
             .IsRequired(false);

            builder.Entity<PermissionHeaderSettings>()
              .HasOne(x => x.ForestBeat)
              .WithMany(x => x.PermissionHeaderSettings)
              .HasForeignKey(x => x.ForestBeatId)
              .IsRequired(false);

           builder.Entity<PermissionHeaderSettings>()
            .HasOne(x => x.ForestFcvVcf)
            .WithMany(x => x.PermissionHeaderSettings)
            .HasForeignKey(x => x.ForestFcvVcfId)
            .IsRequired(false);


            // Other Info
            builder.Entity<PermissionHeaderSettings>()
           .HasOne(x => x.UserRole)
           .WithMany(x => x.PermissionHeaderSettings)
           .HasForeignKey(x => x.UserRoleId)
           .IsRequired(false);

            builder.Entity<PermissionHeaderSettings>()
             .HasOne(x => x.User)
             .WithMany(x => x.PermissionHeaderSettings)
             .HasForeignKey(x => x.UserId)
             .IsRequired(false);
        }
    }
}
