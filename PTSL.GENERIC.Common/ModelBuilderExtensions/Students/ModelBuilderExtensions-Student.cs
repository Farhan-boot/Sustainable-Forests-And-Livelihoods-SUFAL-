using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.Students;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureStudent(this ModelBuilder builder)
        {
            builder.Entity<Student>(e =>
            {
                e.ToTable($"{nameof(Student)}s", "Student");

                e.Property(x => x.Name)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);

                e.Property(x => x.Email)
                   .HasColumnType("varchar(500)")
                   .IsRequired(false);

                e.Property(x => x.RollNumber)
                .HasColumnType("varchar(500)")
                .IsRequired(false);

                e.Property(x => x.AccountNumber)
                .HasColumnType("varchar(500)")
                .IsRequired(false);

                e.Property(a => a.Batch).IsRequired(false);
                e.Property(a => a.Semester).IsRequired(false);
            });


        }
    }
}
