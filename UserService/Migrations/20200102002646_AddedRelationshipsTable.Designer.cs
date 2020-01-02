﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UserService.Persistence;

namespace UserService.Migrations
{
    [DbContext(typeof(UserServiceDbContext))]
    [Migration("20200102002646_AddedRelationshipsTable")]
    partial class AddedRelationshipsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("UserService.Models.Relationship", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<string>("RelationshipType")
                        .HasColumnName("relationship_type")
                        .HasColumnType("text");

                    b.Property<Guid>("User1")
                        .HasColumnName("user1")
                        .HasColumnType("uuid");

                    b.Property<Guid>("User2")
                        .HasColumnName("user2")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("relationships");

                    b.HasData(
                        new
                        {
                            Id = new Guid("709fb6ba-705a-449b-8060-d09626deca01"),
                            RelationshipType = "friend",
                            User1 = new Guid("f8b784ae-9dea-48e2-8d81-20f9dcb532bd"),
                            User2 = new Guid("e1db792b-fce0-4355-a9bc-242fbf7232c6")
                        });
                });

            modelBuilder.Entity("UserService.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<string>("EmailAddress")
                        .HasColumnName("email_address")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnName("username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f8b784ae-9dea-48e2-8d81-20f9dcb532bd"),
                            Username = "User 1"
                        },
                        new
                        {
                            Id = new Guid("e1db792b-fce0-4355-a9bc-242fbf7232c6"),
                            Username = "User 2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
