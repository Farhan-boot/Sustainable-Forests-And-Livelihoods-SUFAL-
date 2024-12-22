using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureReplantationCostInfo(this ModelBuilder builder)
    {
        builder.Entity<ReplantationCostInfo>(e =>
        {
            e.ToTable($"{nameof(ReplantationCostInfo)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<ReplantationCostInfo>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}