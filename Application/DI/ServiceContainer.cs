using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.Directors;
using Application.Factories;
using Application.Mappers;
using Application.Queries;
using Application.Worker;
using Domain.User.Repositories;
using Infrastructure.Authentication.Config;
using Infrastructure.Persistence.Config;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Application.DI



{
    public static class ServiceContainer
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services,
            IConfiguration configuration)
        {



            services.AddScoped<IDbConnectionFactory, SqlServerConnectionFactory>();
            services.AddScoped<ICategoryQueries, CategoryQueries>();
            services.AddScoped<UserMapper>();
            services.AddScoped<ImageMapper>();
            services.AddScoped<FilmMapper>();
            services.AddScoped<IImageQueries, ImageQueries>();
            services.AddScoped<IImageWorker, ImageWorker>();
            services.AddScoped<IVideoWorker, VideoWorker>();


            return services;
        }
    }
}
