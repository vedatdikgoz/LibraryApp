

namespace LibraryApp.Entities.Concrete
{
    public class BorrowedBook
    {
        public int BorrowedBookId { get; set; }
        public string BorrowerName { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int BookId {  get; set; }
        public Book Book { get; set; }
    }
}
