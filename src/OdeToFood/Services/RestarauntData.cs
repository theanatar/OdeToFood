using OdeToFood.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Services
{
    public interface IRestarauntData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
    }

    public class InMemoryRestarauntData : IRestarauntData
    {
        private List<Restaurant> _restaurants;

        public InMemoryRestarauntData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1 , Name = "Restaraunt 1"},
                new Restaurant { Id = 2 , Name = "Restaraunt 2"},
                new Restaurant { Id = 3 , Name = "Restaraunt 3"}
            };
        }

        public Restaurant Get(int id)
        {
           return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }
    }

    public class RestarauntData
    {

    }
}
