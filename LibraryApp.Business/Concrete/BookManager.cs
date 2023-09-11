using LibraryApp.Business.Abstract;
using LibraryApp.DataAccess.Abstract;
using LibraryApp.Entities.Concrete;


namespace LibraryApp.Business.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookManager(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void Create(Book entity)
        {
            _bookRepository.Create(entity);
        }

        public List<Book> GetAll()
        {
            return _bookRepository.GetAll().OrderBy(book => book.BookName).ToList(); //alfebetik sıra ile listeleme işlemi
        }

        public Book GetById(int id)
        {
            return _bookRepository.GetById(id);
        }
    }
}
