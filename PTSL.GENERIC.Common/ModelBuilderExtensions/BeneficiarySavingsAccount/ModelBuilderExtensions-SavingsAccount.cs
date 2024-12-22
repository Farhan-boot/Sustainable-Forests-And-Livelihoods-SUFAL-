using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureSavingsAccount(this ModelBuilder builder)
        {
            builder.Entity<SavingsAccount>(ac =>
            {
                ac.ToTable("SavingsAccount", "BSA");

                ac.Property(a => a.FcvId).IsRequired(false);
                ac.Property(a => a.StatusId).IsRequired(false);
                ac.Property(a => a.AccountTypeId).IsRequired(false);
                ac.Property(a => a.AmountLimit).IsRequired(false);
            });

            builder.Entity<SavingsAccount>()
                   .HasOne(x => x.ForestCircle)
                   .WithMany(x => x.SavingsAccounts)
                   .HasForeignKey(x => x.ForestCircleId)
                   .IsRequired(false);

            builder.Entity<SavingsAccount>()
                 .HasOne(x => x.ForestDivision)
                 .WithMany(x => x.SavingsAccounts)
                 .HasForeignKey(x => x.ForestDivisionId)
                 .IsRequired(false);

            builder.Entity<SavingsAccount>()
              .HasOne(x => x.ForestRange)
              .WithMany(x => x.SavingsAccounts)
              .HasForeignKey(x => x.ForestRangeId)
              .IsRequired(false);

          builder.Entity<SavingsAccount>()
          .HasOne(x => x.ForestBeat)
          .WithMany(x => x.SavingsAccounts)
          .HasForeignKey(x => x.ForestBeatId)
          .IsRequired(false);

            builder.Entity<SavingsAccount>()
                 .HasOne(x => x.Division)
                 .WithMany(x => x.SavingsAccounts)
                 .HasForeignKey(x => x.DivisionId)
                 .IsRequired(false);

            builder.Entity<SavingsAccount>()
                  .HasOne(x => x.Division)
                  .WithMany(x => x.SavingsAccounts)
                  .HasForeignKey(x => x.DivisionId)
                  .IsRequired(false);

            builder.Entity<SavingsAccount>()
            .HasOne(x => x.Division)
            .WithMany(x => x.SavingsAccounts)
            .HasForeignKey(x => x.DivisionId)
            .IsRequired(false);

            builder.Entity<SavingsAccount>()
            .HasOne(x => x.District)
            .WithMany(x => x.SavingsAccounts)
            .HasForeignKey(x => x.DistrictId)
            .IsRequired(false);

            builder.Entity<SavingsAccount>()
             .HasOne(x => x.Upazilla)
             .WithMany(x => x.SavingsAccounts)
             .HasForeignKey(x => x.UpazillaId)
             .IsRequired(false);

         builder.Entity<SavingsAccount>()
         .HasOne(x => x.Union)
         .WithMany(x => x.SavingsAccounts)
         .HasForeignKey(x => x.UnionId)
         .IsRequired(false);

            builder.Entity<SavingsAccount>()
             .HasOne(x => x.Ngos)
             .WithMany(x => x.SavingsAccounts)
             .HasForeignKey(x => x.NgoId)
             .IsRequired(false);
            builder.Entity<SavingsAccount>()
            .HasOne(x => x.Survey)
            .WithMany(x => x.SavingsAccounts)
            .HasForeignKey(x => x.SurveyId)
            .IsRequired(false);

        }
    }
}
