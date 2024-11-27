﻿// <auto-generated />
using System;
using CarServiceApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarServiceApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241119203735_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CarServiceApp.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EngineType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("RepairCaseId")
                        .HasColumnType("int");

                    b.Property<int?>("RepairCaseId1")
                        .HasColumnType("int");

                    b.Property<string>("VIN")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RepairCaseId");

                    b.HasIndex("RepairCaseId1");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarServiceApp.Models.RepairCase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("RepairHistory")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UnresolvedIssues")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("RepairCases");
                });

            modelBuilder.Entity("CarServiceApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarServiceApp.Models.Car", b =>
                {
                    b.HasOne("CarServiceApp.Models.RepairCase", null)
                        .WithMany()
                        .HasForeignKey("RepairCaseId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("CarServiceApp.Models.RepairCase", "RepairCase")
                        .WithMany()
                        .HasForeignKey("RepairCaseId1");

                    b.Navigation("RepairCase");
                });
#pragma warning restore 612, 618
        }
    }
}