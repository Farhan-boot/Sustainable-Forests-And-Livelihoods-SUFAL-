using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureNaturalIncomeSourceType(this ModelBuilder builder)
        {
            builder.Entity<NaturalIncomeSourceType>(e =>
            {
                e.ToTable($"{nameof(NaturalIncomeSourceType)}s", "BEN");

                e.Property(x => x.Name)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                e.Property(x => x.NameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

			builder.Entity<NaturalIncomeSourceType>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}
