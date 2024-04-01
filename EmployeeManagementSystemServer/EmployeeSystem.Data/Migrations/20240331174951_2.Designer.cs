﻿// <auto-generated />
using System;
using EmployeeSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeSystem.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240331174951_2")]
    partial class _2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeSystem.Core.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("IdNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("EmployeeList");
                });

            modelBuilder.Entity("EmployeeSystem.Core.Entities.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PositionsList");
                });

            modelBuilder.Entity("EmployeeSystem.Core.Entities.PositionForEmployee", b =>
                {
                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DateOfEntryIntoOffice")
                        .HasColumnType("date");

                    b.Property<bool>("IsManagerialPosition")
                        .HasColumnType("bit");

                    b.HasKey("PositionId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("PositionForEmployeesList");
                });

            modelBuilder.Entity("EmployeeSystem.Core.Entities.PositionForEmployee", b =>
                {
                    b.HasOne("EmployeeSystem.Core.Entities.Employee", null)
                        .WithMany("Positions")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeSystem.Core.Entities.Position", null)
                        .WithMany("PositionForEmployees")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeSystem.Core.Entities.Employee", b =>
                {
                    b.Navigation("Positions");
                });

            modelBuilder.Entity("EmployeeSystem.Core.Entities.Position", b =>
                {
                    b.Navigation("PositionForEmployees");
                });
#pragma warning restore 612, 618
        }
    }
}