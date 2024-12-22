using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigurePlantationFile(this ModelBuilder builder)
    {
        builder.Entity<PlantationFile>(e =>
        {
            e.ToTable($"{nameof(PlantationFile)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<PlantationFile>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}