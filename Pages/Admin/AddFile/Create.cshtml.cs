using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MohamadShop.Data;
using MohamadShop.Models;

namespace MohamadShop.Pages.Admin.AddFile
{
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
        public Filess Filess { get; set; }
        [BindProperty]
        public AddEditProductViewModel Productse { get; set; }
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Filesses.Add(Filess);
            await _context.SaveChangesAsync();
            if (Productse.Picture?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "File",
                Filess.Name + Path.GetExtension(Productse.Picture.FileName));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Productse.Picture.CopyTo(stream);
                }
            }
            return RedirectToPage("./Index");
        }
    }
}
