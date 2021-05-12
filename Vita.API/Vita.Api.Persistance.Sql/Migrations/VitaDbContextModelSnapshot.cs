﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vita.Api.Persistance.Sql;

namespace Vita.Persistance.Sql.Migrations
{
    [DbContext(typeof(VitaApiDbContext))]
    partial class VitaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Vita.Api.Domain.Aggregates.Categories.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Vita.Api.Domain.Aggregates.Goals.Goal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset(0)");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Title");

                    b.Property<int>("_goalStatusId")
                        .HasColumnType("int")
                        .HasColumnName("GoalStatusId");

                    b.HasKey("Id");

                    b.HasIndex("_goalStatusId");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("Vita.Api.Domain.Aggregates.Goals.GoalStatus", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("GoalStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "todo"
                        },
                        new
                        {
                            Id = 2,
                            Name = "completed"
                        });
                });

            modelBuilder.Entity("Vita.Api.Domain.Aggregates.Goals.Goal", b =>
                {
                    b.HasOne("Vita.Api.Domain.Aggregates.Goals.GoalStatus", "GoalStatus")
                        .WithMany()
                        .HasForeignKey("_goalStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Vita.Api.Domain.Aggregates.Dates.DateTimeInterval", "AimDate", b1 =>
                        {
                            b1.Property<Guid>("GoalId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTimeOffset>("End")
                                .HasColumnType("datetimeoffset");

                            b1.Property<DateTimeOffset>("Start")
                                .HasColumnType("datetimeoffset");

                            b1.HasKey("GoalId");

                            b1.ToTable("Goals");

                            b1.WithOwner()
                                .HasForeignKey("GoalId");
                        });

                    b.Navigation("AimDate");

                    b.Navigation("GoalStatus");
                });
#pragma warning restore 612, 618
        }
    }
}
