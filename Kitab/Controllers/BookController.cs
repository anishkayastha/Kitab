using Kitab.Data;
using Kitab.Data.Services;
using Kitab.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Kitab.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            /*var allbooks = _context.Books.Include(n => n.Publisher).OrderBy(n => n.Title).ToList();*/
            //LINQ - Table join garne ani chahiteko 
            //ViewBag
            var allBooks = await _service.GetAllAsync(n => n.Publisher!);
            return View(allBooks);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allBooks = await _service.GetAllAsync(n => n.Publisher!);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allBooks.Where(n => n.Title!.ToLower().Contains(searchString.ToLower()) || n.Description!.ToLower().Contains
                    (searchString.ToLower())).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", allBooks);
        }

        //GET: Book/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var bookDetails = await _service.GetBookByIdAsync(id);
            return View(bookDetails);
        }

        //GET: Books/Create
        public async Task<IActionResult> Create()
        {
            var bookDropdownsData = await _service.GetNewBookDropdownsValues();

            ViewBag.Publishers = new SelectList(bookDropdownsData.Publishers, "Id", "Name");
            ViewBag.Categories = new SelectList(bookDropdownsData.Categories, "Id", "Name");
            ViewBag.Authors = new SelectList(bookDropdownsData.Authors, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewBookVM book)
        {
            if (!ModelState.IsValid)
            {
                var bookDropdownsData = await _service.GetNewBookDropdownsValues();

                ViewBag.Publishers = new SelectList(bookDropdownsData.Publishers, "Id", "Name");
                ViewBag.Categories = new SelectList(bookDropdownsData.Categories, "Id", "Name");
                ViewBag.Authors = new SelectList(bookDropdownsData.Authors, "Id", "FullName");

                return View(book);
            }

            await _service.AddNewBookAsync(book);
            return RedirectToAction(nameof(Index));
        }

        //GET: Books/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var bookDetails = await _service.GetBookByIdAsync(id);
            if (bookDetails == null)
                return View("NotFound");

            var response = new NewBookVM()
            {
                Id = bookDetails.Id,
                Title = bookDetails.Title,
                Description = bookDetails.Description,
                Price = bookDetails.Price,
                PublishedDate = bookDetails.PublishedDate,
                ImageURL = bookDetails.ImageURL,
                PublisherId = bookDetails.PublisherId,
                AuthorIds = bookDetails.Authors_Books!.Select(n => n.AuthorId).ToList(),
                CategoryIds = bookDetails.Categories_Books!.Select(n => n.CategoryId).ToList()
            };
            
            var bookDropdownsData = await _service.GetNewBookDropdownsValues();

            ViewBag.Publishers = new SelectList(bookDropdownsData.Publishers, "Id", "Name");
            ViewBag.Categories = new SelectList(bookDropdownsData.Categories, "Id", "Name");
            ViewBag.Authors = new SelectList(bookDropdownsData.Authors, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewBookVM book)
        {
            if (id != book.Id)
                return View("NotFound");

            if (!ModelState.IsValid)
            {
                var bookDropdownsData = await _service.GetNewBookDropdownsValues();

                ViewBag.Publishers = new SelectList(bookDropdownsData.Publishers, "Id", "Name");
                ViewBag.Categories = new SelectList(bookDropdownsData.Categories, "Id", "Name");
                ViewBag.Authors = new SelectList(bookDropdownsData.Authors, "Id", "FullName");

                return View(book);
            }

            await _service.UpdateBookAsync(book);
            return RedirectToAction(nameof(Index));
        }
    }
}
