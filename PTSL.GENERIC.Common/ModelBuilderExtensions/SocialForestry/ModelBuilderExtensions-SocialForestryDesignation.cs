using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureSocialForestryDesignation(this ModelBuilder builder)
    {
        builder.Entity<SocialForestryDesignation>(e =>
        {
            e.ToTable($"{nameof(SocialForestryDesignation)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<SocialForestryDesignation>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}