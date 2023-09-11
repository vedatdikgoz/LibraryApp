using LibraryApp.Business.Abstract;
using LibraryApp.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IBorrowedBookService _borrowedBookService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IBookService bookService, IBorrowedBookService borrowedBookService)
        {
            _logger = logger;
            _bookService = bookService;
            _borrowedBookService = borrowedBookService;
        }

        public IActionResult Index()
        {
            try
            {
                var books = _bookService.GetAll();
                var borrowedBookList = _borrowedBookService.BorrowedBookList();
                ViewBag.BorrowedBookList = borrowedBookList;
                return View(books);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }
            return View();

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book newBook, IFormFile file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return View(newBook);
                }

                var book = new Book()
                {
                    BookName = newBook.BookName,
                    Author = newBook.Author,
                    IsAvailable = true
                };
                if (file != null)
                {
                    //resim ekleme işlemleri
                    var newName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    book.ImageUrl = newName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", newName);
                    var stream = new FileStream(path, FileMode.Create);
                    await file.CopyToAsync(stream);

                }
                _bookService.Create(book);
                _logger.LogInformation("Yeni kitap eklendi");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return RedirectToAction("Index", "Home");
        }




        [HttpGet]
        public IActionResult BorrowBook(int id)
        {
            ViewBag.BookId = id;  //viewbag ile ödünç verilecek kitabın id sini modele taşıma
            return View();
        }

        [HttpPost]
        public IActionResult BorrowBook(BorrowedBook newborrowedBook)
        {
            try
            {
                var borrowedBook = new BorrowedBook()
                {
                    BookId = newborrowedBook.BookId,
                    BorrowerName = newborrowedBook.BorrowerName,
                    BorrowDate = DateTime.Now,
                    ReturnDate = newborrowedBook.ReturnDate,
                };
                _borrowedBookService.Create(borrowedBook);
                _logger.LogInformation($"{borrowedBook.BookId} nolu kitap ödünç verildi");

                //TODO book tablosunda IsAvailable durumunu güncelleme? işlemleri
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }
            

            return RedirectToAction("Index", "Home");
        }
    }
}