using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigurePlantationSocialForestryBeneficiaryMap(this ModelBuilder builder)
    {
        builder.Entity<PlantationSocialForestryBeneficiaryMap>(e =>
        {
            e.ToTable($"{nameof(PlantationSocialForestryBeneficiaryMap)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<PlantationSocialForestryBeneficiaryMap>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}