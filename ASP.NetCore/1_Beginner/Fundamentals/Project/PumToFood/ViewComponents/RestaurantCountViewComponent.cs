using Microsoft.AspNetCore.Mvc;
using PumToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumToFood.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestaurantData restaurantData;
    
        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IViewComponentResult Invoke()
        {
            var count = restaurantData.GetCountRestaurants();
            return View(count); // Calls Default.cshtml in Shared/Components/RestaurantCount
            //return View("otro", count); // Calls otro.cshtml in Shared/Components/RestaurantCount
        }

    }
}
