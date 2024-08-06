using Domain.Film.Entities;
using Domain.Image.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Config
{
    public class ImageConfig : IEntityTypeConfiguration<Image>
    {

        public void Configure(EntityTypeBuilder<Image> builder)
        {

            builder.ToTable("Images");
            builder.HasMany<Varient>().WithOne().HasForeignKey(v => v.ImageId).OnDelete(DeleteBehavior.ClientCascade);
            builder.Navigation(i => i.Varients).Metadata.SetField("_varients");
        }
    }

    public class VarientConfig : IEntityTypeConfiguration<Varient>
    { 
        public void Configure(EntityTypeBuilder<Varient> builder)
        {
            builder.ToTable("ImageVarients");
            builder.OwnsOne(v => v.Dimension);

        }
    }
}
