using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MohamadShop.Data;
using MohamadShop.Models;

namespace MohamadShop.Pages.Admin.sliderrr
{
    public class DeleteModel : PageModel
    {
        private readonly MohamadShop.Data.Eshopecontex _context;

        public DeleteModel(MohamadShop.Data.Eshopecontex context)
        {
            _context = context;
        }

        [BindProperty]
        public Slider Slider { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Slider = await _context.Sliders.FirstOrDefaultAsync(m => m.Id == id);

            if (Slider == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Slider = await _context.Sliders.FindAsync(id);

            if (Slider != null)
            {
                _context.Sliders.Remove(Slider);
                await _context.SaveChangesAsync();
            }
            string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                         "wwwroot",
                         "img", "slide",
                     Slider.Name + ".jpg");
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            return RedirectToPage("./Index");
        }
    }
}
