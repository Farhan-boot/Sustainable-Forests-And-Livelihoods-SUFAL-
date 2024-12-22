using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureDistributionPercentage(this ModelBuilder builder)
    {
        builder.Entity<DistributionPercentage>(e =>
        {
            e.ToTable($"{nameof(DistributionPercentage)}s", SchemaNames.SocialForestry);
            e.HasKey(o => new { o.DistributionFundTypeId, o.PlantationTypeId });
        });

        builder.Entity<DistributionPercentage>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
