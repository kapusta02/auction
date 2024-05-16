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
    [Migration("20240516141929_UpdateTimeSecond")]
    partial class UpdateTimeSecond
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
                            Id = new Guid("1c815e59-f915-4d70-980f-7f4ed8d9b8fb"),
                            Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Earum, voluptas!",
                            Images = "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user",
                            Name = "Lot #1",
                            StartPrice = 937.1m,
                            Tags = "Test",
                            TradingDuration = new TimeSpan(2, 0, 0, 0, 0),
                            TradingStart = new DateTime(2020, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("60ddc68a-c9b6-4f03-9e03-e4d2330908d9")
                        },
                        new
                        {
                            Id = new Guid("4fd933ee-031c-4c78-a290-6304f31334cf"),
                            Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Earum, voluptas!",
                            Images = "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user",
                            Name = "Lot #1",
                            StartPrice = 937.1m,
                            Tags = "Test",
                            TradingDuration = new TimeSpan(2, 0, 0, 0, 0),
                            TradingStart = new DateTime(2020, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("8b1cf396-20dc-4137-bfce-f8dfef451e66")
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
                            Id = new Guid("b7586b69-1122-42e9-80fb-75bd44a1cd49"),
                            Balance = 1000000.0m,
                            Currency = "Kaspi Coin",
                            UserId = new Guid("deb87b47-3c96-4f87-a14a-dbbc018f4dcf")
                        },
                        new
                        {
                            Id = new Guid("d0d1e513-daba-484b-936d-a88a27e7909b"),
                            Balance = 1004300.0m,
                            Currency = "Kaspi Coin",
                            UserId = new Guid("96f5c4b7-40df-4530-8cee-182d54c9d29f")
                        },
                        new
                        {
                            Id = new Guid("7e344ca9-f0d0-4144-afc4-bab271d7a8c1"),
                            Balance = 1023100.0m,
                            Currency = "Kaspi Coin",
                            UserId = new Guid("5fe86c91-eaca-40e2-bcf1-3ed7868b82bc")
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
