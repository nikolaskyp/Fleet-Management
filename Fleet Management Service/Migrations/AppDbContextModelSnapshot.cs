﻿// <auto-generated />
using System;
using Fleet_Management_Service.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fleet_Management_Service.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fleet_Management_Service.Models.Container", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContainerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VesselId")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VesselId");

                    b.ToTable("Containers");
                });

            modelBuilder.Entity("Fleet_Management_Service.Models.Fleet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fleets");
                });

            modelBuilder.Entity("Fleet_Management_Service.Models.Vessel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FleetId")
                        .HasColumnType("int");

                    b.Property<string>("IMONumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaximumCapacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FleetId");

                    b.ToTable("Vessels");
                });

            modelBuilder.Entity("Fleet_Management_Service.Models.Container", b =>
                {
                    b.HasOne("Fleet_Management_Service.Models.Vessel", "Vessel")
                        .WithMany()
                        .HasForeignKey("VesselId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vessel");
                });

            modelBuilder.Entity("Fleet_Management_Service.Models.Vessel", b =>
                {
                    b.HasOne("Fleet_Management_Service.Models.Fleet", null)
                        .WithMany("Vessels")
                        .HasForeignKey("FleetId");
                });

            modelBuilder.Entity("Fleet_Management_Service.Models.Fleet", b =>
                {
                    b.Navigation("Vessels");
                });
#pragma warning restore 612, 618
        }
    }
}
