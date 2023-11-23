﻿// <auto-generated />
using System;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231121231402_mig-SeedData")]
    partial class migSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entity.Entities.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ImageId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c8afbbb2-995e-43d8-a6ab-44e312fbce83"),
                            CategoryId = new Guid("1f148b26-918a-4153-94a6-0d55256d4c7e"),
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 11, 22, 2, 14, 2, 54, DateTimeKind.Local).AddTicks(6675),
                            ImageId = new Guid("25222750-0aa6-40ce-bad6-616a23f249f4"),
                            IsDeleted = false,
                            Title = "Asp.Net Core Deneme Makalesi 1",
                            ViewCount = 15
                        },
                        new
                        {
                            Id = new Guid("bce4549a-185b-4d84-a90d-7f687058c973"),
                            CategoryId = new Guid("c0f62248-8220-49ed-8354-1a5ed2a5ff57"),
                            Content = "Visual Studio Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 11, 22, 2, 14, 2, 54, DateTimeKind.Local).AddTicks(6681),
                            ImageId = new Guid("c0f62248-8220-49ed-8354-1a5ed2a5ff23"),
                            IsDeleted = false,
                            Title = "Visual Studio Deneme Makalesi 1",
                            ViewCount = 15
                        });
                });

            modelBuilder.Entity("Entity.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c0f62248-8220-49ed-8354-1a5ed2a5ff57"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 11, 22, 2, 14, 2, 54, DateTimeKind.Local).AddTicks(6842),
                            IsDeleted = false,
                            Name = "Visual Studio"
                        },
                        new
                        {
                            Id = new Guid("1f148b26-918a-4153-94a6-0d55256d4c7e"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 11, 22, 2, 14, 2, 54, DateTimeKind.Local).AddTicks(6845),
                            IsDeleted = false,
                            Name = "Asp.Net Core"
                        });
                });

            modelBuilder.Entity("Entity.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c0f62248-8220-49ed-8354-1a5ed2a5ff23"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 11, 22, 2, 14, 2, 54, DateTimeKind.Local).AddTicks(6943),
                            FileName = "images/testimage",
                            FileType = "png",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = new Guid("25222750-0aa6-40ce-bad6-616a23f249f4"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 11, 22, 2, 14, 2, 54, DateTimeKind.Local).AddTicks(6946),
                            FileName = "images/testimage",
                            FileType = "jpg",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("Entity.Entities.Article", b =>
                {
                    b.HasOne("Entity.Entities.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Entities.Image", "Image")
                        .WithMany("Articles")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Entity.Entities.Category", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("Entity.Entities.Image", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}
