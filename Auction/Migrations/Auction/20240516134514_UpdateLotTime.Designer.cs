﻿// <auto-generated />
using System;
using Auction.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Auction.Migrations.Auction
{
    [DbContext(typeof(AuctionContext))]
    [Migration("20240516134514_UpdateLotTime")]
    partial class UpdateLotTime
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.19");

            modelBuilder.Entity("Auction.Entities.Lot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.Property<string>("Images")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("StartPrice")
                        .HasMaxLength(4)
                        .HasColumnType("TEXT");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("TradingDuration")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TradingStart")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasMaxLength(36)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Lot");

                    b.HasData(
                        new
                        {
                            Id = new Guid("75d6586a-21cc-452f-b60f-e4cd4272ad96"),
                            Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Earum, voluptas!",
                            Images = "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user",
                            Name = "Lot #1",
                            StartPrice = 937.1m,
                            Tags = "Test",
                            TradingDuration = new TimeSpan(2),
                            TradingStart = new DateTime(2020, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("48959c77-c314-43cf-8d72-aa3c6aff2ab3")
                        },
                        new
                        {
                            Id = new Guid("18cbd317-b831-467c-b90b-f950fb9453fe"),
                            Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Earum, voluptas!",
                            Images = "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user",
                            Name = "Lot #1",
                            StartPrice = 937.1m,
                            Tags = "Test",
                            TradingDuration = new TimeSpan(2, 0, 0, 0, 0),
                            TradingStart = new DateTime(2020, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("38b0d50c-6e1d-41e8-af5d-cc2cea8708ae")
                        });
                });

            modelBuilder.Entity("Auction.Entities.Wallet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasMaxLength(36)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Wallet");

                    b.HasData(
                        new
                        {
                            Id = new Guid("34c87c8c-73d6-430a-907b-6286fbc0ebcd"),
                            Balance = 1000000.0m,
                            Currency = "Kaspi Coin",
                            UserId = new Guid("466a0766-7b8c-4bdc-b6c4-f99410eadd26")
                        },
                        new
                        {
                            Id = new Guid("b672a33c-1f46-4f60-aac9-2a6f353ed9a6"),
                            Balance = 1004300.0m,
                            Currency = "Kaspi Coin",
                            UserId = new Guid("ee22f658-e25e-4265-9afb-09132f2178f9")
                        },
                        new
                        {
                            Id = new Guid("5432d021-ef7b-4df7-9a9b-bcde0f588ec7"),
                            Balance = 1023100.0m,
                            Currency = "Kaspi Coin",
                            UserId = new Guid("9b11d45c-752d-45e4-9df5-9b8190777ca5")
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
