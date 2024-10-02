﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StaffCensus.DataAccess;

#nullable disable

namespace StaffCensus.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241002052343_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("StaffCensus.DataAccess.Entities.DepartmentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Floor")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Floor = 2,
                            Name = "IT"
                        },
                        new
                        {
                            Id = 2,
                            Floor = 1,
                            Name = "HR"
                        });
                });

            modelBuilder.Entity("StaffCensus.DataAccess.Entities.EmployeeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("StaffCensus.DataAccess.Entities.ProgrammingLanguageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProgrammingLanguages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "C#"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Java"
                        });
                });

            modelBuilder.Entity("StaffCensus.DataAccess.Entities.WorkExperienceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProgrammingLanguageId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProgrammingLanguageId");

                    b.ToTable("WorkExperiences");
                });

            modelBuilder.Entity("StaffCensus.DataAccess.Entities.EmployeeEntity", b =>
                {
                    b.HasOne("StaffCensus.DataAccess.Entities.DepartmentEntity", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("StaffCensus.DataAccess.Entities.WorkExperienceEntity", b =>
                {
                    b.HasOne("StaffCensus.DataAccess.Entities.EmployeeEntity", "Employee")
                        .WithMany("WorkExperiences")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StaffCensus.DataAccess.Entities.ProgrammingLanguageEntity", "ProgrammingLanguage")
                        .WithMany()
                        .HasForeignKey("ProgrammingLanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("ProgrammingLanguage");
                });

            modelBuilder.Entity("StaffCensus.DataAccess.Entities.EmployeeEntity", b =>
                {
                    b.Navigation("WorkExperiences");
                });
#pragma warning restore 612, 618
        }
    }
}
