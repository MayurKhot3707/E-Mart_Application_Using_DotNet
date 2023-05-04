using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace E_mart_final_project.models
{

    public class EmartContext : DbContext
    {
        public EmartContext() { }
        public EmartContext(DbContextOptions<EmartContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-JCDQ5ER\\SQLEXPRESS;Initial Catalog=Emart;Integrated Security=True; Trust Server Certificate=True");
            }


        }

        public DbSet<CatMaster> CatMaster { get; set; }
        public DbSet<ProductMaster> ProductMaster { get; set; }
        public DbSet<ProductDtlMaster> ProductDtlMaster { get; set; }
        public DbSet<ConfigMaster> ConfigMaster { get; set; }
        public DbSet<AddToCart> AddToCarts { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Payment> Payment { get; set; }


    }
}