using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureDistributedToBeneficiary(this ModelBuilder builder)
    {
        builder.Entity<DistributedToBeneficiary>(e =>
        {
            e.ToTable($"{nameof(DistributedToBeneficiary)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<DistributedToBeneficiary>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
