using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestryTraining;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureEventTypeForTraining(this ModelBuilder builder)
    {
        builder.Entity<EventTypeForTraining>(e =>
        {
            e.ToTable($"{nameof(EventTypeForTraining)}s", SchemaNames.SocialForestryTraining);
        });

        builder.Entity<EventTypeForTraining>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}