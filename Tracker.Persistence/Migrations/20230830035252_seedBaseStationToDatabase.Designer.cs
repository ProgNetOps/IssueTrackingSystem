﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tracker.Persistence;

#nullable disable

namespace Tracker.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230830035252_seedBaseStationToDatabase")]
    partial class seedBaseStationToDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tracker.Entity.BTS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BTSName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Coordinates")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<string>("LocationAddress")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("BaseStations");
                });

            modelBuilder.Entity("Tracker.Entity.NetworkSwitch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BTSId")
                        .HasColumnType("int");

                    b.Property<string>("ConfigBackup")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<DateTime?>("DateOfLastBackup")
                        .HasColumnType("datetime2");

                    b.Property<string>("SwitchIP")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("SwitchName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("BTSId");

                    b.ToTable("NetworkSwitch");
                });

            modelBuilder.Entity("Tracker.Entity.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RegionName = "Abuja"
                        },
                        new
                        {
                            Id = 2,
                            RegionName = "Benin"
                        },
                        new
                        {
                            Id = 3,
                            RegionName = "Enugu"
                        },
                        new
                        {
                            Id = 4,
                            RegionName = "Ibadan"
                        },
                        new
                        {
                            Id = 5,
                            RegionName = "Lagos"
                        },
                        new
                        {
                            Id = 6,
                            RegionName = "PortHarcourt"
                        });
                });

            modelBuilder.Entity("Tracker.Entity.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("Tracker.Entity.BTS", b =>
                {
                    b.HasOne("Tracker.Entity.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("Tracker.Entity.NetworkSwitch", b =>
                {
                    b.HasOne("Tracker.Entity.BTS", "BTS")
                        .WithMany("Switches")
                        .HasForeignKey("BTSId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BTS");
                });

            modelBuilder.Entity("Tracker.Entity.State", b =>
                {
                    b.HasOne("Tracker.Entity.Region", "Region")
                        .WithMany("States")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Tracker.Entity.BTS", b =>
                {
                    b.Navigation("Switches");
                });

            modelBuilder.Entity("Tracker.Entity.Region", b =>
                {
                    b.Navigation("States");
                });
#pragma warning restore 612, 618
        }
    }
}
