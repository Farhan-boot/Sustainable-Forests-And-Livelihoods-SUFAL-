using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureLandOccupancy(this ModelBuilder builder)
        {
            builder.Entity<LandOccupancy>(e =>
            {
                e.ToTable("LandOccupancies", "BEN");

                e.Property(x => x.LandClassificationEnum)
                    .HasColumnType("smallint")
                    .IsRequired();
                e.Property(x => x.LandClassificationTxt)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                e.Property(x => x.Notes)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

            builder.Entity<LandOccupancy>()
                .HasOne(x => x.Survey)
                .WithMany(x => x.LandOccupancy)
                .HasForeignKey(x => x.SurveyId)
                .IsRequired();

			builder.Entity<LandOccupancy>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}
