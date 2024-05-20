using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithEFCore
{
    public class Northwind : DbContext
    {
        //props to map to tables in the database
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Northwind.db");

            string connection = $"Filename={path}";

            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.DarkYellow;

            WriteLine($"Connection: {connection}");
            optionsBuilder.UseSqlite(connection);
            optionsBuilder.LogTo(WriteLine)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            // example of using Fluent API instead of attributes
            // to limit the length of a category name to 15
            modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired() // NOT NULL
                .HasMaxLength(15);
            if(Database.ProviderName?.Contains("Sqlite") ?? false)
            {
                // added to "fix" the lack of decimal support in SQLite
                modelBuilder.Entity<Product>().Property(product => product.Cost).HasConversion<double>();
            }
        }
    }
}
