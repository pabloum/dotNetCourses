using PumToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PumToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            { 
                new Restaurant { Id = 1, Name = "Pablo's Restaurant", Location = "Medallo", Cuisine = CuisineType.Colombian },
                new Restaurant { Id = 2, Name = "Pablo's Restaurant", Location = "Cali", Cuisine = CuisineType.Colombian },
                new Restaurant { Id = 3, Name = "Pablo's Restaurant", Location = "Bogotá", Cuisine = CuisineType.Colombian },
                new Restaurant { Id = 4, Name = "Pablo's Restaurant", Location = "DF", Cuisine = CuisineType.Mexican },
                new Restaurant { Id = 5, Name = "Pablo's Restaurant", Location = "Ciudad", Cuisine = CuisineType.Mexican },
                new Restaurant { Id = 6, Name = "Pablo's Restaurant", Location = "New Dehli", Cuisine = CuisineType.Indian }
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            var query = from r in _restaurants
                        orderby r.Name descending
                        select r;

            return query;
        }
    }
}
