using Domain.Base.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Category;

namespace Infrastructure.Persistence.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.OwnsMany(x => x.FilmIds, d =>
            {

                d.ToTable("CategoryFilmRelationship");
                d.Property(v => v.Value).HasColumnName("filmsId");
                d.WithOwner().HasForeignKey("categoryId");
                d.HasKey("categoryId", "Value");
            });
        }
    }


}
