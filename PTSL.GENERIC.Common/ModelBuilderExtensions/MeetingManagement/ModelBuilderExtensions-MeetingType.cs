using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.MeetingManagement;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureMeetingType(this ModelBuilder builder)
        {
            builder.Entity<MeetingType>(e =>
            {
                e.ToTable($"{nameof(MeetingType)}s", "Meeting");

                e.Property(x => x.Name)
                    .HasColumnType("text")
                    .IsRequired(false);
                e.Property(x => x.NameBn)
                    .HasColumnType("text")
                    .IsRequired(false);
            });

			builder.Entity<MeetingType>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}
