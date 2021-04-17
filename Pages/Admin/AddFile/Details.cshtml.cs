using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MohamadShop.Data;
using MohamadShop.Models;

namespace MohamadShop.Pages.Admin.AddFile
{
    public class DetailsModel : PageModel
    {
        private readonly MohamadShop.Data.Eshopecontex _context;

        public DetailsModel(MohamadShop.Data.Eshopecontex context)
        {
            _context = context;
        }

        public Filess Filess { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Filess = await _context.Filesses.FirstOrDefaultAsync(m => m.Id == id);

            if (Filess == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
