using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureLotWiseSellingInformation(this ModelBuilder builder)
    {
        builder.Entity<LotWiseSellingInformation>(e =>
        {
            e.ToTable($"{nameof(LotWiseSellingInformation)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<LotWiseSellingInformation>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}