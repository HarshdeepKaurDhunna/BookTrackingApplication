using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookTrackingApplication.Data;
using Microsoft.EntityFrameworkCore;
using local = BookTrackingApplication.Models;
using schema = Schema.NET;
using System.Diagnostics;

namespace BookTrackingApplication.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly BookTrackingApplicationContext _context;

        public IndexModel(BookTrackingApplicationContext context)
        {
            _context = context;
            PopulateDepartmentsDropDownList(_context);
        }
       
        public IList<local.Book> Books { get; set; }
        [BindProperty]
        public local.Book Book { get; set; }
        public ICollection<schema.Thing> JSONLD
        {
            get
            {
                List<schema.Thing> lst = new List<schema.Thing>() { };
                foreach (var thing in GetBooksList())
                {
                    lst.Add(GetJson(thing));
                }

                return lst;
            }
        }
       
        public SelectList CategoryTypiesSL { get; set; }

        public void PopulateDepartmentsDropDownList(BookTrackingApplicationContext _context,
            object selectedCategoryTypies = null)
        {
            var categoryTypiesQuery = from ct in _context.CategoryTypies
                                      orderby ct.Description // Sort by name.
                                      select ct;

            CategoryTypiesSL = new SelectList(categoryTypiesQuery.AsNoTracking(),
                        "NameToken", "Description", selectedCategoryTypies);
        }
        public schema.Thing GetJson(local.Book Book)
        {
            schema.Book book = new schema.Book();
            book.Isbn = Book.ISBN;
            book.Author = new schema.Person() { Name = Book.Author };
            book.Name = Book.Title;
            book.IsBasedOn = new List<object>() {
                new schema.Product()
                {
                    Name = Book.CategoryType.NameToken,
                    Description = Book.CategoryType.Description,
                    Category = new schema.Thing()
                    {
                        AlternateName =  Book.CategoryType.Category.Name,
                        Name = Book.CategoryType.Category.Name
                    }


                }
            };

            return book;
        }
        public List<local.Book> GetBooksList()
        {
            List<local.Book> BooksList = _context.Books
                   .Include(b => b.CategoryType)
                       .ThenInclude(c => c.Category)
                   .ToList();
            return BooksList;
        }
        public async Task OnGetAsync(int id, string action)
        {
            Books = await _context.Books
                     .Include(b => b.CategoryType)
                         .ThenInclude(c => c.Category)
                     .AsNoTracking()
                     .ToListAsync();

            if (action == "Edit")
            {
                await OnGetEditAsync(id);
            }
            if (action == "Delete")
            {
                await OnGetDeleteAsync(id);
            }

        }
        public async Task<IActionResult> OnPostAsync()
        {
           
            if (Book.bookNum != 0)
            {
               
                local.Book updatedBook = _context.Books.SingleOrDefault(b => b.bookNum == Book.bookNum);
                if (updatedBook != null)
                {
                    updatedBook.bookNum = Book.bookNum;
                    updatedBook.Author = Book.Author;
                    updatedBook.CategoryTypeNameToken = Book.CategoryTypeNameToken;
                    updatedBook.Title = Book.Title;
                   
                }
              
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(Book.bookNum))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }
            }
            else
            {
                _context.Books.Add(Book);
                await _context.SaveChangesAsync();
            }
            
            return RedirectToPage("./Index");
        }
       
        /*
       @method: Delete item from list 

       */

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            local.Book updatedBook =  _context.Books.SingleOrDefault(b => b.bookNum == id);

            if (updatedBook != null)
            {
                _context.Books.Remove(updatedBook);
                await _context.SaveChangesAsync();
            }
            return Page();
        }

        /*
         @method: get the item from list and bind the global bind object
           
         */
        public async Task<IActionResult> OnGetEditAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Books.FirstOrDefaultAsync(b => b.bookNum == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.bookNum == id);
        }

    }
}

