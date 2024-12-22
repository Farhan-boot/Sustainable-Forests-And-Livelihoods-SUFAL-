using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigurePlantationTopography(this ModelBuilder builder)
    {
        builder.Entity<PlantationTopography>(e =>
        {
            e.ToTable($"{nameof(PlantationTopography)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<PlantationTopography>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}