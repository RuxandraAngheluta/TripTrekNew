﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TripTrek.Models;

#nullable disable

namespace TripTrek.Migrations
{
    [DbContext(typeof(PiiContext))]
    [Migration("20240607084928_e1")]
    partial class e1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TripTrek.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("PhoneNr")
                        .HasColumnType("bigint");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Account");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("TripTrek.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id")
                        .HasName("PK_Address");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("TripTrek.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("PricePerNight")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Hotel");

                    b.HasIndex("AddressId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("TripTrek.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Street")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("TotalRating")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("Id")
                        .HasName("PK_Location");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("TripTrek.Models.Suggestion", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Contra")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Pro")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("Userid")
                        .HasColumnType("int")
                        .HasColumnName("userid");

                    b.HasKey("Id")
                        .HasName("PK_Suggestion");

                    b.ToTable("Suggestions");
                });

            modelBuilder.Entity("TripTrek.Models.TouristSpot", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("TicketPrice")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("TouristSpots");
                });

            modelBuilder.Entity("TripTrek.Models.Transport", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Duration")
                        .HasColumnType("datetime");

                    b.Property<int?>("FromLocationId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<int?>("ToLocationId")
                        .HasColumnType("int");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Transports");
                });

            modelBuilder.Entity("TripTrek.Models.TransportType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TransportTypes");
                });

            modelBuilder.Entity("TripTrek.Models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<decimal?>("Budget")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<DateTime?>("DateOfReturn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("PersonsNr")
                        .HasColumnType("int");

                    b.Property<int>("TouristSpotsId")
                        .HasColumnType("int");

                    b.Property<int?>("TransportId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Trip");

                    b.HasIndex("HotelId");

                    b.HasIndex("LocationId");

                    b.HasIndex("TouristSpotsId");

                    b.HasIndex("TransportId");

                    b.HasIndex("UserId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("TripTrek.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_User");

                    b.HasIndex("AccountId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TripTrek.Models.Hotel", b =>
                {
                    b.HasOne("TripTrek.Models.Address", "Address")
                        .WithMany("Hotels")
                        .HasForeignKey("AddressId")
                        .HasConstraintName("FK_Hotels_Addresses");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("TripTrek.Models.TouristSpot", b =>
                {
                    b.HasOne("TripTrek.Models.Address", "Address")
                        .WithMany("TouristSpots")
                        .HasForeignKey("AddressId")
                        .HasConstraintName("FK_TouristSpots_Addresses");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("TripTrek.Models.Transport", b =>
                {
                    b.HasOne("TripTrek.Models.TransportType", "Type")
                        .WithMany("Transports")
                        .HasForeignKey("TypeId")
                        .HasConstraintName("FK_Transports_TransportTypes");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("TripTrek.Models.Trip", b =>
                {
                    b.HasOne("TripTrek.Models.Hotel", "Hotel")
                        .WithMany("Trips")
                        .HasForeignKey("HotelId")
                        .HasConstraintName("FK_Trips_Hotels");

                    b.HasOne("TripTrek.Models.Location", "Location")
                        .WithMany("Trips")
                        .HasForeignKey("LocationId")
                        .IsRequired()
                        .HasConstraintName("FK_Trips_Locations");

                    b.HasOne("TripTrek.Models.TouristSpot", "TouristSpots")
                        .WithMany("Trips")
                        .HasForeignKey("TouristSpotsId")
                        .IsRequired()
                        .HasConstraintName("FK_Trips_TouristSpots");

                    b.HasOne("TripTrek.Models.Transport", "Transport")
                        .WithMany("Trips")
                        .HasForeignKey("TransportId")
                        .HasConstraintName("FK_Trips_Transport");

                    b.HasOne("TripTrek.Models.User", "User")
                        .WithMany("Trips")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Trips_Users");

                    b.Navigation("Hotel");

                    b.Navigation("Location");

                    b.Navigation("TouristSpots");

                    b.Navigation("Transport");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TripTrek.Models.User", b =>
                {
                    b.HasOne("TripTrek.Models.Account", "Account")
                        .WithMany("Users")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("FK_Users_Accounts");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("TripTrek.Models.Account", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("TripTrek.Models.Address", b =>
                {
                    b.Navigation("Hotels");

                    b.Navigation("TouristSpots");
                });

            modelBuilder.Entity("TripTrek.Models.Hotel", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("TripTrek.Models.Location", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("TripTrek.Models.TouristSpot", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("TripTrek.Models.Transport", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("TripTrek.Models.TransportType", b =>
                {
                    b.Navigation("Transports");
                });

            modelBuilder.Entity("TripTrek.Models.User", b =>
                {
                    b.Navigation("Trips");
                });
#pragma warning restore 612, 618
        }
    }
}
