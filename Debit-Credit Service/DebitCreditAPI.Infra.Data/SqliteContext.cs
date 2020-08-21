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
            modelBuilder.Entity<Entry>()
                .HasOne(p => p.OriginAccount)
                .WithMany(b => b.Entries)
                .HasForeignKey(p => p.OriginAccountId);

            modelBuilder.Entity<Entry>()
                .HasOne(p => p.DestinyAccount)
                .WithMany(b => b.Entries)
                .HasForeignKey(p => p.DestinyAccountId);

            modelBuilder.Entity<Account>()
                .HasIndex(p => p.AccountNumber)
                .IsUnique();
        }
    }
}
