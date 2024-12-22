using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureLaborInformationFile(this ModelBuilder builder)
    {
        builder.Entity<LaborInformationFile>(e =>
        {
            e.ToTable($"{nameof(LaborInformationFile)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<LaborInformationFile>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}