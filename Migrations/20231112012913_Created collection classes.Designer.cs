﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentAPI_Main.Data;

#nullable disable

namespace StudentAPI_Main.Migrations
{
    [DbContext(typeof(StudentAPIDbContext))]
    [Migration("20231112012913_Created collection classes")]
    partial class Createdcollectionclasses
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentAPI_Main.Domain.Models.Class", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Classses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("237b0357-dfb0-49e9-90a9-0a25933c439e"),
                            Name = "Intro to programming"
                        },
                        new
                        {
                            Id = new Guid("5c47bab3-293b-4b64-8860-bdeb1516ed43"),
                            Name = "Web Prog and Impl"
                        },
                        new
                        {
                            Id = new Guid("69e61e7e-6b80-4cde-b016-3a253e9a0c45"),
                            Name = "Java"
                        },
                        new
                        {
                            Id = new Guid("0d06acb7-5ad4-458c-b26e-a3b390994335"),
                            Name = "Object Oriented"
                        });
                });

            modelBuilder.Entity("StudentAPI_Main.Domain.Models.Ranking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rankings");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b9de3c6d-55e8-4857-9e8e-87a8c35f5ae0"),
                            Name = "Brilliant"
                        },
                        new
                        {
                            Id = new Guid("df1228e3-b8e6-4bd5-95a3-5b54e19b3a88"),
                            Name = "Average"
                        },
                        new
                        {
                            Id = new Guid("044677d4-ec73-4c97-a007-86530e9c0769"),
                            Name = "Needs more work"
                        });
                });

            modelBuilder.Entity("StudentAPI_Main.Domain.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RankingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("RankingId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentAPI_Main.Domain.Models.Class", b =>
                {
                    b.HasOne("StudentAPI_Main.Domain.Models.Student", null)
                        .WithMany("Classes")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("StudentAPI_Main.Domain.Models.Student", b =>
                {
                    b.HasOne("StudentAPI_Main.Domain.Models.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentAPI_Main.Domain.Models.Ranking", "Ranking")
                        .WithMany()
                        .HasForeignKey("RankingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Ranking");
                });

            modelBuilder.Entity("StudentAPI_Main.Domain.Models.Student", b =>
                {
                    b.Navigation("Classes");
                });
#pragma warning restore 612, 618
        }
    }
}
