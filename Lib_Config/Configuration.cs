using Lib_DatabaseEntity.DbContext_SQL_Server;
using Lib_DatabaseEntity.Repository;
using Lib_Services.Authoz;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        }

        public static void RegisterAddCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials()
                           .WithExposedHeaders("*");
                    });
            });
        }
    }
}
