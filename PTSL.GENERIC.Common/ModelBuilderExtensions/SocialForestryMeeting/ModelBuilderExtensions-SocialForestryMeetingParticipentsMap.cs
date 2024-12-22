using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.SocialForestryMeeting;
using PTSL.GENERIC.Common.Entity.SocialForestryTraining;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureSocialForestryMeetingParticipentsMap(this ModelBuilder builder)
    {
        builder.Entity<SocialForestryMeetingParticipentsMap>(e =>
        {
            e.ToTable($"{nameof(SocialForestryMeetingParticipentsMap)}s", SchemaNames.SocialForestryMeeting);

            e.Property(x => x.SocialForestryMeetingMemberId)
                   .IsRequired();
        });

        builder.Entity<SocialForestryMeetingParticipentsMap>()
               .HasOne(x => x.SocialForestryMeetingMember)
               .WithMany(x => x.SocialForestryMeetingParticipentsMaps)
               .HasForeignKey(x => x.SocialForestryMeetingMemberId)
               .IsRequired();

        builder.Entity<SocialForestryMeetingParticipentsMap>()
            .HasOne(x => x.SocialForestryMeeting)
            .WithMany(x => x.SocialForestryMeetingParticipentsMaps)
            .HasForeignKey(x => x.SocialForestryMeetingId)
            .IsRequired();

        builder.Entity<SocialForestryMeetingParticipentsMap>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}