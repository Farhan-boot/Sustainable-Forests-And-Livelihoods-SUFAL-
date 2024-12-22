using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureReplantationSocialForestryBeneficiaryMap(this ModelBuilder builder)
    {
        builder.Entity<ReplantationSocialForestryBeneficiaryMap>(e =>
        {
            e.ToTable($"{nameof(ReplantationSocialForestryBeneficiaryMap)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<ReplantationSocialForestryBeneficiaryMap>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}