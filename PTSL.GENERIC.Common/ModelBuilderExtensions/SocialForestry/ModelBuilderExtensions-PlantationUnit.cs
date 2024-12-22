using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigurePlantationUnit(this ModelBuilder builder)
    {
        builder.Entity<PlantationUnit>(e =>
        {
            e.ToTable($"{nameof(PlantationUnit)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<PlantationUnit>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}