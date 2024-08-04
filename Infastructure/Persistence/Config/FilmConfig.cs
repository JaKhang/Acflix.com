using Azure;
using Domain.Actor.Enities;
using Domain.Base.ValueObjects;
using Domain.Director;
using Domain.Film.Entities;
using Domain.Film.ObjectValues;
using Domain.Image.Entities;
using Infastructure.Persistence.Converter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Infastructure.Persistence.Config
{
    public class FilmConfig : IEntityTypeConfiguration<Film>
    {

        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.ToTable("Films");

            builder.Property(f => f.Name).HasMaxLength(255);
            builder.Property(f => f.Description).IsRequired(false);
            builder.Property(f => f.OriginalName).HasMaxLength(255);
            builder.Property(f => f.Language).HasMaxLength(2);
            builder.Property(f => f.AgeRestriction).IsRequired(true).HasDefaultValue(0);
            builder.Property(f => f.Country).HasMaxLength(2);
            builder.Property(f => f.Popularity).HasDefaultValue(0);
            builder.Property(f => f.PosterId).IsRequired(false);
            builder.Property(f => f.DirectorId).IsRequired(false);
            builder.Property(f => f.Quality).HasConversion<QualityConverter>();
            builder.Property(f => f.Status).HasConversion<FilmStatusConverter>();
            builder.OwnsOne(f => f.ReleaseDate);
            builder.HasMany(f => f.Comments).WithOne().HasForeignKey(c => c.FilmId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(f => f.Votes).WithOne().HasForeignKey(c => c.FilmId).OnDelete(DeleteBehavior.Cascade);

            /* builder.OwnsMany(f => f.Genres, g =>
             {
                 g.ToTable("FilmGenreRelationship");
                 g.WithOwner().HasForeignKey("FilmId");
                 g.HasKey("FilmId", "Genre");
             });*/
            builder.Navigation(f => f.Genres).Metadata.SetField("_genres");
            builder.Property(f => f.Genres).HasConversion(
                  v => string.Join(',', v.Select(t => t.Id)),
                  v => v.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                  .Select(id => Genre.FromId(int.Parse(id)))
                  .ToList()
                );
            builder.OwnsMany(film => film.ActorIds, ac =>
            {
                ac.ToTable("FilmActorRelationship");
                ac.Property(f => f.Value).HasColumnName("actorId");
                ac.WithOwner().HasForeignKey("filmId");
                ac.HasKey("filmId", "Value");

            });
            builder.OwnsMany(film => film.RelatedFilmIds, ac =>
            {
                ac.ToTable("FilmRelatedFilmRelationship");
                ac.Property(f => f.Value).HasColumnName("relatedFilmId");
                ac.WithOwner().HasForeignKey("filmId");
                ac.WithOwner().HasForeignKey("relatedFilmId");
                ac.HasKey("filmId", "Value");

            });
            builder.HasOne<Director>().WithMany().HasForeignKey(f => f.DirectorId).OnDelete(DeleteBehavior.ClientCascade);
            builder.HasOne<Image>().WithMany().HasForeignKey(f => f.PosterId).OnDelete(DeleteBehavior.ClientCascade);
            builder.HasMany(f => f.Comments).WithOne().HasForeignKey(c => c.FilmId);
            builder.Navigation(f => f.Comments).Metadata.SetField("_comments");
            builder.Navigation(f => f.ActorIds).Metadata.SetField("_actorIds");
            builder.Navigation(f => f.Votes).Metadata.SetField("_votes");
            builder.Navigation(f => f.RelatedFilmIds).Metadata.SetField("_relatedFilmIds");

        }
    }

    public class SeriesConfig : IEntityTypeConfiguration<Series>
    {

        public void Configure(EntityTypeBuilder<Series> builder)
        {
            builder.ToTable("Series");


            builder.HasMany(s => s.Episodes).WithOne().HasForeignKey(e => e.FilmId).OnDelete(DeleteBehavior.ClientCascade);

                
        }
    }

    public class MovieConfig : IEntityTypeConfiguration<Movie>
    {

        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movies");


            builder.OwnsOne(m => m.Source);
        }
    }

    public class EpisodeConfig : IEntityTypeConfiguration<Episode>
    {

        public void Configure(EntityTypeBuilder<Episode> builder)
        {
            builder.ToTable("Episodes");

            builder.OwnsOne(e => e.Source);
        }
    }

    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {

        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");

            builder.Property(c => c.UserId).HasConversion<IDConverter>();
            builder.HasOne<Film>().WithMany().HasForeignKey(c => c.FilmId).OnDelete(DeleteBehavior.ClientCascade);
        }


    }

    public class VoteConfig : IEntityTypeConfiguration<Vote>
    {

        public void Configure(EntityTypeBuilder<Vote> builder)
        {

            builder.ToTable("Votes");
            builder.Property(c => c.UserId).HasConversion<IDConverter>();
            builder.HasOne<Film>().WithMany().HasForeignKey(c => c.FilmId).OnDelete(DeleteBehavior.ClientCascade);

        }
    }

}
