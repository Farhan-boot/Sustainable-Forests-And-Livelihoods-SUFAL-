using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureDistributionFundType(this ModelBuilder builder)
    {
        builder.Entity<DistributionFundType>(e =>
        {
            e.ToTable($"{nameof(DistributionFundType)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<DistributionFundType>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
