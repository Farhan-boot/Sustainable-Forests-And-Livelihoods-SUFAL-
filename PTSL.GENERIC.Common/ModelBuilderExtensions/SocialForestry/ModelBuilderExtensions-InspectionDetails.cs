using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureInspectionDetails(this ModelBuilder builder)
    {
        builder.Entity<InspectionDetails>(e =>
        {
            e.ToTable($"{nameof(InspectionDetails)}s", SchemaNames.SocialForestry);        
        });

        builder.Entity<InspectionDetails>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}