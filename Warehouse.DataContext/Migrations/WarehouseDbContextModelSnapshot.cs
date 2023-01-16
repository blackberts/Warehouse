﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Warehouse.DataContext;

#nullable disable

namespace Warehouse.DataContext.Migrations
{
    [DbContext(typeof(WarehouseDbContext))]
    partial class WarehouseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Warehouse.Domain.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Warehouse.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DeparmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DeparmentId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Warehouse.Domain.Entities.Worker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FullName")
                        .IsUnique();

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("Warehouse.Domain.Entities.WorkersDepartments", b =>
                {
                    b.Property<Guid>("WorkerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("WorkerId", "DepartmentId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("WorkersDepartments");
                });

            modelBuilder.Entity("Warehouse.Domain.Entities.Product", b =>
                {
                    b.HasOne("Warehouse.Domain.Entities.Department", "Department")
                        .WithMany("Products")
                        .HasForeignKey("DeparmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Warehouse.Domain.Entities.WorkersDepartments", b =>
                {
                    b.HasOne("Warehouse.Domain.Entities.Department", "Department")
                        .WithMany("WorkersDepartments")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Warehouse.Domain.Entities.Worker", "Worker")
                        .WithMany("WorkersDepartments")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("Warehouse.Domain.Entities.Department", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("WorkersDepartments");
                });

            modelBuilder.Entity("Warehouse.Domain.Entities.Worker", b =>
                {
                    b.Navigation("WorkersDepartments");
                });
#pragma warning restore 612, 618
        }
    }
}
