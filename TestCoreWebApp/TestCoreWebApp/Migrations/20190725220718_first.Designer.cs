﻿// <auto-generated />
using AcesWebApp.Models.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AcesWebApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190725220718_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099");

            modelBuilder.Entity("AcesWebApp.Models.Classrooms.Classroom", b =>
                {
                    b.Property<int>("classId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("className");

                    b.Property<string>("orgName");

                    b.HasKey("classId");

                    b.ToTable("Classrooms");
                });

            modelBuilder.Entity("AcesWebApp.Models.Students.Student", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("classId");

                    b.Property<string>("githubEmail");

                    b.Property<string>("githubUrsName");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("Students");
                });
#pragma warning restore 612, 618
        }
    }
}