using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureRealization(this ModelBuilder builder)
    {
        builder.Entity<Realization>(e =>
        {
            e.ToTable($"{nameof(Realization)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<Realization>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}