using Microsoft.EntityFrameworkCore;

namespace FastStart.Entities
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
            {
            }
    /*    private string _connectionString =
            "Server=tcp:usersfbo.database.windows.net,1433;Initial Catalog=usersfbo;Persist Security Info=False;User ID=p_markiewicz;Password=S€cr€t_P@ssw0rds;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
     */ 
        public DbSet<Users> Users { get; set; }

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
    /*    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    */
    }
}