using Data.Layer.Access.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Data.Layer.Access
{
    public class DataAccess:DbContext
    {
        public DataAccess(DbContextOptions<DataAccess>options):base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=SEZER;Database=NewGenericBaseDb;Integrated Security=True;Trust Server Certificate=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //// UserInfo ve User arasında birebir ilişki
            //modelBuilder.Entity<UserInfo>()
            //    .HasOne(u => u.User)
            //    .WithOne(i=>i.UserInformation)
            //    .HasForeignKey<User>(u=>u.UserInformation);

            //// Product ve UserInfo arasında çoka çok ilişki
            //modelBuilder.Entity<Product>()
            //    .HasMany(p => p.Users)
            //    .WithMany(u => u.Products)
            //    .UsingEntity(join => join.ToTable("ProductUser"));


            //modelBuilder.Entity<Product>().HasData(
            //new Product
            //{
            //    ProductName = "Samsung Galaxy A21S",
            //    Category = "Technology",
            //    Description = "Mobile Phone",
            //    StockQuantity = 1304,
            //    Price = 1249.99

            //});
            //modelBuilder.Entity<Product>().HasData(
            //new Product
            //{
            //    ProductName = "RedMi Note 10",
            //    Category = "Technology",
            //    Description = "Mobile Phone",
            //    StockQuantity = 1334,
            //    Price = 1049.99

            //});
            //modelBuilder.Entity<Product>().HasData(
            //new Product
            //{
            //    ProductName = "Huawei Nova 11i",
            //    Category = "Technology",
            //    Description = "Mobile Phone",
            //    StockQuantity = 123,
            //    Price = 1529.99

            //});
            
            //modelBuilder.Entity<Product>().HasData(
            //new Product
            //{
            //    ProductName = "Huawei P60 Pro",
            //    Category = "Technology",
            //    Description = "Mobile Phone",
            //    StockQuantity = 1544,
            //    Price = 1321.99

            //});

        }
    }
}
