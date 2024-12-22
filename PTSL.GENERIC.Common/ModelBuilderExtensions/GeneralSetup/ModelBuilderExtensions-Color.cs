using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureColor(this ModelBuilder builder)
        {
            builder.Entity<Color>(ac =>
            {
                ac.ToTable("Color", "GS");

                ac.Property(a => a.ColorName)
                    .HasColumnName("ColorName")
                    .HasColumnType("varchar(500)")
                    .IsRequired();
            });
            builder.Entity<Color>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            //builder.Entity<Color>().HasQueryFilter(q => q.IsDeleted == 0 && q.IsActive == 1);
        }
    }
}
