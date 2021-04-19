using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MohamadShop.Data;
using MohamadShop.Models;

namespace MohamadShop.Pages.Admin.Category
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly MohamadShop.Data.Eshopecontex _context;

        public DetailsModel(MohamadShop.Data.Eshopecontex context)
        {
            _context = context;
        }

        public Categoty Categoty { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Categoty = await _context.categories.FirstOrDefaultAsync(m => m.Id == id);

            if (Categoty == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
