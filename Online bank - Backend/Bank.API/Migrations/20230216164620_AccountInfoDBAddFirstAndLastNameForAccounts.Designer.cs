﻿// <auto-generated />
using Bank.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bank.API.Migrations
{
    [DbContext(typeof(AccountInfoContext))]
    [Migration("20230216164620_AccountInfoDBAddFirstAndLastNameForAccounts")]
    partial class AccountInfoDBAddFirstAndLastNameForAccounts
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bank.API.Repository.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("Sum")
                        .HasColumnType("real");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Ioana",
                            LastName = "Gabor",
                            Sum = 2500f,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Carmen",
                            LastName = "Pavel",
                            Sum = 3200f,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Carmen",
                            LastName = "Pavel",
                            Sum = 200f,
                            UserId = 2
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Ioana",
                            LastName = "Gabor",
                            Sum = 2800f,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Bank.API.Repository.Entities.Deposit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<float>("DepositSum")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Deposits");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountId = 1,
                            DepositSum = 2000f,
                            Name = "Savings Deposit",
                            Period = 1
                        },
                        new
                        {
                            Id = 2,
                            AccountId = 1,
                            DepositSum = 500f,
                            Name = "Fixed Deposit",
                            Period = 12
                        },
                        new
                        {
                            Id = 3,
                            AccountId = 2,
                            DepositSum = 2200f,
                            Name = "Fixed Deposit",
                            Period = 6
                        },
                        new
                        {
                            Id = 4,
                            AccountId = 2,
                            DepositSum = 1000f,
                            Name = "Recurring Deposit",
                            Period = 1
                        },
                        new
                        {
                            Id = 5,
                            AccountId = 3,
                            DepositSum = 1200f,
                            Name = "Savings Deposit",
                            Period = 12
                        },
                        new
                        {
                            Id = 6,
                            AccountId = 3,
                            DepositSum = 1600f,
                            Name = "Current Deposit",
                            Period = 6
                        },
                        new
                        {
                            Id = 7,
                            AccountId = 4,
                            DepositSum = 100f,
                            Name = "Recurring Deposit",
                            Period = 6
                        },
                        new
                        {
                            Id = 8,
                            AccountId = 4,
                            DepositSum = 12f,
                            Name = "Savings Deposit",
                            Period = 12
                        });
                });

            modelBuilder.Entity("Bank.API.Repository.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Admin = false,
                            Email = "ioanagabor@gmail.com",
                            FirstName = "Ioana",
                            LastName = "Gabor",
                            Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f",
                            Username = "ioanagabor"
                        },
                        new
                        {
                            Id = 2,
                            Admin = false,
                            Email = "carmen2411@gmail.com",
                            FirstName = "Carmen",
                            LastName = "Pavel",
                            Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f",
                            Username = "pavelcarmen"
                        },
                        new
                        {
                            Id = 3,
                            Admin = true,
                            Email = "andreeagabor@gmail.com",
                            FirstName = "Andreea",
                            LastName = "Gabor",
                            Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f",
                            Username = "deeagabor"
                        });
                });

            modelBuilder.Entity("Bank.API.Repository.Entities.Account", b =>
                {
                    b.HasOne("Bank.API.Repository.Entities.User", null)
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bank.API.Repository.Entities.Deposit", b =>
                {
                    b.HasOne("Bank.API.Repository.Entities.Account", "Account")
                        .WithMany("Deposits")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Bank.API.Repository.Entities.Account", b =>
                {
                    b.Navigation("Deposits");
                });

            modelBuilder.Entity("Bank.API.Repository.Entities.User", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
