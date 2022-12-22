using Kitab.Data.Base;
using Kitab.Data.ViewModels;
using Kitab.Models;
using Microsoft.EntityFrameworkCore;

namespace Kitab.Data.Services
{
    public class BookService : EntityBaseRepository<Book>, IBookService
    {
        private readonly KitabDbContext _context;
        public BookService(KitabDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewBookAsync(NewBookVM data)
        {
            var newBook = new Book()
            {
                Title = data.Title,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                PublishedDate = data.PublishedDate,
                PublisherId = data.PublisherId
            };

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            //Add Categories
            foreach (var categoryId in data.CategoryIds!)
            {
                var newCategoryBook = new Category_Book()
                {
                    BookId = newBook.Id,
                    CategoryId = categoryId
                };
                await _context.Categories_Books.AddAsync(newCategoryBook);
            }
            await _context.SaveChangesAsync();
            
            //Add Authors
            foreach (var authorId in data.AuthorIds!)
            {
                var newAuthorBook = new Author_Book()
                {
                    BookId = newBook.Id,
                    AuthorId = authorId
                };
                await _context.Authors_Books.AddAsync(newAuthorBook);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var bookDetails = await _context.Books
                .Include(p => p.Publisher)
                .Include(cb => cb.Categories_Books!).ThenInclude(c => c.Category)
                .Include(ab => ab.Authors_Books!).ThenInclude(a => a.Author)
                .FirstOrDefaultAsync(n => n.Id == id);

            return bookDetails!;
        }

        public async Task<NewBookDropdownsVM> GetNewBookDropdownsValues()
        {
            var response = new NewBookDropdownsVM()
            {
                Authors = await _context.Authors.OrderBy(n => n.FullName).ToListAsync(),
                Categories = await _context.Categories.OrderBy(n => n.Name).ToListAsync(),
                Publishers = await _context.Publishers.OrderBy(n => n.Name).ToListAsync()
            };

            return response;
        }

        public async Task UpdateBookAsync(NewBookVM data)
        {
            var dbBook = await _context.Books.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbBook != null)
            {
                dbBook.Title = data.Title;
                dbBook.Description = data.Description;
                dbBook.Price = data.Price;
                dbBook.ImageURL = data.ImageURL;
                dbBook.PublishedDate = data.PublishedDate;
                dbBook.PublisherId = data.PublisherId;

                await _context.SaveChangesAsync();
            }

            //Remove existing authors
            var existingAuthorsDb = _context.Authors_Books.Where(n => n.BookId == data.Id).ToList();
            _context.Authors_Books.RemoveRange(existingAuthorsDb);
            await _context.SaveChangesAsync();

            //Remove existing categories
            var existingCategoriesDb = _context.Categories_Books.Where(n => n.BookId == data.Id).ToList();
            _context.Categories_Books.RemoveRange(existingCategoriesDb);
            await _context.SaveChangesAsync();

            //Add Categories
            foreach (var categoryId in data.CategoryIds!)
            {
                var newCategoryBook = new Category_Book()
                {
                    BookId = data.Id,
                    CategoryId = categoryId
                };
                await _context.Categories_Books.AddAsync(newCategoryBook);
            }
            await _context.SaveChangesAsync();

            //Add Authors
            foreach (var authorId in data.AuthorIds!)
            {
                var newAuthorBook = new Author_Book()
                {
                    BookId = data.Id,
                    AuthorId = authorId
                };
                await _context.Authors_Books.AddAsync(newAuthorBook);
            }
            await _context.SaveChangesAsync();
        }
    }
}
