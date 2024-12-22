using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureLaborCostType(this ModelBuilder builder)
    {
        builder.Entity<LaborCostType>(e =>
        {
            e.ToTable($"{nameof(LaborCostType)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<LaborCostType>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}