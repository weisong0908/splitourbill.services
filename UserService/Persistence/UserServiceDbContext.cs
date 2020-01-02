using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.Persistence
{
    public class UserServiceDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Relationship> Relationships { get; set; }

        public UserServiceDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().Property(u => u.Id).HasColumnName("id");
            modelBuilder.Entity<User>().Property(u => u.Username).HasColumnName("username");
            modelBuilder.Entity<User>().Property(u => u.EmailAddress).HasColumnName("email_address");

            modelBuilder.Entity<Relationship>().ToTable("relationships");
            modelBuilder.Entity<Relationship>().Property(r => r.Id).HasColumnName("id");
            modelBuilder.Entity<Relationship>().Property(r => r.User1).HasColumnName("user1");
            modelBuilder.Entity<Relationship>().Property(r => r.User2).HasColumnName("user2");
            modelBuilder.Entity<Relationship>().Property(r => r.RelationshipType).HasColumnName("relationship_type");

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

            var relationships = new List<Relationship>()
            {
                new Relationship()
                {
                    Id = new Guid("709fb6ba-705a-449b-8060-d09626deca01"),
                    User1 = new Guid("f8b784ae-9dea-48e2-8d81-20f9dcb532bd"),
                    User2 = new Guid("e1db792b-fce0-4355-a9bc-242fbf7232c6"),
                    RelationshipType = "friend"
                }
            };

            modelBuilder.Entity<Relationship>().HasData(relationships);
        }
    }
}