using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigurePlantationType(this ModelBuilder builder)
    {
        builder.Entity<PlantationType>(e =>
        {
            e.ToTable($"{nameof(PlantationType)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<PlantationType>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}