using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.Persistence
{
    public class UserServiceDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserServiceDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().Property(u => u.Id).HasColumnName("id");
            modelBuilder.Entity<User>().Property(u => u.Username).HasColumnName("username");
            modelBuilder.Entity<User>().Property(u => u.EmailAddress).HasColumnName("email_address");

            SeedDatabase(modelBuilder);
        }

        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            var users = new List<User>()
            {
                new User(){ Id = new Guid("f8b784ae-9dea-48e2-8d81-20f9dcb532bd"), Username = "User 1"},
                new User(){ Id = new Guid("e1db792b-fce0-4355-a9bc-242fbf7232c6"), Username = "User 2"}
            };
            modelBuilder.Entity<User>().HasData(users);
        }
    }
}