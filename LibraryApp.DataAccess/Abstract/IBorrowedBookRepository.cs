using LibraryApp.Entities.Concrete;
using LibraryApp.Entities.Concrete.DTOs;

namespace LibraryApp.DataAccess.Abstract
{
    public interface IBorrowedBookRepository : IEntityRepository<BorrowedBook>
    {
         List<BorrowedBookDTO> BorrowedBookList();
    }
}
