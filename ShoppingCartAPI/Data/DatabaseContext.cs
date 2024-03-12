using ShoppingCartAPI.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace ShoppingCartAPI.Data
{
    public class DatabaseContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ShoppingCart>()
        //        .HasMany(e => e.CartItems);
        //}

        public DbSet<Product> Products { get; set; }
    }

}


