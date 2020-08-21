using DebitCreditAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebitCreditAPI.Infra.Data
{
    public class SqliteContext :DbContext
    {
        public SqliteContext()
        {
        }

        public SqliteContext(DbContextOptions<SqliteContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Entry> Entries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>()
                .HasMany(p => p.OriginEntries)
                .WithOne(b => b.OriginAccount)
                .HasForeignKey(c => c.OriginAccountId);
            modelBuilder.Entity<Account>()
                .HasMany(p => p.DestinyEntries)
                .WithOne(b => b.DestinyAccount)
                .HasForeignKey(c => c.DestinyAccountId);

            modelBuilder.Entity<Entry>()
                .HasOne(p => p.OriginAccount)
                .WithMany(b => b.OriginEntries)
                .HasForeignKey(c => c.OriginAccountId);

            modelBuilder.Entity<Entry>()
                .HasOne(p => p.DestinyAccount)
                .WithMany(b => b.DestinyEntries)
                .HasForeignKey(c => c.DestinyAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Account>()
                .HasIndex(p => p.AccountNumber)
                .IsUnique();
        }
    }
}
