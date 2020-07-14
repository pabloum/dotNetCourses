using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PumToFood.Core;
using PumToFood.Data;

namespace PumToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IRestaurantData _restaurantData;
        private readonly ILogger<ListModel> _logger;

        public string Message { get; set; }
        public string Message2 { get; set; }
        public string SearchInput { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }


        public ListModel(IConfiguration config, IRestaurantData restaurantData, ILogger<ListModel> logger)
        {
            _config = config;
            _restaurantData = restaurantData;
            _logger = logger;
        }
        public void OnGet(string searchValue)
        {
            _logger.LogError("Executing ListModel");
            //HttpContext.Request.QueryString

            Message     = "Hallo, Welt";
            Message2    = _config["Message"];
            //SearchInput = searchValue;
            //Restaurants = _restaurantData.GetRestaurantByName(searchValue);
            Restaurants = _restaurantData.GetRestaurantByName(SearchTerm);
        }
    }
}
