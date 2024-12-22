using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigurePlantationDamageInformation(this ModelBuilder builder)
    {
        builder.Entity<PlantationDamageInformation>(e =>
        {
            e.ToTable($"{nameof(PlantationDamageInformation)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<PlantationDamageInformation>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}