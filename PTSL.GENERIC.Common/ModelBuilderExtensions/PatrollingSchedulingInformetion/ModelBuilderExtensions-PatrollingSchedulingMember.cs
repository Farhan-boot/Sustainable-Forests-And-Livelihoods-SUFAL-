using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigurePatrollingSchedulingMember(this ModelBuilder builder)
        {
            builder.Entity<PatrollingSchedulingMember>(e =>
            {
                e.ToTable($"{nameof(PatrollingSchedulingMember)}s", "PatrollingScheduling");

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
            });

			builder.Entity<PatrollingSchedulingMember>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}
