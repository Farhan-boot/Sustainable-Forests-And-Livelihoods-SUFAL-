using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureSocialForestryNgo(this ModelBuilder builder)
    {
        builder.Entity<SocialForestryNgo>(e =>
        {
            e.ToTable($"{nameof(SocialForestryNgo)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<SocialForestryNgo>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}