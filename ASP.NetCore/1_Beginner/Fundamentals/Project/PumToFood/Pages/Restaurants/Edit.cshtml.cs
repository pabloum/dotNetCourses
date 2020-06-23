using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PumToFood.Core;
using PumToFood.Data;

namespace PumToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper )
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;

            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
        }
        public IActionResult OnGet(int? restaurantId)
        {
            if (restaurantId.HasValue)
            {
                Restaurant = restaurantData.GetById(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }

            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {

                if (Restaurant.Id > 0)
                {
                    TempData["Message"] = "Restaurant updated!";
                    Restaurant = restaurantData.Update(Restaurant);
                }
                else
                {
                    TempData["Message"] = "Restaurant created!";
                    Restaurant = restaurantData.Create(Restaurant);
                }

                restaurantData.Commit();

                return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id});
            }

            return Page();
        }
    }
}
