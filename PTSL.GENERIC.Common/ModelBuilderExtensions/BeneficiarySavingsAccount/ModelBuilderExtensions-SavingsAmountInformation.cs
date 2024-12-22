using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureSavingsAmountInformation(this ModelBuilder builder)
        {
            builder.Entity<SavingsAmountInformation>(ac =>
            {
                ac.ToTable("SavingsAmountInformation", "BSA");

                ac.Property(a => a.SavingsDate).IsRequired(false);
                ac.Property(a => a.SavingsAmount).IsRequired(false);
                ac.Property(a => a.Remark).IsRequired(false);
            });

      builder.Entity<SavingsAmountInformation>()
       .HasOne(x => x.SavingsAccounts)
       .WithMany(x => x.SavingsAmountInformations)
       .HasForeignKey(x => x.SavingsAccountId)
       .IsRequired(false);

        }
    }
}
