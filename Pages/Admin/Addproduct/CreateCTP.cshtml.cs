using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MohamadShop.Data;
using MohamadShop.Models;

namespace MohamadShop.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly MohamadShop.Data.Eshopecontex _context;

        public CreateModel(MohamadShop.Data.Eshopecontex context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "Id");
        ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductId");
            return Page();
        }

        [BindProperty]
        public CategoryToproduct CategoryToproduct { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CategoryToproducts.Add(CategoryToproduct);
            await _context.SaveChangesAsync();

            return RedirectToPage("./IndexCTP");
        }
    }
}
