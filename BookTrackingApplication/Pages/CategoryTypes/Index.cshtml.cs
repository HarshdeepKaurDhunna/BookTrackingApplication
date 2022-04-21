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
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace BookTrackingApplication.Pages.CategoryTypes
{
    public class IndexModel : PageModel
    {
        private readonly BookTrackingApplicationContext _context;
        public SelectList CategorySL { get; set; }

        [BindProperty]
        public CategoryType categoryType { get; set; }
        public IList<CategoryType> CategoryTypies { get; set; } = new List<CategoryType>();
        public IndexModel(BookTrackingApplicationContext context)
        {
            _context = context;
            PopulateDepartmentsDropDownList(_context);
        }

        public void PopulateDepartmentsDropDownList(BookTrackingApplicationContext _context,
           object selectedCategory = null)
        {
            var categoryQuery = _context.Categories.ToList();

            CategorySL = new SelectList(categoryQuery,
                        "Type", "Name", selectedCategory);

        }
        public async Task OnGetAsync(int id, string action)
        {
            CategoryTypies =  await _context.CategoryTypies
                    .Include(ct => ct.Category)
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
        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategoryType updatedCategoryType = _context.CategoryTypies.SingleOrDefault(b => b.CategoryTypeNum == id);

            if (updatedCategoryType != null)
            {
                _context.CategoryTypies.Remove(updatedCategoryType);
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

            categoryType = await _context.CategoryTypies.FirstOrDefaultAsync(b => b.CategoryTypeNum == id);

            if (categoryType == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Debug.WriteLine("OnPostAsync");
            if (categoryType.CategoryTypeNum != 0)
            {
                
                CategoryType updatedCategory = _context.CategoryTypies.FirstOrDefault(b => b.CategoryTypeNum == categoryType.CategoryTypeNum);
                if (updatedCategory != null)
                {
                    updatedCategory.CategoryTypeNum = categoryType.CategoryTypeNum;
                    updatedCategory.Description = categoryType.Description;
                    updatedCategory.CategoryTypeCode = categoryType.CategoryTypeCode;
                }
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!categoryTypeExists(categoryType.CategoryTypeNum))
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
                _context.CategoryTypies.Add(categoryType);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("/CategoryTypes/Index");
        }

        private bool categoryTypeExists(int id)
        {
            return _context.CategoryTypies.Any(e => e.CategoryTypeNum == id);
        }

    }
}