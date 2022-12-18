﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MeetupApi.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Speaker")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Theme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b68f79c0-1147-4402-8160-2f28af499fb8"),
                            Date = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "111",
                            Place = "1",
                            Speaker = "1",
                            Theme = "1"
                        },
                        new
                        {
                            Id = new Guid("d62bb844-7c8c-49a2-af47-7792c8c00515"),
                            Date = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "222",
                            Place = "2",
                            Speaker = "2",
                            Theme = "2"
                        },
                        new
                        {
                            Id = new Guid("5a6fe7c4-6e36-4064-b7ca-bc5cbceefc74"),
                            Date = new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "333",
                            Place = "3",
                            Speaker = "3",
                            Theme = "3"
                        },
                        new
                        {
                            Id = new Guid("1901f789-4cb8-4bf9-b72a-ec1787592098"),
                            Date = new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "444",
                            Place = "4",
                            Speaker = "4",
                            Theme = "4"
                        },
                        new
                        {
                            Id = new Guid("093deb67-be72-412c-b6a2-0a797e56a3f5"),
                            Date = new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "555",
                            Place = "5",
                            Speaker = "5",
                            Theme = "5"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
