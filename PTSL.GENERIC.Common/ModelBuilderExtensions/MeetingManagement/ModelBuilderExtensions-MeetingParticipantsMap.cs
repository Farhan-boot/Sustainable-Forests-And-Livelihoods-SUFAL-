using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.MeetingManagement;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureMeetingParticipantsMap(this ModelBuilder builder)
        {
            builder.Entity<MeetingParticipantsMap>(e =>
            {
                e.ToTable($"{nameof(MeetingParticipantsMap)}s", "Capacity");

                e.Property(x => x.SurveyId)
                    .IsRequired(false);

                e.Property(x => x.MeetingMemberId)
                    .IsRequired(false);

                e.Property(x => x.MeetingId)
                    .IsRequired();
            });

            builder.Entity<MeetingParticipantsMap>()
                .HasOne(x => x.Survey)
                .WithMany(x => x.MeetingParticipantsMaps)
                .HasForeignKey(x => x.SurveyId)
                .IsRequired(false);

            builder.Entity<MeetingParticipantsMap>()
                .HasOne(x => x.MeetingMember)
                .WithMany(x => x.MeetingParticipantsMaps)
                .HasForeignKey(x => x.MeetingMemberId)
                .IsRequired(false);

            builder.Entity<MeetingParticipantsMap>()
                .HasOne(x => x.Meeting)
                .WithMany(x => x.MeetingParticipantsMaps)
                .HasForeignKey(x => x.MeetingId)
                .IsRequired();

			builder.Entity<MeetingParticipantsMap>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}
