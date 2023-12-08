﻿// <auto-generated />
using System;
using Expedia.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Expedia.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Expedia.Entities.Airline", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(true);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Airlines", (string)null);
                });

            modelBuilder.Entity("Expedia.Entities.BankCard", b =>
                {
                    b.Property<string>("CardNumber")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Company")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpireDate")
                        .HasPrecision(2)
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("CardNumber", "Company");

                    b.HasIndex("CustomerId");

                    b.ToTable("BankCards", (string)null);
                });

            modelBuilder.Entity("Expedia.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.HasKey("Id");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("Expedia.Entities.Flight", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("AirlineId")
                        .HasColumnType("int");

                    b.Property<string>("AirplaneName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.HasIndex("AirlineId");

                    b.ToTable("Flights", null, t =>
                        {
                            t.HasCheckConstraint("CK_NumberOfSeatsGreaterThanZeroAndLessThan1000", "NumberOfSeats >= 0 AND NumberOfSeats <= 1000");
                        });
                });

            modelBuilder.Entity("Expedia.Entities.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar");

                    b.Property<int>("NumberOfStars")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Hotels", null, t =>
                        {
                            t.HasCheckConstraint("CK_NumberOfStarsBetweenOneAndFiveStars", "NumberOfStars BETWEEN 1 AND 5");
                        });
                });

            modelBuilder.Entity("Expedia.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Cost")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsSelected")
                        .HasColumnType("bit");

                    b.Property<string>("ReservationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Reservations", (string)null);

                    b.HasDiscriminator<string>("ReservationType").HasValue("Reservation");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Expedia.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Capicity")
                        .HasColumnType("int");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Rooms", (string)null);
                });

            modelBuilder.Entity("Expedia.Entities.FlightReservation", b =>
                {
                    b.HasBaseType("Expedia.Entities.Reservation");

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<string>("FromCity")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.Property<string>("ToCity")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.HasIndex("FlightId")
                        .IsUnique()
                        .HasFilter("[FlightId] IS NOT NULL");

                    b.HasDiscriminator().HasValue("Flight");
                });

            modelBuilder.Entity("Expedia.Entities.RoomReservation", b =>
                {
                    b.HasBaseType("Expedia.Entities.Reservation");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasIndex("RoomId")
                        .IsUnique()
                        .HasFilter("[RoomId] IS NOT NULL");

                    b.HasDiscriminator().HasValue("Room");
                });

            modelBuilder.Entity("Expedia.Entities.BankCard", b =>
                {
                    b.HasOne("Expedia.Entities.Customer", "Customer")
                        .WithMany("BankCards")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Expedia.Entities.Flight", b =>
                {
                    b.HasOne("Expedia.Entities.Airline", "Airline")
                        .WithMany("Flights")
                        .HasForeignKey("AirlineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airline");
                });

            modelBuilder.Entity("Expedia.Entities.Reservation", b =>
                {
                    b.HasOne("Expedia.Entities.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId");

                    b.OwnsOne("Expedia.Entities.Period", "Period", b1 =>
                        {
                            b1.Property<int>("ReservationId")
                                .HasColumnType("int");

                            b1.Property<DateTime>("EndDate")
                                .HasPrecision(2)
                                .HasColumnType("datetime2")
                                .HasColumnName("EndDate");

                            b1.Property<DateTime>("StartDate")
                                .HasPrecision(2)
                                .HasColumnType("datetime2")
                                .HasColumnName("StartDate");

                            b1.HasKey("ReservationId");

                            b1.ToTable("Reservations");

                            b1.WithOwner()
                                .HasForeignKey("ReservationId");
                        });

                    b.Navigation("Customer");

                    b.Navigation("Period")
                        .IsRequired();
                });

            modelBuilder.Entity("Expedia.Entities.Room", b =>
                {
                    b.HasOne("Expedia.Entities.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Expedia.Entities.FlightReservation", b =>
                {
                    b.HasOne("Expedia.Entities.Flight", "Flight")
                        .WithOne("FlightReservation")
                        .HasForeignKey("Expedia.Entities.FlightReservation", "FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("Expedia.Entities.RoomReservation", b =>
                {
                    b.HasOne("Expedia.Entities.Room", "Room")
                        .WithOne("RoomReservation")
                        .HasForeignKey("Expedia.Entities.RoomReservation", "RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Expedia.Entities.Airline", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("Expedia.Entities.Customer", b =>
                {
                    b.Navigation("BankCards");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Expedia.Entities.Flight", b =>
                {
                    b.Navigation("FlightReservation")
                        .IsRequired();
                });

            modelBuilder.Entity("Expedia.Entities.Hotel", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Expedia.Entities.Room", b =>
                {
                    b.Navigation("RoomReservation")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
