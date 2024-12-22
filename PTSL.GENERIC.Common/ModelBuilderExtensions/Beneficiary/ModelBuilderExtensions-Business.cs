using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureBusiness(this ModelBuilder builder)
        {
            builder.Entity<Business>(e =>
            {
                e.ToTable($"{nameof(Business)}s", "BEN");

                e.Property(x => x.BusinessIncomeSourceTypeTxt)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

			builder.Entity<Business>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);

			builder.Entity<Business>()
                .HasOne(x => x.Survey)
                .WithMany(x => x.Businesses)
                .HasForeignKey(x => x.SurveyId)
                .IsRequired();
        }
    }
}
