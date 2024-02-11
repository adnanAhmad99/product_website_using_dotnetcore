﻿// <auto-generated />
using MainApp.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MainApp.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240211095801_SeedAdded")]
    partial class SeedAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MainApp.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Scifi"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Isekei"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Fantacy"
                        });
                });

            modelBuilder.Entity("MainApp.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryDataId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryDataId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryDataId = 1,
                            ImageUrl = "",
                            ProductName = "firsty",
                            Quantity = 10
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryDataId = 2,
                            ImageUrl = "",
                            ProductName = "secondy",
                            Quantity = 40
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryDataId = 3,
                            ImageUrl = "",
                            ProductName = "thirdy",
                            Quantity = 20
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryDataId = 2,
                            ImageUrl = "",
                            ProductName = "forthdy",
                            Quantity = 23
                        });
                });

            modelBuilder.Entity("MainApp.Models.Product", b =>
                {
                    b.HasOne("MainApp.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}