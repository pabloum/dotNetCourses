using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace PumToFood.Pages.Restaurant
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;

        public string Message { get; set; }
        public string Message2 { get; set; }

        public ListModel(IConfiguration config)
        {
            _config = config;
        }
        public void OnGet()
        {
            Message  = "Hallo, Welt";
            Message2 = _config["Message"];
        }
    }
}
