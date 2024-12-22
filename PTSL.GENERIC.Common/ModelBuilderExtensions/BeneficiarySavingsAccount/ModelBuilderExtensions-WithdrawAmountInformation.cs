using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureWithdrawAmountInformation(this ModelBuilder builder)
        {
            builder.Entity<WithdrawAmountInformation>(ac =>
            {
                ac.ToTable("WithdrawAmountInformation", "BSA");

                ac.Property(a => a.WithdrawDate).IsRequired(false);
                ac.Property(a => a.WithdrawAmount).IsRequired(false);
                ac.Property(a => a.Remark).IsRequired(false);
            });

      builder.Entity<WithdrawAmountInformation>()
       .HasOne(x => x.SavingsAccounts)
       .WithMany(x => x.WithdrawAmountInformations)
       .HasForeignKey(x => x.SavingsAccountId)
       .IsRequired(false);

        }
    }
}
