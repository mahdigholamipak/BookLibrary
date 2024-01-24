using BookLibrary.Models;
using BookLibrary.Models.ViewModels;
using BookLibrary.Repositories;
using BookLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace BookLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookService _bookService;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, IBookService bookService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {

            ICollection<Book> books = await _unitOfWork.Books.GetAllBooksAsync();
            ICollection<BookViewModel> booksViewModel = await _bookService.GetBookViewModelsFromModelsAsync(books);

            return View(booksViewModel);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}