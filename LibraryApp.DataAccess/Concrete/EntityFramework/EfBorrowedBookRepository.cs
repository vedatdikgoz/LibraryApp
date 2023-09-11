using LibraryApp.DataAccess.Abstract;
using LibraryApp.DataAccess.Concrete.Context;
using LibraryApp.DataAccess.Migrations;
using LibraryApp.Entities.Concrete;
using LibraryApp.Entities.Concrete.DTOs;


namespace LibraryApp.DataAccess.Concrete.EntityFramework
{
    public class EfBorrowedBookRepository : EfEntityRepositoryBase<BorrowedBook, DataContext>, IBorrowedBookRepository
    {
    
        public List<BorrowedBookDTO> BorrowedBookList()
        {
            using (DataContext context = new DataContext())
            {
                //Bu sorgu, BorrowedBooks tablosunu önce BookId'ye göre gruplar,
                //her grup için en büyük ReturnDate değerini bulur, sonra bu bilgileri
                //kullanarak iki tabloyu birleştirir ve BookId, BorrowerName ve ReturnDate değerlerini alır.
                var result = context.BorrowedBooks
                                    .GroupBy(b => b.BookId)
                                    .Select(g => new
                                      {
                                        BookId = g.Key,
                                        MaxReturnDate = g.Max(b => b.ReturnDate)
                                    })
                                    .Join(
                                           context.BorrowedBooks,
                                           b => new { b.BookId, ReturnDate = b.MaxReturnDate },
                                           bb => new { bb.BookId, bb.ReturnDate },
                                           (b, bb) => new
                                             {
                                               b.BookId,
                                               b.MaxReturnDate,
                                               bb.BorrowerName
                                              }
                                           ).ToList();

               
                List<BorrowedBookDTO> borrowedBookDTOList = new();
                foreach (var item in result)
                {
                    BorrowedBookDTO borrowedBookDTO = new()
                    {
                        BookId = item.BookId,
                        BorrowerName = item.BorrowerName,
                        ReturnDate = item.MaxReturnDate
                    };

                    borrowedBookDTOList.Add(borrowedBookDTO);
                }

                return borrowedBookDTOList;
            }
        }
    }
}
