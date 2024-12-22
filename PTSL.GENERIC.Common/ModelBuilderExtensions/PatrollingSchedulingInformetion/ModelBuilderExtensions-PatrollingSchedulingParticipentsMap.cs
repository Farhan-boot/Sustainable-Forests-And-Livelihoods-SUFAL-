using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigurePatrollingSchedulingParticipentsMap(this ModelBuilder builder)
        {
            builder.Entity<PatrollingSchedulingParticipentsMap>(e =>
            {
                e.ToTable($"{nameof(PatrollingSchedulingParticipentsMap)}s", "PatrollingScheduling");

                e.Property(x => x.SurveyId)
                    .IsRequired(false);

                e.Property(x => x.PatrollingSchedulingMemberId)
                    .IsRequired(false);
            });

            builder.Entity<PatrollingSchedulingParticipentsMap>()
                .HasOne(x => x.Survey)
                .WithMany(x => x.PatrollingSchedulingParticipentsMaps)
                .HasForeignKey(x => x.SurveyId)
                .IsRequired(false);

            builder.Entity<PatrollingSchedulingParticipentsMap>()
                .HasOne(x => x.PatrollingSchedulingMember)
                .WithMany(x => x.PatrollingSchedulingParticipentsMaps)
                .HasForeignKey(x => x.PatrollingSchedulingMemberId)
                .IsRequired(false);

            builder.Entity<PatrollingSchedulingParticipentsMap>()
                .HasOne(x => x.PatrollingScheduling)
                .WithMany(x => x.PatrollingSchedulingParticipentsMaps)
                .HasForeignKey(x => x.PatrollingSchedulingId)
                .IsRequired();

			builder.Entity<PatrollingSchedulingParticipentsMap>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}
