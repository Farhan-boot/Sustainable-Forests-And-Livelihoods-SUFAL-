using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureDisabilityType(this ModelBuilder builder)
        {
            builder.Entity<DisabilityType>(e =>
            {
                e.ToTable($"{nameof(DisabilityType)}s", "BEN");

                e.Property(x => x.Name)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                e.Property(x => x.NameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

			builder.Entity<DisabilityType>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
		}
	}
}
