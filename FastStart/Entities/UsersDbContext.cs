using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FastStart.Entities
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .Property(u => u.Imie)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Users>()
                .Property(u => u.Nazwisko)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Users>()
               .Property(u => u.DataUrodzenia);

            modelBuilder.Entity<Users>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<Users>()
                .Property(u => u.NrFBO)
                .IsRequired()
                .HasMaxLength(12);

            modelBuilder.Entity<Users>()
                .Property(u => u.NrTel)
                .IsRequired()
                .HasMaxLength(14);

            modelBuilder.Entity<Users>()
                .Property(u => u.Rola);
        }
    }
}