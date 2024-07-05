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

        public DbSet<AccountEntity> Account { get; set; }
        public DbSet<CategoryEntity> Category { get; set; }
        public DbSet<BrandEntity> Brand { get; set; }
        public DbSet<ProductEntity> Product { get; set; }
        public DbSet<CartEntity> Cart { get; set; }
        public DbSet<BillEntity> Bill { get; set; }
        public DbSet<ListProductBillEntity> ListProductBill { get; set; }
    }
}
