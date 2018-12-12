using Microsoft.EntityFrameworkCore;
using Sgs.Library.Model;

namespace Sgs.Library.DataAccess
{
    public class LibraryDB : DbContext
    {
        public LibraryDB(DbContextOptions<LibraryDB> options) : base(options)
        {
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
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Map>().ToTable("Maps");
            modelBuilder.Entity<Report>().ToTable("Reports");
            modelBuilder.Entity<Periodical>().ToTable("Periodicals");
        }

    }
}
