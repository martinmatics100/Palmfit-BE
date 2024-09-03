using Microsoft.EntityFrameworkCore;
using Palmfit.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Palmfit.Common.Helpers;
using Palmfit.Application.Interfaces.IRepository;
using Palmfit.Infrastructure.Repository;

using Palmfit.Application.Interfaces.IServices;
using Palmfit.Application.Services;
using Palmfit.Infrastructure.RepositoryWrapper;
using AutoMapper;
using Palmfit.Application.MapperProfile.Profiles;
using Palmfit.Application.Dtos.CloudinaryFolder;
using Palmfit.Application.CloudinaryFolder;
using Palmfit.Common.CloudinaryFolder;

namespace Palmfit.Api.Extensions
{
    public static class DbRegistryExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSection>(configuration.GetSection("JwtSection"));
            var jwtSection = configuration.GetSection(nameof(JwtSection)).Get<JwtSection>();

            services.AddDbContext<PalmfitDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("connection") ??
                    throw new InvalidOperationException("Sorry your connection is not found"));
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = jwtSection!.Issuer,
                    ValidAudience = jwtSection.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection.Key!))
                };
            });


            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                MappingProfile.RegisterProfiles(cfg);
            });

            var mapper = mapperConfiguration.CreateMapper();

            services.AddSingleton(mapper);
            

            //services.AddScoped<IBaseRepository<AppUser>, BaseRepository<AppUser>>();
            //services.AddScoped<IBaseRepository<UserRole>, BaseRepository<UserRole>>();
            //services.AddScoped<IBaseRepository<SystemRole>, BaseRepository<SystemRole>>();
            //services.AddScoped<IBaseRepository<RefreshTokenInfo>, BaseRepository<RefreshTokenInfo>>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IUserAccountServices, UserAccountServices>();


            services.AddScoped<ICloudinaryService, CloudinaryService>();

            services.Configure<CloudinarySetting>(configuration.GetSection("Cloudinary"));

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowBlazorWasm",
            //        builder => builder
            //        .WithOrigins("http://localhost:5074", "https://localhost:7089")
            //        .AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .AllowCredentials());
            //});
        }
    }
}
