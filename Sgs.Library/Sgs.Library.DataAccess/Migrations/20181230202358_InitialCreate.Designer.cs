﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sgs.Library.DataAccess;

namespace Sgs.Library.DataAccess.Migrations
{
    [DbContext(typeof(LibraryDB))]
    [Migration("20181230202358_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sgs.Library.Model.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("ColumnNumber")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<decimal>("Price")
                        .HasColumnType("Money");

                    b.Property<int>("Quantity");

                    b.Property<int>("ReleaseYaer");

                    b.Property<string>("RowNumber")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<string>("ShelfNumber")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Sgs.Library.Model.Borrow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookId");

                    b.Property<DateTime>("BorrowDate");

                    b.Property<int>("EmployeeId");

                    b.Property<bool>("IsReturn");

                    b.Property<int?>("MapId");

                    b.Property<int?>("PeriodicalId");

                    b.Property<int?>("ReportId");

                    b.Property<DateTime?>("ReturnDate");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("MapId");

                    b.HasIndex("PeriodicalId");

                    b.HasIndex("ReportId");

                    b.ToTable("Borrowings");
                });

            modelBuilder.Entity("Sgs.Library.Model.Map", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abstract")
                        .IsRequired();

                    b.Property<string>("ArabicName")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("ColumnNumber")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<bool>("HasAttachment");

                    b.Property<string>("MapSize")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<int>("MapTypeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<decimal>("Price")
                        .HasColumnType("Money");

                    b.Property<int>("Quantity");

                    b.Property<string>("Region")
                        .HasMaxLength(30);

                    b.Property<int>("ReleaseYaer");

                    b.Property<string>("RowNumber")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<string>("ShelfNumber")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("MapTypeId");

                    b.ToTable("Maps");
                });

            modelBuilder.Entity("Sgs.Library.Model.MapType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("MapsTypes");
                });

            modelBuilder.Entity("Sgs.Library.Model.Periodical", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("ColumnNumber")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime>("PeriodicalDate");

                    b.Property<decimal>("Price")
                        .HasColumnType("Money");

                    b.Property<int>("Quantity");

                    b.Property<int>("ReleaseYaer");

                    b.Property<string>("RowNumber")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<string>("ShelfNumber")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.HasKey("Id");

                    b.ToTable("Periodicals");
                });

            modelBuilder.Entity("Sgs.Library.Model.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abstract")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("ColumnNumber")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<bool>("HasAttachment");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Note")
                        .HasMaxLength(300);

                    b.Property<decimal>("Price")
                        .HasColumnType("Money");

                    b.Property<int>("Quantity");

                    b.Property<string>("Region")
                        .HasMaxLength(30);

                    b.Property<int>("ReleaseYaer");

                    b.Property<int>("ReportTypeId");

                    b.Property<string>("RowNumber")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<string>("ShelfNumber")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("ReportTypeId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Sgs.Library.Model.ReportType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("ReportsTypes");
                });

            modelBuilder.Entity("Sgs.Library.Model.Borrow", b =>
                {
                    b.HasOne("Sgs.Library.Model.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("Sgs.Library.Model.Map", "Map")
                        .WithMany()
                        .HasForeignKey("MapId");

                    b.HasOne("Sgs.Library.Model.Periodical", "Periodical")
                        .WithMany()
                        .HasForeignKey("PeriodicalId");

                    b.HasOne("Sgs.Library.Model.Report", "Report")
                        .WithMany()
                        .HasForeignKey("ReportId");
                });

            modelBuilder.Entity("Sgs.Library.Model.Map", b =>
                {
                    b.HasOne("Sgs.Library.Model.MapType", "MapType")
                        .WithMany("MapsList")
                        .HasForeignKey("MapTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Sgs.Library.Model.Report", b =>
                {
                    b.HasOne("Sgs.Library.Model.ReportType", "ReportType")
                        .WithMany("ReportsList")
                        .HasForeignKey("ReportTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}