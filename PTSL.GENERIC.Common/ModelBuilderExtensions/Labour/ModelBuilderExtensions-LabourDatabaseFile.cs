using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.Labour;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureLabourDatabaseFile(this ModelBuilder builder)
        {
            builder.Entity<LabourDatabaseFile>(ac =>
            {
                ac.ToTable("LabourDatabaseFiles", SchemaNames.LABOUR);

                ac.Property(a => a.FileName)
                    .HasColumnType("varchar(500)")
                    .IsRequired();
             
                ac.Property(a => a.FileUrl)
                   .HasColumnType("varchar(500)")
                   .IsRequired();
            });

            builder.Entity<LabourDatabaseFile>()
                .HasOne(x => x.LabourDatabase)
                .WithMany(x => x.LabourDatabaseFiles)
                .HasForeignKey(x => x.LabourDatabaseId)
                .IsRequired();

            builder.Entity<LabourDatabaseFile>().HasQueryFilter(x => !x.IsDeleted && x.IsActive);
        }
    }
}
