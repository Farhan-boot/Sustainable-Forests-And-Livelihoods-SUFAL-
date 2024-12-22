using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Capacity;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureCommunityTrainingType(this ModelBuilder builder)
        {
            builder.Entity<CommunityTrainingType>(e =>
            {
                e.ToTable($"{nameof(CommunityTrainingType)}s", "Capacity");

                e.Property(x => x.Name)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);

                e.Property(x => x.NameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

			builder.Entity<CommunityTrainingType>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}
