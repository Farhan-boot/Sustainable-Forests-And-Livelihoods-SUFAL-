using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureAnnualHouseholdExpenditure(this ModelBuilder builder)
        {
            builder.Entity<AnnualHouseholdExpenditure>(e =>
            {
                e.ToTable($"{nameof(AnnualHouseholdExpenditure)}s", "BEN");

                e.Property(x => x.ExpenditureTypeTxt)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                e.Property(x => x.ExpenditureRemarks)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

			builder.Entity<AnnualHouseholdExpenditure>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);

			builder.Entity<AnnualHouseholdExpenditure>()
                .HasOne(x => x.ExpenditureType)
                .WithMany(x => x.AnnualHouseholdExpenditures)
                .HasForeignKey(x => x.ExpenditureTypeId)
                .IsRequired(false);
            builder.Entity<AnnualHouseholdExpenditure>()
                .HasOne(x => x.Survey)
                .WithMany(x => x.AnnualHouseholdExpenditures)
                .HasForeignKey(x => x.SurveyId)
                .IsRequired();
        }
    }
}
