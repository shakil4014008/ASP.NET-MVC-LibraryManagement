﻿// <auto-generated />
using LibraryData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace LibraryData.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibraryData.Models.BranchHours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BranchId");

                    b.Property<int>("CloseTime");

                    b.Property<int>("DayOfWeek");

                    b.Property<int>("OpenTime");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("BranchHourSS");
                });

            modelBuilder.Entity("LibraryData.Models.Checkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Since");

                    b.Property<DateTime>("Until");

                    b.Property<int?>("libraryAssetId");

                    b.Property<int>("libraryCardId");

                    b.HasKey("Id");

                    b.HasIndex("libraryAssetId");

                    b.HasIndex("libraryCardId");

                    b.ToTable("Checkouts");
                });

            modelBuilder.Entity("LibraryData.Models.CheckoutHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CheckedIn");

                    b.Property<DateTime>("CheckedOut");

                    b.Property<int>("libraryAssetId");

                    b.Property<int>("libraryCardId");

                    b.HasKey("Id");

                    b.HasIndex("libraryAssetId");

                    b.HasIndex("libraryCardId");

                    b.ToTable("CheckoutHistorys");
                });

            modelBuilder.Entity("LibraryData.Models.Hold", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("HoldPlaced");

                    b.Property<int?>("libraryAssetId");

                    b.Property<int?>("libraryCardId");

                    b.HasKey("Id");

                    b.HasIndex("libraryAssetId");

                    b.HasIndex("libraryCardId");

                    b.ToTable("Holds");
                });

            modelBuilder.Entity("LibraryData.Models.LibraryAsset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("ImageUrl");

                    b.Property<int?>("LocationId");

                    b.Property<int>("NumberOfCopies");

                    b.Property<int>("StatusId");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("Year");

                    b.Property<decimal>("cost");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("StatusId");

                    b.ToTable("LibraryAssets");

                    b.HasDiscriminator<string>("Discriminator").HasValue("LibraryAsset");
                });

            modelBuilder.Entity("LibraryData.Models.LibraryBranch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<DateTime>("OpenDate");

                    b.Property<string>("Telephone")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("LibraryBranchs");
                });

            modelBuilder.Entity("LibraryData.Models.LibraryCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<decimal>("Fees");

                    b.HasKey("Id");

                    b.ToTable("LibraryCards");
                });

            modelBuilder.Entity("LibraryData.Models.Patron", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("TelephoneNumber");

                    b.Property<int?>("librayBranchId");

                    b.Property<int?>("librayCardId");

                    b.HasKey("ID");

                    b.HasIndex("librayBranchId");

                    b.HasIndex("librayCardId");

                    b.ToTable("pattrons");
                });

            modelBuilder.Entity("LibraryData.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("LibraryData.Models.Book", b =>
                {
                    b.HasBaseType("LibraryData.Models.LibraryAsset");

                    b.Property<string>("Author")
                        .IsRequired();

                    b.Property<string>("DeweyIndex")
                        .IsRequired();

                    b.Property<string>("ISBN")
                        .IsRequired();

                    b.ToTable("Book");

                    b.HasDiscriminator().HasValue("Book");
                });

            modelBuilder.Entity("LibraryData.Models.Video", b =>
                {
                    b.HasBaseType("LibraryData.Models.LibraryAsset");

                    b.Property<string>("Director")
                        .IsRequired();

                    b.ToTable("Video");

                    b.HasDiscriminator().HasValue("Video");
                });

            modelBuilder.Entity("LibraryData.Models.BranchHours", b =>
                {
                    b.HasOne("LibraryData.Models.LibraryBranch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId");
                });

            modelBuilder.Entity("LibraryData.Models.Checkout", b =>
                {
                    b.HasOne("LibraryData.Models.LibraryAsset", "libraryAsset")
                        .WithMany()
                        .HasForeignKey("libraryAssetId");

                    b.HasOne("LibraryData.Models.LibraryCard", "libraryCard")
                        .WithMany("checkouts")
                        .HasForeignKey("libraryCardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LibraryData.Models.CheckoutHistory", b =>
                {
                    b.HasOne("LibraryData.Models.LibraryAsset", "libraryAsset")
                        .WithMany()
                        .HasForeignKey("libraryAssetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LibraryData.Models.LibraryCard", "libraryCard")
                        .WithMany()
                        .HasForeignKey("libraryCardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LibraryData.Models.Hold", b =>
                {
                    b.HasOne("LibraryData.Models.LibraryAsset", "libraryAsset")
                        .WithMany()
                        .HasForeignKey("libraryAssetId");

                    b.HasOne("LibraryData.Models.LibraryCard", "libraryCard")
                        .WithMany()
                        .HasForeignKey("libraryCardId");
                });

            modelBuilder.Entity("LibraryData.Models.LibraryAsset", b =>
                {
                    b.HasOne("LibraryData.Models.LibraryBranch", "Location")
                        .WithMany("libraryAsset")
                        .HasForeignKey("LocationId");

                    b.HasOne("LibraryData.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LibraryData.Models.Patron", b =>
                {
                    b.HasOne("LibraryData.Models.LibraryBranch", "librayBranch")
                        .WithMany("Patrons")
                        .HasForeignKey("librayBranchId");

                    b.HasOne("LibraryData.Models.LibraryCard", "librayCard")
                        .WithMany()
                        .HasForeignKey("librayCardId");
                });
#pragma warning restore 612, 618
        }
    }
}
