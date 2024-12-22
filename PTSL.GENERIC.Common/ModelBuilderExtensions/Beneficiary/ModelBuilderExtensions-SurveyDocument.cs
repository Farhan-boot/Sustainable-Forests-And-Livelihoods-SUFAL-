using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureSurveyDocument(this ModelBuilder builder)
    {
        builder.Entity<SurveyDocument>(e =>
        {
            e.ToTable($"{nameof(SurveyDocument)}s", "BEN");

            e.Property(x => x.SurveyId)
                .IsRequired();
            e.Property(x => x.DocumentName)
                .HasColumnType("text")
                .IsRequired();
            e.Property(x => x.DocumentNameURL)
                .HasColumnType("text")
                .IsRequired();
        });

        builder.Entity<SurveyDocument>()
            .HasOne(x => x.Survey)
            .WithMany(x => x.SurveyDocuments)
            .HasForeignKey(x => x.SurveyId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<SurveyDocument>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
