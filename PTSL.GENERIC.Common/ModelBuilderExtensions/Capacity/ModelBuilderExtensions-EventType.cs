using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Capacity;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureEventType(this ModelBuilder builder)
        {
            builder.Entity<EventType>(e =>
            {
                e.ToTable($"{nameof(EventType)}s", "Capacity");

                e.Property(x => x.Name)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);

                e.Property(x => x.NameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

			builder.Entity<EventType>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}
