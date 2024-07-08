using Lib_DatabaseEntity.DbContext_SQL_Server;
using Lib_DatabaseEntity.Repository;
using Lib_Services.Authoz;
using Lib_Services.Brand;
using Lib_Services.Category;
using Lib_Services.Jwt;
using Lib_Services.Product;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Config
{
    public static class Configuration
    {
        public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Db_Context>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DataBase_Project4_Tung_Hoang"),
            options => options.MigrationsAssembly(typeof(Db_Context).Assembly.FullName)));
        }

        public static void RegisterRepositoryScoped(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAuthoz, Authoz>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<ICustomCookieService, CustomCookieService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IProductService, ProductService>();
        }

        public static void RegisterAddCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.WithOrigins("http://26.0.169.91:3000", "http://26.78.185.194:5050", "http://localhost:5071")
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials()
                           .WithExposedHeaders("*");
                    });
            });
        }

        public static void RegisterJwt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    LifetimeValidator = (notBefore, expires, token, param) =>
                    {
                        return expires > DateTime.UtcNow; // Kiểm tra thời gian hết hạn
                    },
                    ValidateIssuerSigningKey = true
                };
            });
        }
    }
}
