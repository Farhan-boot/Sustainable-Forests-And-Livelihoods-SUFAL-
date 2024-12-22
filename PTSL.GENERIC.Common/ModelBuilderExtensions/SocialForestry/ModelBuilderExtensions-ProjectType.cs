using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureProjectType(this ModelBuilder builder)
    {
        builder.Entity<ProjectType>(e =>
        {
            e.ToTable($"{nameof(ProjectType)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<ProjectType>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}