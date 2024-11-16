using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Director;
using Domain.Film.Repositories;
using Domain.Image.Repositories;
using Domain.User.Repositories;
using Infrastructure.Authentication;
using Infrastructure.Authentication.Config;
using Infrastructure.Media;
using Infrastructure.Notifications;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Config;
using Infrastructure.Persistence.Interceptors;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Storage.Local;
using MediatR;
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
            var imageProperties = new ImageProperties();
            var hlsProperties = new HLSProperties();
            configuration.GetSection("Jwt").Bind(jwtProperties);
            configuration.GetSection("Media").GetSection("Image").Bind(imageProperties);
            configuration.GetSection("Media").GetSection("HLS").Bind(hlsProperties);
            services.AddSingleton(imageProperties);
            services.AddSingleton(jwtProperties);
            services.AddSingleton(hlsProperties);
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
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
            services.AddScoped<PublishDomainEventsInterceptor>();
            services.AddScoped<IMediator, Mediator>();
            services.AddScoped<IImageProcessor, ImageProcessor>();
            services.AddScoped<ILocalStorage, LocalStorage>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IVideoProcessor, VideoProcessor>();
            services.AddScoped<IDirectorRepository, DirectorRepository>();
            return services;
        }
    }
}