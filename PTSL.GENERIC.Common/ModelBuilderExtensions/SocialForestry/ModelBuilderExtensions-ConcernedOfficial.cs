using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureConcernedOfficial(this ModelBuilder builder)
    {
        builder.Entity<ConcernedOfficial>(e =>
        {
            e.ToTable($"{nameof(ConcernedOfficial)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<ConcernedOfficial>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}