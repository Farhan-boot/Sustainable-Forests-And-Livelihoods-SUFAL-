using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureCip(this ModelBuilder builder)
    {
        builder.Entity<Cip>(e =>
        {
            e.ToTable($"{nameof(Cip)}s", "BEN");
        });

        // Forest Administration
        builder.Entity<Cip>()
            .HasOne(x => x.ForestCircle)
            .WithMany(x => x.Cips)
            .HasForeignKey(x => x.ForestCircleId)
            .IsRequired(false);
        builder.Entity<Cip>()
            .HasOne(x => x.ForestDivision)
            .WithMany(x => x.Cips)
            .HasForeignKey(x => x.ForestDivisionId)
            .IsRequired(false);

        builder.Entity<Cip>()
            .HasOne(x => x.ForestRange)
            .WithMany(x => x.Cips)
            .HasForeignKey(x => x.ForestRangeId)
            .IsRequired(false);
        builder.Entity<Cip>()
            .HasOne(x => x.ForestBeat)
            .WithMany(x => x.Cips)
            .HasForeignKey(x => x.ForestBeatId)
            .IsRequired(false);
        builder.Entity<Cip>()
            .HasOne(x => x.ForestFcvVcf)
            .WithMany(x => x.Cips)
            .HasForeignKey(x => x.ForestFcvVcfId)
            .IsRequired(false);

        // Civil Administration
        builder.Entity<Cip>()
            .HasOne(x => x.Division)
            .WithMany(x => x.Cips)
            .HasForeignKey(x => x.DivisionId)
            .IsRequired(false);
        builder.Entity<Cip>()
            .HasOne(x => x.District)
            .WithMany(x => x.Cips)
            .HasForeignKey(x => x.DistrictId)
            .IsRequired(false);
        builder.Entity<Cip>()
            .HasOne(x => x.Upazilla)
            .WithMany(x => x.Cips)
            .HasForeignKey(x => x.UpazillaId)
            .IsRequired(false);
        builder.Entity<Cip>()
            .HasOne(x => x.Union)
            .WithMany(x => x.Cips)
            .HasForeignKey(x => x.UnionId)
            .IsRequired(false);

        builder.Entity<Cip>()
            .HasOne(x => x.Ethnicity)
            .WithMany(x => x.Cips)
            .HasForeignKey(x => x.EthnicityId)
            .IsRequired(false);

        builder.Entity<Cip>()
            .HasIndex(x => x.CipGeneratedId)
            .IsUnique();

        builder.Entity<Cip>()
            .HasOne(x => x.Survey)
            .WithOne(x => x.Cip!)
            .HasForeignKey<Survey>(x => x.CipId)
            .IsRequired(false);

        builder.Entity<Cip>()
            .HasOne(x => x.TypeOfHouseNew)
            .WithMany(x => x.Cips)
            .HasForeignKey(x => x.TypeOfHouseNewId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Cip>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}