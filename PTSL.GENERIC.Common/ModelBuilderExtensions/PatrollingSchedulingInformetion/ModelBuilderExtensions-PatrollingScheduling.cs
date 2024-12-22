using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigurePatrollingScheduling(this ModelBuilder builder)
        {
            builder.Entity<PatrollingScheduling>(e =>
            {
                e.ToTable($"{nameof(PatrollingScheduling)}s", "PatrollingScheduling");

                e.Property(x => x.FcvId)
                     .IsRequired();

                e.Property(x => x.Date)
                   .IsRequired();

                e.Property(x => x.PatrollingDescription)
                 .IsRequired();

                e.Property(x => x.StartTime)
                .IsRequired();

                e.Property(x => x.EndTime)
               .IsRequired();

                e.Property(x => x.PatrollingArea)
                .IsRequired();

                e.Property(x => x.AllocatedAmountMonth)
               .IsRequired();

                
            });

            builder.Entity<PatrollingScheduling>()
                .HasOne(x => x.ForestCircle)
                .WithMany(x => x.PatrollingSchedulings)
                .HasForeignKey(x => x.ForestCircleId)
                .IsRequired();
            builder.Entity<PatrollingScheduling>()
                .HasOne(x => x.ForestDivision)
                .WithMany(x => x.PatrollingSchedulings)
                .HasForeignKey(x => x.ForestDivisionId)
                .IsRequired();
            builder.Entity<PatrollingScheduling>()
                .HasOne(x => x.ForestRange)
                .WithMany(x => x.PatrollingSchedulings)
                .HasForeignKey(x => x.ForestRangeId)
                .IsRequired();
            builder.Entity<PatrollingScheduling>()
                .HasOne(x => x.ForestBeat)
                .WithMany(x => x.PatrollingSchedulings)
                .HasForeignKey(x => x.ForestBeatId)
                .IsRequired();
            builder.Entity<PatrollingScheduling>()
                .HasOne(x => x.ForestFcvVcf)
                .WithMany(x => x.PatrollingSchedulings)
                .HasForeignKey(x => x.ForestFcvVcfId)
                .IsRequired();
            builder.Entity<PatrollingScheduling>()
                .HasOne(x => x.Division)
                .WithMany(x => x.PatrollingSchedulings)
                .HasForeignKey(x => x.DivisionId)
                .IsRequired();
            builder.Entity<PatrollingScheduling>()
                .HasOne(x => x.District)
                .WithMany(x => x.PatrollingSchedulings)
                .HasForeignKey(x => x.DistrictId)
                .IsRequired();
            builder.Entity<PatrollingScheduling>()
                .HasOne(x => x.Upazilla)
                .WithMany(x => x.PatrollingSchedulings)
                .HasForeignKey(x => x.UpazillaId)
                .IsRequired();
            builder.Entity<PatrollingScheduling>()
                .HasOne(x => x.Union)
                .WithMany(x => x.PatrollingSchedulings)
                .HasForeignKey(x => x.UnionId)
                .IsRequired(false);
            builder.Entity<PatrollingScheduling>()
               .HasOne(x => x.Ngos)
               .WithMany(x => x.PatrollingSchedulings)
               .HasForeignKey(x => x.NgoId)
               .IsRequired(false);

			builder.Entity<PatrollingScheduling>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}
