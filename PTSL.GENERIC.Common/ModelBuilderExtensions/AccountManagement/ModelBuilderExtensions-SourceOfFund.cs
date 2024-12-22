using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.AccountManagement;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureSourceOfFund(this ModelBuilder builder)
    {
        builder.Entity<SourceOfFund>(e =>
        {
            e.ToTable($"{nameof(SourceOfFund)}s", SchemaNames.AccountManagement);
        });

        builder.Entity<SourceOfFund>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}