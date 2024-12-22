using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.AIG;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureIndividualLDFInfoForm(this ModelBuilder builder)
    {
        builder.Entity<IndividualLDFInfoForm>(e =>
        {
            e.ToTable($"{nameof(IndividualLDFInfoForm)}s", SchemaNames.AIG);

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

            e.Property(x => x.SurveyId)
                .IsRequired();

            e.Property(x => x.NgoId)
                .HasDefaultValue(null)
                .IsRequired(false);

            e.Property(x => x.RequestedLoanAmount)
                .IsRequired();
            e.Property(x => x.ApprovedLoanAmount)
                .IsRequired();

            e.Property(x => x.IndividualLDFInfoStatus)
                .IsRequired();
            e.Property(x => x.StatusDate)
                .HasDefaultValue(null)
                .IsRequired(false);
            e.Property(x => x.DocumentInfoURL)
                .IsRequired();
        });

        // Forest Administration
        builder.Entity<IndividualLDFInfoForm>()
            .HasOne(x => x.ForestCircle)
            .WithMany(x => x.IndividualLDFInfoForms)
            .HasForeignKey(x => x.ForestCircleId)
            .IsRequired();
        builder.Entity<IndividualLDFInfoForm>()
            .HasOne(x => x.ForestDivision)
            .WithMany(x => x.IndividualLDFInfoForms)
            .HasForeignKey(x => x.ForestDivisionId)
            .IsRequired();

        builder.Entity<IndividualLDFInfoForm>()
            .HasOne(x => x.ForestRange)
            .WithMany(x => x.IndividualLDFInfoForms)
            .HasForeignKey(x => x.ForestRangeId)

            .IsRequired();
        builder.Entity<IndividualLDFInfoForm>()
            .HasOne(x => x.ForestBeat)
            .WithMany(x => x.IndividualLDFInfoForms)
            .HasForeignKey(x => x.ForestBeatId)
            .IsRequired();
        builder.Entity<IndividualLDFInfoForm>()
            .HasOne(x => x.ForestFcvVcf)
            .WithMany(x => x.IndividualLDFInfoForms)
            .HasForeignKey(x => x.ForestFcvVcfId)
            .IsRequired();

        // Civil Administration
        builder.Entity<IndividualLDFInfoForm>()
            .HasOne(x => x.Division)
            .WithMany(x => x.IndividualLDFInfoForms)
            .HasForeignKey(x => x.DivisionId)
            .IsRequired();
        builder.Entity<IndividualLDFInfoForm>()
            .HasOne(x => x.District)
            .WithMany(x => x.IndividualLDFInfoForms)
            .HasForeignKey(x => x.DistrictId)
            .IsRequired();
        builder.Entity<IndividualLDFInfoForm>()
            .HasOne(x => x.Upazilla)
            .WithMany(x => x.IndividualLDFInfoForms)
            .HasForeignKey(x => x.UpazillaId)
            .IsRequired();
        builder.Entity<IndividualLDFInfoForm>()
            .HasOne(x => x.Union)
            .WithMany(x => x.IndividualLDFInfoForms)
            .HasForeignKey(x => x.UnionId)
            .IsRequired(false);

        builder.Entity<IndividualLDFInfoForm>()
            .HasOne(x => x.Ngo)
            .WithMany(x => x.IndividualLDFInfoForms)
            .HasForeignKey(x => x.NgoId)
            .IsRequired(false);

        builder.Entity<IndividualLDFInfoForm>()
            .HasOne(x => x.AIGBasicInformation)
            .WithOne(x => x.IndividualLDFInfoForm!)
            .HasForeignKey<AIGBasicInformation>(x => x.IndividualLDFInfoFormId)
            .IsRequired(false);

        builder.Entity<IndividualLDFInfoForm>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
