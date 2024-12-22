using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureCostType(this ModelBuilder builder)
    {
        builder.Entity<CostType>(e =>
        {
            e.ToTable($"{nameof(CostType)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<CostType>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}