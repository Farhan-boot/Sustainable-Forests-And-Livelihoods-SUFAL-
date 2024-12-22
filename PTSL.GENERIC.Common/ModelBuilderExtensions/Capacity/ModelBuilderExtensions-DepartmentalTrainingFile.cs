using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Capacity;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureDepartmentalTrainingFile(this ModelBuilder builder)
        {
            builder.Entity<DepartmentalTrainingFile>(e =>
            {
                e.ToTable($"{nameof(DepartmentalTrainingFile)}s", "Capacity");

                e.Property(x => x.FileName)
                    .HasColumnType("text")
                    .IsRequired(false);

                e.Property(x => x.FileNameUrl)
                    .HasColumnType("text")
                    .IsRequired(false);

                e.Property(x => x.FileType)
                    .IsRequired();
            });

            builder.Entity<DepartmentalTrainingFile>()
                .HasOne(x => x.DepartmentalTraining)
                .WithMany(x => x.DepartmentalTrainingFiles)
                .HasForeignKey(x => x.DepartmentalTrainingId)
                .IsRequired();

			builder.Entity<DepartmentalTrainingFile>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}
