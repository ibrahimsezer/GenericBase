using Data.Layer.Access.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Layer.Access
{
    public class DataAccess:DbContext
    {
        public DbSet<User<UserInfo>> Users { get; set; }
        public DbSet<Product> Products { get; set; }   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=SEZER;Database=GenericBaseDb;Integrated Security=True;Trust Server Certificate=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // UserInfo ve User arasında birebir ilişki
            modelBuilder.Entity<UserInfo>()
                .HasOne(u => u.User)
                .WithOne(i=>i.Info)
                .HasForeignKey<User<UserInfo>>(u=>u.InfoId);

            // Product ve UserInfo arasında çoka çok ilişki
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Users)
                .WithMany(u => u.Products)
                .UsingEntity(join => join.ToTable("ProductUser"));
                

        }
    }
}
