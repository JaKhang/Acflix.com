using Domain.Image.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Persistence.Config
{
    public class ImageConfig : IEntityTypeConfiguration<Image>
    {

        public void Configure(EntityTypeBuilder<Image> builder)
        {

            builder.ToTable("Images");
            builder.HasMany<Variant>().WithOne().HasForeignKey("ImageId").OnDelete(DeleteBehavior.ClientCascade);
            builder.Navigation(i => i.Variants).Metadata.SetField("_variants");
        }
    }

    public class VariantConfig : IEntityTypeConfiguration<Variant>
    { 
        public void Configure(EntityTypeBuilder<Variant> builder)
        {
            builder.ToTable("ImageVariants");
            builder.HasOne<Image>().WithMany(f => f.Variants).HasForeignKey(c => c.ImageId).OnDelete(DeleteBehavior.ClientCascade);
            builder.OwnsOne(v => v.Dimension);

        }
    }
}
