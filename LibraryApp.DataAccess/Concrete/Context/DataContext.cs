using LibraryApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;


namespace LibraryApp.DataAccess.Concrete.Context
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //veritabanı bağlantısı
            optionsBuilder.UseSqlServer("Data Source = VEDAT\\SQLEXPRESS; Database=LibraryDb; Trusted_Connection=true; TrustServerCertificate=True;");
            
        }


        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set; }
    }
}
