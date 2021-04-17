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
    public class IndexModel : PageModel
    {
        private readonly MohamadShop.Data.Eshopecontex _context;

        public IndexModel(MohamadShop.Data.Eshopecontex context)
        {
            _context = context;
        }

        public IList<CategoryToproduct> CategoryToproduct { get;set; }
     
        public async Task OnGetAsync()
        {
            CategoryToproduct = await _context.CategoryToproducts
                .Include(c => c.Category)
                .Include(c => c.Product).ToListAsync();
        }
    }
}
