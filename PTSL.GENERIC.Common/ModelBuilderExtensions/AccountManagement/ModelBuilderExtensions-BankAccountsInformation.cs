using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.ForestManagement;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureBankAccountsInformation(this ModelBuilder builder)
    {
        builder.Entity<BankAccountsInformation>(ac =>
        {
            ac.ToTable("BankAccountsInformation", "AccountManagement");
            //ac.Property(a => a.RoleName)
            //    .HasColumnName("RoleName")
            //    .HasColumnType("varchar(100)")
            //    .IsRequired(false);
        });

        builder.Entity<BankAccountsInformation>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        
        builder.Entity<BankAccountsInformation>()
            .HasOne(x => x.User)
            .WithMany(x => x.BankAccountsInformations)
            .HasForeignKey(x => x.UserId)
            .IsRequired(false);

        builder.Entity<BankAccountsInformation>()
           .HasOne(x => x.Account)
           .WithMany(x => x.BankAccountsInformations)
           .HasForeignKey(x => x.AccountId)
           .IsRequired(false);
    }
}
