using Bank.API.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank.API.Data
{
    public class AccountInfoContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Deposit> Deposits { get; set; }

        public AccountInfoContext(DbContextOptions<AccountInfoContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasData(
                new Account()
                {
                    Id = 1,
                    FirstName = "Ioana",
                    LastName = "Gabor",
                    Sum = 2500,
                    UserId = 1
                },
                 new Account()
                 {
                     Id = 2,
                     FirstName = "Carmen",
                     LastName = "Pavel",
                     Sum = 3200,
                     UserId = 2
                 },
                new Account()
                {
                    Id = 3,
                    FirstName = "Carmen",
                    LastName = "Pavel",
                    Sum = 200,
                    UserId = 2
                },
                new Account()
                {
                    Id = 4,
                    FirstName = "Ioana",
                    LastName = "Gabor",
                    Sum = 2800,
                    UserId = 1
                });

            modelBuilder.Entity<Deposit>()
                .HasData(
                new Deposit()
                {
                    Id = 1,
                    AccountId = 1,
                    Name = "Savings Deposit",
                    Period = 1,
                    DepositSum = 2000
                },
                new Deposit()
                {
                    Id = 2,
                    AccountId = 1,
                    Name = "Fixed Deposit",
                    Period = 12,
                    DepositSum = 500
                },
                new Deposit()
                {
                    Id = 3,
                    AccountId = 2,
                    Name = "Fixed Deposit",
                    Period = 6,
                    DepositSum = 2200
                },
                new Deposit()
                {
                    Id = 4,
                    AccountId = 2,
                    Name = "Recurring Deposit",
                    Period = 1,
                    DepositSum = 1000
                },
                new Deposit()
                {
                    Id = 5,
                    AccountId = 3,
                    Name = "Savings Deposit",
                    Period = 12,
                    DepositSum = 1200
                },
                new Deposit()
                {
                    Id = 6,
                    AccountId = 3,
                    Name = "Current Deposit",
                    Period = 6,
                    DepositSum = 1600
                },
                 new Deposit()
                 {
                     Id = 7,
                     AccountId = 4,
                     Name = "Recurring Deposit",
                     Period = 6,
                     DepositSum = 100
                 },
                new Deposit()
                {
                    Id = 8,
                    AccountId = 4,
                    Name = "Savings Deposit",
                    Period = 12,
                    DepositSum = 12
                });


            modelBuilder.Entity<User>()
                .HasData(
                new User()
                {
                    Id = 1,
                    FirstName = "Ioana",
                    LastName = "Gabor",
                    Email = "ioanagabor@gmail.com",
                    Username = "ioanagabor",
                    Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f",
                    Admin = false
                },
                new User()
                {
                    Id = 2,
                    FirstName = "Carmen",
                    LastName = "Pavel",
                    Email = "carmen2411@gmail.com",
                    Username = "pavelcarmen",
                    Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f",
                    Admin = false
                },
                new User()
                {
                    Id = 3,
                    FirstName = "Andreea",
                    LastName = "Gabor",
                    Email = "andreeagabor@gmail.com",
                    Username = "deeagabor",
                    Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f",
                    Admin = true
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
