using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MohamadShop.Data;
using MohamadShop.Models;

namespace MohamadShop.Pages.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly MohamadShop.Data.Eshopecontex _context;

        public DetailsModel(MohamadShop.Data.Eshopecontex context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
