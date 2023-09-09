using Microsoft.EntityFrameworkCore;
using NorthwindBackend.Core.Entities.Concrete;
using NorthwindBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.DataAccess.Concrete.EntityFramework.Contexts
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(connectionString: @"Server=(ASUS)\\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
            optionsBuilder.UseSqlServer(connectionString: @"Server=ASUS;Database=Northwind;User Id=sa;Password=123;");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
