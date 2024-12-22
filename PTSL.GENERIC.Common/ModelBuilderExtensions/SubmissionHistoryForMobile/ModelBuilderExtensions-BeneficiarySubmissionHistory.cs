using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.SubmissionHistoryForMobile;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureBeneficiarySubmissionHistory(this ModelBuilder builder)
        {
            builder.Entity<BeneficiarySubmissionHistory>(ac =>
            {
                ac.ToTable("BeneficiarySubmissionHistory", "SubmissionHistoryForMobile");

                //ac.Property(a => a.FileUrl)
                //    .HasColumnType("varchar(500)")
                //    .IsRequired(false);
            });

            //Other Info
            builder.Entity<BeneficiarySubmissionHistory>()
                .HasOne(x => x.Survey)
                .WithMany(x => x.BeneficiarySubmissionHistorys)
                .HasForeignKey(x => x.SurveyId)
                .IsRequired(false);

            builder.Entity<BeneficiarySubmissionHistory>()
                .HasOne(x => x.AIGBasicInformation)
                .WithMany(x => x.BeneficiarySubmissionHistorys)
                .HasForeignKey(x => x.AIGBasicInformationId)
                .IsRequired(false);

            builder.Entity<BeneficiarySubmissionHistory>()
               .HasOne(x => x.InternalLoanInformation)
               .WithMany(x => x.BeneficiarySubmissionHistorys)
               .HasForeignKey(x => x.InternalLoanInformationId)
               .IsRequired(false);

            builder.Entity<BeneficiarySubmissionHistory>()
              .HasOne(x => x.SavingsAccount)
              .WithMany(x => x.BeneficiarySubmissionHistorys)
              .HasForeignKey(x => x.SavingsAccountId)
              .IsRequired(false);
        }
    }
}
