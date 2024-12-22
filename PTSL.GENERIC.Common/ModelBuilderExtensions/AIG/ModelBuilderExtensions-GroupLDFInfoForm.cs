using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.AIG;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureGroupLDFInfoForm(this ModelBuilder builder)
    {
        builder.Entity<GroupLDFInfoForm>(e =>
        {
            e.ToTable($"{nameof(GroupLDFInfoForm)}s", SchemaNames.AIG);

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
                .HasDefaultValue(null)
                .IsRequired(false);

            e.Property(x => x.SubmittedById)
                .IsRequired();
            e.Property(x => x.SubmittedDate)
                .IsRequired();
            e.Property(x => x.DocumentName)
                .IsRequired(false);
            e.Property(x => x.DocumentNameURL)
                .IsRequired();
        });

        // Forest Administration
        builder.Entity<GroupLDFInfoForm>()
            .HasOne(x => x.ForestCircle)
            .WithMany(x => x.GroupLDFInfoForms)
            .HasForeignKey(x => x.ForestCircleId)
            .IsRequired();
        builder.Entity<GroupLDFInfoForm>()
            .HasOne(x => x.ForestDivision)
            .WithMany(x => x.GroupLDFInfoForms)
            .HasForeignKey(x => x.ForestDivisionId)
            .IsRequired();

        builder.Entity<GroupLDFInfoForm>()
            .HasOne(x => x.ForestRange)
            .WithMany(x => x.GroupLDFInfoForms)
            .HasForeignKey(x => x.ForestRangeId)

            .IsRequired();
        builder.Entity<GroupLDFInfoForm>()
            .HasOne(x => x.ForestBeat)
            .WithMany(x => x.GroupLDFInfoForms)
            .HasForeignKey(x => x.ForestBeatId)
            .IsRequired();
        builder.Entity<GroupLDFInfoForm>()
            .HasOne(x => x.ForestFcvVcf)
            .WithMany(x => x.GroupLDFInfoForms)
            .HasForeignKey(x => x.ForestFcvVcfId)
            .IsRequired();

        // Civil Administration
        builder.Entity<GroupLDFInfoForm>()
            .HasOne(x => x.Division)
            .WithMany(x => x.GroupLDFInfoForms)
            .HasForeignKey(x => x.DivisionId)
            .IsRequired();
        builder.Entity<GroupLDFInfoForm>()
            .HasOne(x => x.District)
            .WithMany(x => x.GroupLDFInfoForms)
            .HasForeignKey(x => x.DistrictId)
            .IsRequired();
        builder.Entity<GroupLDFInfoForm>()
            .HasOne(x => x.Upazilla)
            .WithMany(x => x.GroupLDFInfoForms)
            .HasForeignKey(x => x.UpazillaId)
            .IsRequired();
        builder.Entity<GroupLDFInfoForm>()
            .HasOne(x => x.Union)
            .WithMany(x => x.GroupLDFInfoForms)
            .HasForeignKey(x => x.UnionId)
            .IsRequired(false);

        builder.Entity<GroupLDFInfoForm>()
            .HasOne(x => x.Ngo)
            .WithMany(x => x.GroupLDFInfoForms)
            .HasForeignKey(x => x.NgoId)
            .IsRequired(false);

        builder.Entity<GroupLDFInfoForm>()
            .HasOne(x => x.SubmittedBy)
            .WithMany(x => x.GroupLDFInfoForms)
            .HasForeignKey(x => x.SubmittedById)
            .IsRequired(false);

        builder.Entity<GroupLDFInfoForm>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
