using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Capacity;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureCommunityTrainingParticipentsMap(this ModelBuilder builder)
        {
            builder.Entity<CommunityTrainingParticipentsMap>(e =>
            {
                e.ToTable($"{nameof(CommunityTrainingParticipentsMap)}s", "Capacity");

                e.Property(x => x.SurveyId)
                    .IsRequired(false);

                e.Property(x => x.CommunityTrainingMemberId)
                    .IsRequired(false);
            });

            builder.Entity<CommunityTrainingParticipentsMap>()
                .HasOne(x => x.Survey)
                .WithMany(x => x.CommunityTrainingParticipentsMaps)
                .HasForeignKey(x => x.SurveyId)
                .IsRequired(false);

            builder.Entity<CommunityTrainingParticipentsMap>()
                .HasOne(x => x.CommunityTrainingMember)
                .WithMany(x => x.CommunityTrainingParticipentsMaps)
                .HasForeignKey(x => x.CommunityTrainingMemberId)
                .IsRequired(false);

            builder.Entity<CommunityTrainingParticipentsMap>()
                .HasOne(x => x.CommunityTraining)
                .WithMany(x => x.CommunityTrainingParticipentsMaps)
                .HasForeignKey(x => x.CommunityTrainingId)
                .IsRequired();

			builder.Entity<CommunityTrainingParticipentsMap>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}
