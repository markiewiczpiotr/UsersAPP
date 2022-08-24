using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FastStart.Entities
{
    public class UsersDbContext : DbContext
    {
        private string _connectionString =
            "Server = tcp:usersfbo.database.windows.net,1433;Initial Catalog = usersfbo; Persist Security Info=False;User ID = p_markiewicz; Password=S€cr€tP@ssw0rd; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";
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
                .Property(u => u.eMail)
                .IsRequired();

            modelBuilder.Entity<Users>()
                .Property(u => u.nrFBO)
                .IsRequired()
                .HasMaxLength(12);

            modelBuilder.Entity<Users>()
                .Property(u => u.nrTel)
                .IsRequired()
                .HasMaxLength(14);

            modelBuilder.Entity<Users>()
                .Property(u => u.Rola);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}