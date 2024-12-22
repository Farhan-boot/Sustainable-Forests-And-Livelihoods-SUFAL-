using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureShareDistribution(this ModelBuilder builder)
    {
        builder.Entity<ShareDistribution>(e =>
        {
            e.ToTable($"{nameof(ShareDistribution)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<ShareDistribution>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
