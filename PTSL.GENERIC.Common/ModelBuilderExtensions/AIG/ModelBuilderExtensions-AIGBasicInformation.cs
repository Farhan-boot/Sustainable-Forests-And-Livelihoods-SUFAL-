using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.AIG;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureAIGBasicInformation(this ModelBuilder builder)
    {
        builder.Entity<AIGBasicInformation>(e =>
        {
            e.ToTable($"{nameof(AIGBasicInformation)}s", SchemaNames.AIG);

            e.Property(x => x.ForestCircleId)
                .IsRequired();
            e.Property(x => x.ForestDivisionId)
                .IsRequired();
            e.Property(x => x.ForestRangeId)
                .IsRequired();
            e.Property(x => x.ForestBeatId)
                .IsRequired();
            e.Property(x => x.ForestFcvVcfId)
                .IsRequired();
            e.Property(x => x.DivisionId)
                .IsRequired();
            e.Property(x => x.DistrictId)
                .IsRequired();
            e.Property(x => x.UpazillaId)
                .IsRequired();
            e.Property(x => x.UnionId)
                .IsRequired();

            e.Property(x => x.NgoId)
                .IsRequired();
            e.Property(x => x.SurveyId)
                .IsRequired();
            e.Property(x => x.IsRecievedTrainingInTrade)
                .IsRequired();
            e.Property(x => x.TradeId)
                .IsRequired(false);

            e.Property(x => x.LDFCount)
                .IsRequired();

            e.Property(x => x.TotalAllocatedLoanAmount)
                .IsRequired();
            e.Property(x => x.MaximumRepaymentMonth)
                .IsRequired();
            e.Property(x => x.StartDate)
                .IsRequired();
            e.Property(x => x.EndDate)
                .IsRequired();
            e.Property(x => x.ServiceChargePercentage)
                .IsRequired();
            e.Property(x => x.SecurityChargePercentage)
                .IsRequired();
        });

        // Forest Administration
        builder.Entity<AIGBasicInformation>()
            .HasOne(x => x.ForestCircle)
            .WithMany(x => x.AIGBasicInformations)
            .HasForeignKey(x => x.ForestCircleId)
            .IsRequired();
        builder.Entity<AIGBasicInformation>()
            .HasOne(x => x.ForestDivision)
            .WithMany(x => x.AIGBasicInformations)
            .HasForeignKey(x => x.ForestDivisionId)
            .IsRequired();
        builder.Entity<AIGBasicInformation>()
            .HasOne(x => x.ForestRange)
            .WithMany(x => x.AIGBasicInformations)
            .HasForeignKey(x => x.ForestRangeId)
            .IsRequired();
        builder.Entity<AIGBasicInformation>()
            .HasOne(x => x.ForestBeat)
            .WithMany(x => x.AIGBasicInformations)
            .HasForeignKey(x => x.ForestBeatId)
            .IsRequired();
        builder.Entity<AIGBasicInformation>()
            .HasOne(x => x.ForestFcvVcf)
            .WithMany(x => x.AIGBasicInformations)
            .HasForeignKey(x => x.ForestFcvVcfId)
            .IsRequired();

        // Civil Administration
        builder.Entity<AIGBasicInformation>()
            .HasOne(x => x.Division)
            .WithMany(x => x.AIGBasicInformations)
            .HasForeignKey(x => x.DivisionId)
            .IsRequired();
        builder.Entity<AIGBasicInformation>()
            .HasOne(x => x.District)
            .WithMany(x => x.AIGBasicInformations)
            .HasForeignKey(x => x.DistrictId)
            .IsRequired();
        builder.Entity<AIGBasicInformation>()
            .HasOne(x => x.Upazilla)
            .WithMany(x => x.AIGBasicInformations)
            .HasForeignKey(x => x.UpazillaId)
            .IsRequired();
        builder.Entity<AIGBasicInformation>()
            .HasOne(x => x.Union)
            .WithMany(x => x.AIGBasicInformations)
            .HasForeignKey(x => x.UnionId)
            .IsRequired(false);

        // Survey, NGO, Trade
        builder.Entity<AIGBasicInformation>()
            .HasOne(x => x.Ngo)
            .WithMany(x => x.AIGBasicInformations!)
            .HasForeignKey(x => x.NgoId)
            .IsRequired();
        builder.Entity<AIGBasicInformation>()
            .HasOne(x => x.Survey)
            .WithMany(x => x.AIGBasicInformations!)
            .HasForeignKey(x => x.SurveyId)
            .IsRequired();
        builder.Entity<AIGBasicInformation>()
            .HasOne(x => x.Trade)
            .WithMany(x => x.AIGBasicInformations!)
            .HasForeignKey(x => x.TradeId)
            .IsRequired(false);
        builder.Entity<AIGBasicInformation>()
            .HasOne(x => x.Account)
            .WithMany(x => x.AIGBasicInformations!)
            .HasForeignKey(x => x.AccountId)
            .IsRequired(false);

        // One to one
        builder.Entity<AIGBasicInformation>()
            .HasOne(x => x.FirstSixtyPercentageLDF)
            .WithOne(x => x.AIGBasicInformation!)
            .HasForeignKey<FirstSixtyPercentageLDF>(x => x.AIGBasicInformationId)
            .IsRequired();
        builder.Entity<AIGBasicInformation>()
            .HasOne(x => x.SecondFourtyPercentageLDF)
            .WithOne(x => x.AIGBasicInformation!)
            .HasForeignKey<SecondFourtyPercentageLDF>(x => x.AIGBasicInformationId)
            .IsRequired();

        builder.Entity<AIGBasicInformation>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
