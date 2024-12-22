using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureNurseryCostInformationFile(this ModelBuilder builder)
    {
        builder.Entity<NurseryCostInformationFile>(e =>
        {
            e.ToTable($"{nameof(NurseryCostInformationFile)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<NurseryCostInformationFile>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}