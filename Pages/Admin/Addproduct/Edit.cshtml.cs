using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MohamadShop.Data;
using MohamadShop.Models;

namespace MohamadShop.Pages.Admin.Addproduct
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
        public Product Product { get; set; }
        [BindProperty]
        public AddEditProductViewModel Productse { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.FirstOrDefaultAsync(m => m.ProductId == id);

            if (Product == null)
            {
                return NotFound();
            }
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

            _context.Attach(Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            if (Productse.Picture?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "img",
                Product.Title + Path.GetExtension(Productse.Picture.FileName));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Productse.Picture.CopyTo(stream);
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
    }
}
