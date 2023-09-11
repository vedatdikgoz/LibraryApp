using LibraryApp.DataAccess.Abstract;
using LibraryApp.DataAccess.Concrete.Context;
using LibraryApp.Entities.Concrete;

namespace LibraryApp.DataAccess.Concrete.EntityFramework
{
    public class EfBookRepository : EfEntityRepositoryBase<Book, DataContext>, IBookRepository
    {
    }
}
