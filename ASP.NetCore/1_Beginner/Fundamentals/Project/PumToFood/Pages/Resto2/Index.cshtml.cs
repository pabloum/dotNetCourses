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
    public class IndexModel : PageModel
    {
        private readonly PumToFood.Data.PumToFoodDbContext _context;

        public IndexModel(PumToFood.Data.PumToFoodDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
