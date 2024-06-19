using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_DatabaseEntity.DbContext_SQL_Server
{
    public class Db_ContextFactory : IDesignTimeDbContextFactory<Db_Context>
    {
        public Db_Context CreateDbContext(string[] args)
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var connectString = configurationRoot.GetConnectionString("DataBase_Project4_Tung_Hoang");
            var optionBuider = new DbContextOptionsBuilder<Db_Context>();
            optionBuider.UseSqlServer(connectString);
            return new Db_Context(optionBuider.Options);
        }
    }
}
