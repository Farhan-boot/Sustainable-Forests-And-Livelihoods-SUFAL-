using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.InternalLoan;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureInternalLoanInformation(this ModelBuilder builder)
    {
        builder.Entity<InternalLoanInformation>(e =>
        {
            e.ToTable($"{nameof(InternalLoanInformation)}s", SchemaNames.InternalLoan);

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
                .IsRequired(false);

            e.Property(x => x.NgoId)
                .IsRequired();
            e.Property(x => x.SurveyId)
                .IsRequired();

            //e.Property(x => x.IsRecievedTrainingInTrade)
            //    .IsRequired();
           //e.Property(x => x.TradeId)
              // .IsRequired(false);

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

            e.Property(x => x.ApprovalStatus)
               .IsRequired(false);
        });

        // Forest Administration
        builder.Entity<InternalLoanInformation>()
            .HasOne(x => x.ForestCircle)
            .WithMany(x => x.InternalLoanInformations)
            .HasForeignKey(x => x.ForestCircleId)
            .IsRequired();
        builder.Entity<InternalLoanInformation>()
            .HasOne(x => x.ForestDivision)
            .WithMany(x => x.InternalLoanInformations)
            .HasForeignKey(x => x.ForestDivisionId)
            .IsRequired();
        builder.Entity<InternalLoanInformation>()
            .HasOne(x => x.ForestRange)
            .WithMany(x => x.InternalLoanInformations)
            .HasForeignKey(x => x.ForestRangeId)
            .IsRequired();
        builder.Entity<InternalLoanInformation>()
            .HasOne(x => x.ForestBeat)
            .WithMany(x => x.InternalLoanInformations)
            .HasForeignKey(x => x.ForestBeatId)
            .IsRequired();
        builder.Entity<InternalLoanInformation>()
            .HasOne(x => x.ForestFcvVcf)
            .WithMany(x => x.InternalLoanInformations)
            .HasForeignKey(x => x.ForestFcvVcfId)
            .IsRequired();

        // Civil Administration
        builder.Entity<InternalLoanInformation>()
            .HasOne(x => x.Division)
            .WithMany(x => x.InternalLoanInformations)
            .HasForeignKey(x => x.DivisionId)
            .IsRequired();
        builder.Entity<InternalLoanInformation>()
            .HasOne(x => x.District)
            .WithMany(x => x.InternalLoanInformations)
            .HasForeignKey(x => x.DistrictId)
            .IsRequired();
        builder.Entity<InternalLoanInformation>()
            .HasOne(x => x.Upazilla)
            .WithMany(x => x.InternalLoanInformations)
            .HasForeignKey(x => x.UpazillaId)
            .IsRequired();
        builder.Entity<InternalLoanInformation>()
            .HasOne(x => x.Union)
            .WithMany(x => x.InternalLoanInformations)
            .HasForeignKey(x => x.UnionId)
            .IsRequired(false);

        // Survey, NGO, Trade
        builder.Entity<InternalLoanInformation>()
            .HasOne(x => x.Ngo)
            .WithMany(x => x.InternalLoanInformations!)
            .HasForeignKey(x => x.NgoId)
            .IsRequired();
        builder.Entity<InternalLoanInformation>()
            .HasOne(x => x.Survey)
            .WithMany(x => x.InternalLoanInformations!)
            .HasForeignKey(x => x.SurveyId)
            .IsRequired();


        //builder.Entity<InternalLoanInformation>()
        //    .HasOne(x => x.Trade)
        //    .WithMany(x => x.AIGBasicInformations!)
        //    .HasForeignKey(x => x.TradeId)
        //    .IsRequired(false);

        // One to one
        //builder.Entity<InternalLoanInformation>()
        //    .HasOne(x => x.FirstSixtyPercentageLDF)
        //    .WithOne(x => x.AIGBasicInformation!)
        //    .HasForeignKey<FirstSixtyPercentageLDF>(x => x.AIGBasicInformationId)
        //    .IsRequired();
        //builder.Entity<AIGBasicInformation>()
        //    .HasOne(x => x.SecondFourtyPercentageLDF)
        //    .WithOne(x => x.AIGBasicInformation!)
        //    .HasForeignKey<SecondFourtyPercentageLDF>(x => x.AIGBasicInformationId)
        //    .IsRequired();

        builder.Entity<InternalLoanInformation>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
