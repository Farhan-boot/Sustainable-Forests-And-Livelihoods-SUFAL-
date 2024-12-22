using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigurePlantationCauseOfDamage(this ModelBuilder builder)
    {
        builder.Entity<PlantationCauseOfDamage>(e =>
        {
            e.ToTable($"{nameof(PlantationCauseOfDamage)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<PlantationCauseOfDamage>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}