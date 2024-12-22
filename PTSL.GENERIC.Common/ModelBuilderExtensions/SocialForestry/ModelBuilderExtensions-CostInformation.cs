using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureCostInformation(this ModelBuilder builder)
    {
        builder.Entity<CostInformation>(e =>
        {
            e.ToTable($"{nameof(CostInformation)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<CostInformation>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}