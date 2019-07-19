﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Portal.Models;

namespace Portal.Migrations
{
    [DbContext(typeof(contextDatabase))]
    [Migration("20190529140045_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Portal.Models.modelCredentials", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email");

                    b.Property<string>("lastLogin");

                    b.Property<string>("password");

                    b.HasKey("ID");

                    b.ToTable("credentialsTable");
                });

            modelBuilder.Entity("Portal.Models.modelDataResult", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("assayID");

                    b.Property<string>("downloadDateTime");

                    b.Property<string>("instrumentName");

                    b.Property<string>("instrumentUUID");

                    b.Property<string>("kitLotID");

                    b.Property<string>("sampleID");

                    b.Property<string>("uniqueID");

                    b.HasKey("ID");

                    b.ToTable("dataresultTable");
                });

            modelBuilder.Entity("Portal.Models.modelInstruments", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("lastPing");

                    b.Property<string>("localAddress");

                    b.Property<string>("name");

                    b.Property<string>("status");

                    b.HasKey("ID");

                    b.ToTable("instrumentsTable");
                });

            modelBuilder.Entity("Portal.Models.modelRawResult", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("date");

                    b.Property<string>("name");

                    b.Property<string>("path");

                    b.HasKey("ID");

                    b.ToTable("rawindexTable");
                });

            modelBuilder.Entity("Portal.Models.modelTarget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DataID");

                    b.Property<int?>("DataTableId");

                    b.Property<string>("Name");

                    b.Property<string>("Outcome");

                    b.Property<string>("tId");

                    b.HasKey("Id");

                    b.HasIndex("DataID");

                    b.ToTable("modelTarget");
                });

            modelBuilder.Entity("Portal.Models.modelTracker", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("dateTime");

                    b.Property<string>("sampleID");

                    b.Property<string>("uniqueID");

                    b.HasKey("ID");

                    b.ToTable("trackersTable");
                });

            modelBuilder.Entity("Portal.Models.modelWell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cq");

                    b.Property<int?>("DataID");

                    b.Property<int?>("DataTableId");

                    b.Property<string>("Species");

                    b.Property<string>("wId");

                    b.HasKey("Id");

                    b.HasIndex("DataID");

                    b.ToTable("modelWell");
                });

            modelBuilder.Entity("Portal.Models.modelTarget", b =>
                {
                    b.HasOne("Portal.Models.modelDataResult", "Data")
                        .WithMany("targets")
                        .HasForeignKey("DataID");
                });

            modelBuilder.Entity("Portal.Models.modelWell", b =>
                {
                    b.HasOne("Portal.Models.modelDataResult", "Data")
                        .WithMany("wells")
                        .HasForeignKey("DataID");
                });
#pragma warning restore 612, 618
        }
    }
}
