using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Film.Repositories;
using Domain.User.Repositories;
using Infrastructure.Authentication;
using Infrastructure.Authentication.Config;
using Infrastructure.Notifications;
using Infrastructure.Persistence.Config;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.DI
{
    public static class ServiceContainer
    {
        public static IServiceCollection InfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            var jwtProperties = new JwtProperties();
            configuration.GetSection("Jwt").Bind(jwtProperties);
            services.AddSingleton(jwtProperties);
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtProperties.Issuer,
                    ValidAudience = jwtProperties.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtProperties.SecretKey))
                };
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<ICodeGenerator, CodeGenerator>();
            services.AddScoped<IJwtProvider, JwtProvider>();
            return services;
        }
    }
}
