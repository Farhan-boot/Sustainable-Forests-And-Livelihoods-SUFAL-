using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Entity.ForestManagement;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureAccountsUserTagLog(this ModelBuilder builder)
    {
        builder.Entity<AccountsUserTagLog>(ac =>
        {
            ac.ToTable($"{nameof(AccountsUserTagLog)}s", SchemaNames.AccountManagement);

            //ac.Property(a => a.Name)
            //    .HasColumnType("varchar(500)")
            //    .IsRequired(false);
        });

        //Accounts User Tag Log Relations
        builder.Entity<AccountsUserTagLog>()
            .HasOne(x => x.Users)
            .WithMany(x => x.AccountsUserTagLogs)
            .HasForeignKey(x => x.UserId)
            .IsRequired(false);

        builder.Entity<AccountsUserTagLog>()
            .HasOne(x => x.Accounts)
            .WithMany(x => x.AccountsUserTagLogs)
            .HasForeignKey(x => x.AccountsId)
            .IsRequired(false);

        builder.Entity<AccountsUserTagLog>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}