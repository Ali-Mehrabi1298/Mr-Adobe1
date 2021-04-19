using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MohamadShop.Data;
using MohamadShop.Models;

namespace MohamadShop.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly MohamadShop.Data.Eshopecontex _context;

        public EditModel(MohamadShop.Data.Eshopecontex context)
        {
            _context = context;
        }

        [BindProperty]
        public CategoryToproduct CategoryToproduct { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategoryToproduct = await _context.CategoryToproducts
                .Include(c => c.Category)
                .Include(c => c.Product).FirstOrDefaultAsync(m => m.Id == id);

            if (CategoryToproduct == null)
            {
                return NotFound();
            }
           ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "Id");
           ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Text");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CategoryToproduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryToproductExists(CategoryToproduct.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CategoryToproductExists(int id)
        {
            return _context.CategoryToproducts.Any(e => e.Id == id);
        }
    }
}
