using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureConcernedOfficialMap(this ModelBuilder builder)
    {
        builder.Entity<ConcernedOfficialMap>(e =>
        {
            e.ToTable($"{nameof(ConcernedOfficialMap)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<ConcernedOfficialMap>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}