using Microsoft.EntityFrameworkCore;
using PumToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace PumToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        public SqlRestaurantData(PumToFoodDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public PumToFoodDbContext DbContext { get; }

        public int Commit()
        {
            return DbContext.SaveChanges();
        }

        public Restaurant Create(Restaurant createdRestaurant)
        {
            DbContext.Restaurants.Add(createdRestaurant);
            return createdRestaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);

            if (restaurant != null)
            {
                DbContext.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return DbContext.Restaurants;
        }

        public Restaurant GetById(int id)
        {
            return DbContext.Restaurants.Find(id); // PK
        }

        public int GetCountRestaurants()
        {
            return DbContext.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            var query = from r in GetAll()
                        where string.IsNullOrEmpty(name) || r.Name.Contains(name)
                        orderby r.Name
                        select r;
            
            return query;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = DbContext.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
