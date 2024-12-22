using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureSocialForestryBeneficiary(this ModelBuilder builder)
    {
        builder.Entity<SocialForestryBeneficiary>(e =>
        {
            e.ToTable($"{nameof(SocialForestryBeneficiary)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<SocialForestryBeneficiary>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}