using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureInspectionDetailsMap(this ModelBuilder builder)
    {
        builder.Entity<InspectionDetailsMap>(e =>
        {
            e.ToTable($"{nameof(InspectionDetailsMap)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<InspectionDetailsMap>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}