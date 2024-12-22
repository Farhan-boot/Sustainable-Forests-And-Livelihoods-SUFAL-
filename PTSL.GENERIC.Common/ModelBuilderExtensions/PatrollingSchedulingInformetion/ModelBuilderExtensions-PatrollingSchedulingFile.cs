using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigurePatrollingSchedulingFile(this ModelBuilder builder)
        {
            builder.Entity<PatrollingSchedulingFile>(e =>
            {
                e.ToTable($"{nameof(PatrollingSchedulingFile)}s", "PatrollingScheduling");

                e.Property(x => x.FileName)
                    .HasColumnType("text")
                    .IsRequired(false);

                e.Property(x => x.FileNameUrl)
                    .HasColumnType("text")
                    .IsRequired(false);

                e.Property(x => x.FileType)
                    .IsRequired();
            });

            builder.Entity<PatrollingSchedulingFile>()
                .HasOne(x => x.PatrollingScheduling)
                .WithMany(x => x.PatrollingSchedulingFiles)
                .HasForeignKey(x => x.PatrollingSchedulingId)
                .IsRequired();

			builder.Entity<PatrollingSchedulingFile>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}
