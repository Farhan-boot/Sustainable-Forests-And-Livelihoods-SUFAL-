using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureEnergyUse(this ModelBuilder builder)
        {
            builder.Entity<EnergyUse>(e =>
            {
                e.ToTable($"{nameof(EnergyUse)}s", "BEN");

                e.Property(x => x.EnergyUseTypeTxt)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

            builder.Entity<EnergyUse>()
                .HasOne(x => x.EnergyType)
                .WithMany(x => x.EnergyUses)
                .HasForeignKey(x => x.EnergyTypeId)
                .IsRequired();
            builder.Entity<EnergyUse>()
                .HasOne(x => x.Survey)
                .WithMany(x => x.EnergyUses)
                .HasForeignKey(x => x.SurveyId)
                .IsRequired();

			builder.Entity<EnergyUse>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
		}
	}
}
