using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureCuttingPlantation(this ModelBuilder builder)
    {
        builder.Entity<CuttingPlantation>(e =>
        {
            e.ToTable($"{nameof(CuttingPlantation)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<CuttingPlantation>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}