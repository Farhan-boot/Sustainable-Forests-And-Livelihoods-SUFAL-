using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureNurseryDistribution(this ModelBuilder builder)
    {
        builder.Entity<NurseryDistribution>(e =>
        {
            e.ToTable($"{nameof(NurseryDistribution)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<NurseryDistribution>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}