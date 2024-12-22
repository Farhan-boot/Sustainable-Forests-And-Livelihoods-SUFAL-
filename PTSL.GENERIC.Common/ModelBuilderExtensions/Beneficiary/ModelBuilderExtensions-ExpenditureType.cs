using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureExpenditureType(this ModelBuilder builder)
        {
            builder.Entity<ExpenditureType>(e =>
            {
                e.ToTable($"{nameof(ExpenditureType)}s", "BEN");

                e.Property(x => x.Name)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                e.Property(x => x.NameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

			builder.Entity<ExpenditureType>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
		}
    }
}
