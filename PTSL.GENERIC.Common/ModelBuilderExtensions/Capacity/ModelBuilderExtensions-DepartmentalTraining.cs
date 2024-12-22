using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Capacity;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureDepartmentalTraining(this ModelBuilder builder)
        {
            builder.Entity<DepartmentalTraining>(e =>
            {
                e.ToTable($"{nameof(DepartmentalTraining)}s", "Capacity");

                e.Property(x => x.TrainingTitle)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);

                e.Property(x => x.TrainingTitleBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);

                e.Property(x => x.StartDate)
                    .IsRequired();

                e.Property(x => x.EndDate)
                    .IsRequired();

                e.Property(x => x.TrainingDuration)
                    .HasColumnType("varchar(200)")
                    .IsRequired();

                e.Property(x => x.Location)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);

                e.Property(x => x.LocationBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);

                e.Property(x => x.TrainerName)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);

                e.Property(x => x.TotalMembers)
                    .IsRequired();
                e.Property(x => x.TotalMale)
                    .IsRequired();
                e.Property(x => x.TotalFemale)
                    .IsRequired();

                e.Property(x => x.FinancialYearId)
                    .IsRequired(false);
            });

            builder.Entity<DepartmentalTraining>()
                .HasOne(x => x.EventType)
                .WithMany(x => x.DepartmentalTrainings)
                .HasForeignKey(x => x.EventTypeId)
                .IsRequired();
            builder.Entity<DepartmentalTraining>()
                .HasOne(x => x.DepartmentalTrainingType)
                .WithMany(x => x.DepartmentalTrainings)
                .HasForeignKey(x => x.DepartmentalTrainingTypeId)
                .IsRequired(false);
            builder.Entity<DepartmentalTraining>()
                .HasOne(x => x.TrainingOrganizer)
                .WithMany(x => x.DepartmentalTrainings)
                .HasForeignKey(x => x.TrainingOrganizerId)
                .IsRequired();

            builder.Entity<DepartmentalTraining>()
                .HasOne(x => x.FinancialYear)
                .WithMany(x => x.DepartmentalTrainings)
                .HasForeignKey(x => x.FinancialYearId)
                .IsRequired(false);

			builder.Entity<DepartmentalTraining>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}
