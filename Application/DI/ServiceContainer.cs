using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands;
using Application.Mappers;
using Application.Queries;
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


            services.AddScoped<IAuthenticationCommands, AuthenticationCommand>();
            services.AddScoped<IFilmCommands, FilmCommand>();
            services.AddScoped<ICategoryCommands, CategoryCommands>();
            services.AddScoped<ICategoryQueries, CategoryQueries>();
            services.AddScoped<UserMapper, UserMapper>();
            services.AddScoped<ImageMapper, ImageMapper>();
            return services;
        }
    }
}
