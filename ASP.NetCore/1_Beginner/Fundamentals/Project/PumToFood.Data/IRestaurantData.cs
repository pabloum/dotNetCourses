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
        IEnumerable<Restaurant> GetRestaurantByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Create(Restaurant createdRestaurant);
        int Commit();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            { 
                new Restaurant { Id = 1, Name = "Pablo's Restaurant", Location = "Medallo", Cuisine = CuisineType.Colombian },
                new Restaurant { Id = 2, Name = "pablo's Restaurant", Location = "Cali", Cuisine = CuisineType.Colombian },
                new Restaurant { Id = 3, Name = "Vero's Restaurant", Location = "Bogotá", Cuisine = CuisineType.Colombian },
                new Restaurant { Id = 4, Name = "PocaLuz's Restaurant", Location = "DF", Cuisine = CuisineType.Mexican },
                new Restaurant { Id = 5, Name = "Fea's Restaurant", Location = "Ciudad", Cuisine = CuisineType.Mexican },
                new Restaurant { Id = 6, Name = "Foxie's Restaurant", Location = "New Dehli", Cuisine = CuisineType.Indian }
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            var query = from r in _restaurants
                        orderby r.Name descending
                        select r;

            return query;
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name = null)
        {
            var query = from r in _restaurants
                        where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                        orderby r.Name descending
                        select r;

            return query;
        }

        public Restaurant GetById(int id)
        {
            var query = from r in _restaurants
                        where r.Id == id
                        select r;
            var option1 = query.FirstOrDefault();

            var option2 = _restaurants.SingleOrDefault(r => r.Id == id);

            return option2;
        }

        public Restaurant Create(Restaurant createdRestaurant)
        {
            createdRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(createdRestaurant);

            return createdRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = _restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }

            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

    }
}
