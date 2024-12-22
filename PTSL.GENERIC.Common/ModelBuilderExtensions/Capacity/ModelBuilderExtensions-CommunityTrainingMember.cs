using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Capacity;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureCommunityTrainingMember(this ModelBuilder builder)
        {
            builder.Entity<CommunityTrainingMember>(e =>
            {
                e.ToTable($"{nameof(CommunityTrainingMember)}s", "Capacity");

                e.Property(x => x.MemberName)
                    .HasColumnType("varchar(500)")
                    .IsRequired();

                e.Property(x => x.MemberPhoneNumber)
                    .HasColumnType("varchar(30)")
                    .IsRequired(false);

                e.Property(x => x.MemberGender)
                    .IsRequired();

                e.Property(x => x.MemberAddress)
                    .HasColumnType("varchar(800)")
                    .IsRequired(false);

                e.Property(x => x.MemberNid)
                    .IsRequired(false)
                    .HasDefaultValue(null);
            });

			builder.Entity<CommunityTrainingMember>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}
