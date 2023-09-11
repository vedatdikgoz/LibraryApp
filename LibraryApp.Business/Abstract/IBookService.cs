using LibraryApp.Entities.Concrete;


namespace LibraryApp.Business.Abstract
{
    public interface IBookService
    {
        Book GetById(int id);
        List<Book> GetAll();
        void Create(Book entity);
    }
}
