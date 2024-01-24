using BookLibrary.Models;
using BookLibrary.Models.ViewModels;
using BookLibrary.Repositories;
using BookLibrary.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;


namespace BookLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookService _bookService;
        private readonly UserManager<User> _userManager;
        public BookController(IUnitOfWork unitOfWork, IBookService bookService, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _bookService = bookService;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                Book book = await _bookService.GetBookModelFromViewModelAsync(bookViewModel);
                book.UserId = _userManager.GetUserId(User);
                await _unitOfWork.Books.AddBookAsync(book);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction("Index", "Home");
            }


            return View(bookViewModel);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int Id)
        {
            Book book = await _unitOfWork.Books.GetBookAsync(Id);
            BookViewModel bookViewModel = await _bookService.GetBookViewModelFromModelAsync(book);

            if (book == null)
            {
                return NotFound();
            }

            return View(bookViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(BookViewModel bookViewModel)
        {
            if (bookViewModel == null)
            {
                return NotFound();
            }
            Book existingBook = await _bookService.GetBookModelFromViewModelAsync(bookViewModel);
            existingBook.UserId = _userManager.GetUserId(User);
            _unitOfWork.Books.UpdateBook(existingBook);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Remove(int Id)
        {
            Book book = await _unitOfWork.Books.GetBookAsync(Id);
            BookViewModel bookViewModel = await _bookService.GetBookViewModelFromModelAsync(book);

            if (book == null)
            {
                return NotFound();
            }

            return View(bookViewModel);
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(BookViewModel bookViewModel)
        {
            if (bookViewModel == null)
            {
                return NotFound();
            }
            Book existingBook = await _bookService.GetBookModelFromViewModelAsync(bookViewModel);
            _unitOfWork.Books.RemoveBook(existingBook);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]

        public async Task<IActionResult> Search(string query)
        {
            ICollection<Book> books = await _unitOfWork.Books.FindBooksAsync(book => book.Title.Contains(query));
            ICollection<BookViewModel> booksViewModel = await _bookService.GetBookViewModelsFromModelsAsync(books);


            ViewBag.Query = query;

            return View(booksViewModel);
        }
    }
}
