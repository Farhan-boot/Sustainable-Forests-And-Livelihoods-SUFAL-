using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.Patrolling;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigurePatrollingScheduleInformetion(this ModelBuilder builder)
        {
            builder.Entity<PatrollingScheduleInformetion>(ac =>
            {
                ac.ToTable("PatrollingScheduleInformetion", "Patrolling");

                ac.Property(a => a.FcvId).IsRequired(false);
                ac.Property(a => a.Date).IsRequired(false);
                ac.Property(a => a.PatrollingDescription).IsRequired(false);
                ac.Property(a => a.StartTime).IsRequired(false);
                ac.Property(a => a.EndTime).IsRequired(false);
                ac.Property(a => a.PatrollingArea).IsRequired(false);
                ac.Property(a => a.AllocatedAmountMonth).IsRequired(false);
                ac.Property(a => a.FilePath).IsRequired(false);
                ac.Property(a => a.Remark).IsRequired(false);
            });

         builder.Entity<PatrollingScheduleInformetion>()
                   .HasOne(x => x.ForestCircle)
                   .WithMany(x => x.PatrollingScheduleInformetions)
                   .HasForeignKey(x => x.ForestCircleId)
                   .IsRequired(false);

         builder.Entity<PatrollingScheduleInformetion>()
                 .HasOne(x => x.ForestDivision)
                 .WithMany(x => x.PatrollingScheduleInformetions)
                 .HasForeignKey(x => x.ForestDivisionId)
                 .IsRequired(false);

         builder.Entity<PatrollingScheduleInformetion>()
               .HasOne(x => x.ForestRange)
               .WithMany(x => x.PatrollingScheduleInformetions)
               .HasForeignKey(x => x.ForestRangeId)
               .IsRequired(false);

         builder.Entity<PatrollingScheduleInformetion>()
              .HasOne(x => x.ForestBeat)
              .WithMany(x => x.PatrollingScheduleInformetions)
              .HasForeignKey(x => x.ForestBeatId)
              .IsRequired(false);

         builder.Entity<PatrollingScheduleInformetion>()
             .HasOne(x => x.Division)
             .WithMany(x => x.PatrollingScheduleInformetions)
             .HasForeignKey(x => x.DivisionId)
             .IsRequired(false);

         builder.Entity<PatrollingScheduleInformetion>()
            .HasOne(x => x.District)
            .WithMany(x => x.PatrollingScheduleInformetions)
            .HasForeignKey(x => x.DistrictId)
            .IsRequired(false);

         builder.Entity<PatrollingScheduleInformetion>()
           .HasOne(x => x.Upazilla)
           .WithMany(x => x.PatrollingScheduleInformetions)
           .HasForeignKey(x => x.UpazillaId)
           .IsRequired(false);

         builder.Entity<PatrollingScheduleInformetion>()
           .HasOne(x => x.Ngos)
           .WithMany(x => x.PatrollingScheduleInformetions)
           .HasForeignKey(x => x.NgoId)
           .IsRequired(false);

         builder.Entity<PatrollingScheduleInformetion>()
          .HasOne(x => x.Union)
          .WithMany(x => x.PatrollingScheduleInformetions)
          .HasForeignKey(x => x.UnionId)
          .IsRequired(false);

        }
    }
}
