using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Capacity;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureDepartmentalTrainingType(this ModelBuilder builder)
        {
            builder.Entity<DepartmentalTrainingType>(e =>
            {
                e.ToTable($"{nameof(DepartmentalTrainingType)}s", "Capacity");

                e.Property(x => x.Name)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);

                e.Property(x => x.NameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

			builder.Entity<DepartmentalTrainingType>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}
