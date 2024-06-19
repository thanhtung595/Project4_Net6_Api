using Lib_Models.Model_Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_DatabaseEntity.DbContext_SQL_Server
{
    public class Db_Context : DbContext
    {
        public Db_Context(DbContextOptions options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Account> Account { get; set; }
        public DbSet<CategoryParents> CategoryParents { get; set; }
        public DbSet<CategoryChildren> CategoryChildren { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<ListProductBill> ListProductBill { get; set; }
    }
}
