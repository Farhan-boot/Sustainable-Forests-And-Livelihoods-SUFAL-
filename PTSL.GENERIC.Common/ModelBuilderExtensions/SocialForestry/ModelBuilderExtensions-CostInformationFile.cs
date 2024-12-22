using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureCostInformationFile(this ModelBuilder builder)
    {
        builder.Entity<CostInformationFile>(e =>
        {
            e.ToTable($"{nameof(CostInformationFile)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<CostInformationFile>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}