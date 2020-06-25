using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PumToFood.Core;
using PumToFood.Data;

namespace PumToFood
{
    public class DeleteModel2 : PageModel
    {
        private readonly PumToFood.Data.PumToFoodDbContext _context;

        public DeleteModel2(PumToFood.Data.PumToFoodDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Restaurant Resto2 { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Resto2 = await _context.Restaurants.FirstOrDefaultAsync(m => m.Id == id);

            if (Resto2 == null)
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

            Resto2 = await _context.Restaurants.FindAsync(id);

            if (Resto2 != null)
            {
                _context.Restaurants.Remove(Resto2);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
