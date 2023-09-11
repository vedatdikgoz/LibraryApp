using LibraryApp.Entities.Concrete;
using LibraryApp.Entities.Concrete.DTOs;


namespace LibraryApp.Business.Abstract
{
    public interface IBorrowedBookService
    {
        void Create(BorrowedBook entity);
        List<BorrowedBookDTO> BorrowedBookList();
    }
}
