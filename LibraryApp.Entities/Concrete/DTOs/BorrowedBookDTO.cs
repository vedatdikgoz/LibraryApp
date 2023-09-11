using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entities.Concrete.DTOs
{
    public class BorrowedBookDTO
    {
        public string BorrowerName { get; set; }
        public DateTime ReturnDate { get; set; }
        public int BookId { get; set; }
    }
}
