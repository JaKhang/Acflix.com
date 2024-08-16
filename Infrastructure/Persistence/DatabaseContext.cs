using Domain.Base;
using Domain.Base.ValueObjects;
using Domain.Film.Entities;
using Domain.Film.ObjectValues;
using Domain.Image.Entities;
using Domain.User.ObjectValue;
using Infrastructure.Persistence.Converter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Domain.Caterory;
using Domain.Event;
using Domain.User.Entities;
using Infrastructure.Persistence.Config;
using Infrastructure.Persistence.Interceptors;

namespace Infrastructure.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EntityConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new FilmConfig());
            modelBuilder.ApplyConfiguration(new ImageConfig());
            modelBuilder.ApplyConfiguration(new SeriesConfig());
            modelBuilder.ApplyConfiguration(new MovieConfig());
            modelBuilder.ApplyConfiguration(new EpisodeConfig());
            modelBuilder.ApplyConfiguration(new CommentConfig());
            modelBuilder.ApplyConfiguration(new VoteConfig());
            modelBuilder.ApplyConfiguration(new VariantConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new CodeConfig());
            // modelBuilder.ApplyConfiguration(new VideoConfig());
            modelBuilder.Ignore<List<DomainEvent>>();



        }


        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<ID>().HaveConversion<IDConverter>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.
            //     AddInterceptors(domainEventsInterceptor);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
