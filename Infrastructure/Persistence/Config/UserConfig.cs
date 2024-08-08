using Domain.Base.ValueObjects;
using Domain.Image.Entities;
using Domain.User.Entities;
using Domain.User.ObjectValue;
using Infrastructure.Persistence.Converter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.OwnsOne(user => user.Name);
            builder.HasOne<Image>().WithMany().HasForeignKey(user => user.AvatarId).IsRequired(false);
            builder.Property(f => f.Roles).HasConversion(
                v => string.Join(',', v.Select(t => t.Id)),
                v => v.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(id => Role.FromId(int.Parse(id)))
                    .ToList()
            );

            builder.HasMany(user => user.Codes).WithOne().HasForeignKey(c => c.UserId).IsRequired(true);
            builder.Property(user => user.Email).HasMaxLength(320);
            builder.Property(user => user.VerifiedAt).HasDefaultValue(null).IsRequired(false);
            builder.Property(user => user.Provider).HasConversion<UserProviderConverter>();
            builder.Property(user => user.AvatarId).IsRequired(false);
            builder.OwnsMany(user => user.SavedFilms, b =>
            {
                b.ToTable("UserSavedFilm");
                b.Property(f => f.Value).HasColumnName("FilmId");
                b.WithOwner().HasForeignKey("userId");
                b.HasKey("userId", "Value");
            });

            builder.OwnsMany(user => user.Histories, b =>
            {
                b.ToTable("UserHistory");
                b.Property(f => f.Value).HasColumnName("FilmId");
                b.WithOwner().HasForeignKey("userId");
                b.HasKey("userId", "Value");
            });
            builder.Navigation(f => f.Codes).Metadata.SetField("_codes");

            InitData(builder);


        }

        private void InitData(EntityTypeBuilder<User> builder)
        {
            var roles = new List<Role>();
            roles.Add(Role.USER);
            roles.Add(Role.ADMIN);
            var name = new Name("Khang", "Ja");
            var user = new User(
                null,
                new DateOnly(2003, 10, 29),
                "kamilionbc@gmail.com",
                "0354519928",
                roles,
                "$2a$11$jRQjEN.2di5tJWhsHTPJgOYawOFC6l73YIsrliCx1uHUHdcYLEZLG",
                DateTime.Now,
                UserProvider.ACFLIX,
                null);
            builder.OwnsOne(u => u.Name).HasData(new
            {
                FirstName = "Khang",
                LastName = "Ja",
                UserId = user.Id
            });

            builder.HasData(new User[]
            {
                user
            });
        }
    }

    public class CodeConfig : IEntityTypeConfiguration<Code>
    {
        public void Configure(EntityTypeBuilder<Code> builder)
        {
            builder.ToTable("Codes");
            builder.Property(code => code.Type).HasConversion(t => t.Id, id => TokenType.FromId(id));
            builder.HasOne<User>().WithMany(user => user.Codes).HasForeignKey(code => code.UserId).OnDelete(DeleteBehavior.ClientCascade);
        }
    }

}

