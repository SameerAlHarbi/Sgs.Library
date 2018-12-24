using Microsoft.EntityFrameworkCore;
using Sgs.Library.Model;

namespace Sgs.Library.DataAccess
{
    public class LibraryDB : DbContext
    {
        public LibraryDB(DbContextOptions<LibraryDB> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Map> Maps { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<Periodical> Periodicals { get; set; }

        public DbSet<Borrow> Borrowings { get; set; }

        public DbSet<ReportType> ReportsTypes { get; set; }

        public DbSet<MapType> MapsTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
