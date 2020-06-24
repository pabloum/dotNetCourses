using PumToFood.Core;
using System.Collections.Generic;
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
        Restaurant Delete(int id);
        int Commit();
    }
}
