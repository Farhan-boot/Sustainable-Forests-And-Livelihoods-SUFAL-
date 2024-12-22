using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigurePlantationPlant(this ModelBuilder builder)
    {
        builder.Entity<PlantationPlant>(e =>
        {
            e.ToTable($"{nameof(PlantationPlant)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<PlantationPlant>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}