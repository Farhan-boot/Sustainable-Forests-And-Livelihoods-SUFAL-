using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureZoneOrArea(this ModelBuilder builder)
    {
        builder.Entity<ZoneOrArea>(e =>
        {
            e.ToTable($"{nameof(ZoneOrArea)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<ZoneOrArea>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}