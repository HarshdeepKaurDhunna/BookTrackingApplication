using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookTrackingApplication.Data;
using BookTrackingApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookTrackingApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BookTrackingApplicationContext _context;

        public IndexModel(BookTrackingApplicationContext context)
        {
            _context = context;
        }


        public IList<Book> Books { get; set; }

        public async Task OnGetAsync()
        {
            Books = await _context.Books.ToListAsync();
        }
    }
}
