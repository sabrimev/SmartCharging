﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartCharging.Domain.Data.EntityFramework;

#nullable disable

namespace SmartCharging.Domain.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220226174420_initial_migration")]
    partial class initial_migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SmartCharging.Domain.Data.EntityFramework.Entities.ChargeStation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("ChargeStations");
                });

            modelBuilder.Entity("SmartCharging.Domain.Data.EntityFramework.Entities.Connector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("ChargeStationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("MaxCurrent")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ChargeStationId");

                    b.ToTable("Connectors");
                });

            modelBuilder.Entity("SmartCharging.Domain.Data.EntityFramework.Entities.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Capacity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("SmartCharging.Domain.Data.EntityFramework.Entities.ChargeStation", b =>
                {
                    b.HasOne("SmartCharging.Domain.Data.EntityFramework.Entities.Group", "Group")
                        .WithMany("ChargeStations")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("SmartCharging.Domain.Data.EntityFramework.Entities.Connector", b =>
                {
                    b.HasOne("SmartCharging.Domain.Data.EntityFramework.Entities.ChargeStation", "ChargeStation")
                        .WithMany("Connectors")
                        .HasForeignKey("ChargeStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChargeStation");
                });

            modelBuilder.Entity("SmartCharging.Domain.Data.EntityFramework.Entities.ChargeStation", b =>
                {
                    b.Navigation("Connectors");
                });

            modelBuilder.Entity("SmartCharging.Domain.Data.EntityFramework.Entities.Group", b =>
                {
                    b.Navigation("ChargeStations");
                });
#pragma warning restore 612, 618
        }
    }
}
