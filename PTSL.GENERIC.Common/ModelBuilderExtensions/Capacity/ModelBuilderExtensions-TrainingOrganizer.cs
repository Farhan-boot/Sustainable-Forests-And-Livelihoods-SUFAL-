using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Capacity;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureTrainingOrganizer(this ModelBuilder builder)
        {
            builder.Entity<TrainingOrganizer>(e =>
            {
                e.ToTable($"{nameof(TrainingOrganizer)}s", "Capacity");

                e.Property(x => x.Name)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);

                e.Property(x => x.NameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

			builder.Entity<TrainingOrganizer>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}
