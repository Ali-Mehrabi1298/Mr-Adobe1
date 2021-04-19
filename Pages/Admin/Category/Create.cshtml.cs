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

namespace MohamadShop.Pages.Admin.Category
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
            return Page();
        }

        [BindProperty]
        public Categoty Categoty { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.categories.Add(Categoty);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
