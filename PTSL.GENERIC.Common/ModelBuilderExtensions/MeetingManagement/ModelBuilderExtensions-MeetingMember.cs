using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.MeetingManagement;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureMeetingMember(this ModelBuilder builder)
        {
            builder.Entity<MeetingMember>(e =>
            {
                e.ToTable($"{nameof(MeetingMember)}s", "Meeting");

                e.Property(x => x.MemberName)
                    .HasColumnType("text")
                    .IsRequired();

                e.Property(x => x.MemberGender)
                    .IsRequired();

                e.Property(x => x.MemberAge)
                    .IsRequired();

                e.Property(x => x.MemberPhone)
                    .HasColumnType("text")
                    .IsRequired();

                e.Property(x => x.MemberAddress)
                    .HasColumnType("text")
                    .IsRequired();
            });

			builder.Entity<MeetingMember>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}
