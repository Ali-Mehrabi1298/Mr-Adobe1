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

namespace MohamadShop.Pages.Admin.sliderrr
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly MohamadShop.Data.Eshopecontex _context;

        public IndexModel(MohamadShop.Data.Eshopecontex context)
        {
            _context = context;
        }

        public IList<Slider> Slider { get;set; }

        public async Task OnGetAsync()
        {
            Slider = await _context.Sliders.ToListAsync();
        }
    }
}
