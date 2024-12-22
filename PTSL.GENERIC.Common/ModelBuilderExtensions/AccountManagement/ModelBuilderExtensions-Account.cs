using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.AccountManagement;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureAccount(this ModelBuilder builder)
    {
        builder.Entity<Account>(e =>
        {
            e.ToTable($"{nameof(Account)}s", SchemaNames.AccountManagement);

            e.HasIndex(a => a.AccountNumber).IsUnique();
        });

        builder.Entity<Account>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}