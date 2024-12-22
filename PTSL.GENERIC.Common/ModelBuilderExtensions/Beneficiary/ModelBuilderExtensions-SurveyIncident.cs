using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureSurveyIncident(this ModelBuilder builder)
    {
        builder.Entity<SurveyIncident>(e =>
        {
            e.ToTable($"{nameof(SurveyIncident)}s", "BEN");
        });

        builder.Entity<SurveyIncident>()
            .HasOne(x => x.Survey)
            .WithMany(x => x.SurveyIncidents)
            .HasForeignKey(x => x.SurveyId)
            .IsRequired();

        builder.Entity<SurveyIncident>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}