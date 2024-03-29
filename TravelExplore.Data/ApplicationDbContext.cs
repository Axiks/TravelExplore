﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata;
using TravelExplore.Data.Entities;

namespace TravelExplore.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString;

        public ApplicationDbContext(String connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_connectionString);
        }

        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerEntity>()
                .HasMany(e => e.Orders)
                .WithOne(e => e.Customer);

            modelBuilder.Entity<OrderEntity>()
                .HasOne(e => e.Customer)
                .WithMany(e => e.Orders)
                .IsRequired();
        }
    }
}
