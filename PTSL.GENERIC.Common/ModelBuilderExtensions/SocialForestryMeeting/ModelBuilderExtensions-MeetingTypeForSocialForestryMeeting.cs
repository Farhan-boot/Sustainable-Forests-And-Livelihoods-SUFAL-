using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestryMeeting;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureMeetingTypeForSocialForestryMeeting(this ModelBuilder builder)
    {
        builder.Entity<MeetingTypeForSocialForestryMeeting>(e =>
        {
            e.ToTable($"{nameof(MeetingTypeForSocialForestryMeeting)}s", SchemaNames.SocialForestryMeeting);
        });

       
        builder.Entity<MeetingTypeForSocialForestryMeeting>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}