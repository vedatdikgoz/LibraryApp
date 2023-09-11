using LibraryApp.Business.Abstract;
using LibraryApp.DataAccess.Abstract;
using LibraryApp.Entities.Concrete;
using LibraryApp.Entities.Concrete.DTOs;

namespace LibraryApp.Business.Concrete
{
    public class BorrowedBookManager : IBorrowedBookService
    {
        private readonly IBorrowedBookRepository _borrowedBookRepository;
        public BorrowedBookManager(IBorrowedBookRepository borrowedBookRepository)
        {
            _borrowedBookRepository = borrowedBookRepository;
        }

        public List<BorrowedBookDTO> BorrowedBookList()
        {
            return _borrowedBookRepository.BorrowedBookList();
        }

        public void Create(BorrowedBook entity)
        {
            _borrowedBookRepository.Create(entity);
        }

    }
}
