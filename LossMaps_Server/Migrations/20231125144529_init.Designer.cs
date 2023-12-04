﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LossMaps_Server.Migrations
{
    [DbContext(typeof(YourDbContext))]
    [Migration("20231125144529_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("Statement", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApplicantFirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ApplicantLastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ApplicantPatronymic")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateTimeOfStatement")
                        .HasColumnType("TEXT");

                    b.Property<string>("Features")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Latitude")
                        .HasColumnType("REAL");

                    b.Property<double>("Longitude")
                        .HasColumnType("REAL");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Statement");
                });
#pragma warning restore 612, 618
        }
    }
}
