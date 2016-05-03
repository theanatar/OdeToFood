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
        void Add(Restaurant newRestaraunt);
        int Commit();
    }

    public class SqlRestaurantData : IRestarauntData
    {
        private OdeToFoodDbContext _context;

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Add(Restaurant newRestaraunt)
        {
            _context.Add(newRestaraunt);
            _context.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return _context.Restaraunts.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaraunts;
        }
    }

    public class InMemoryRestarauntData : IRestarauntData
    {
        static List<Restaurant> _restaurants;

        static InMemoryRestarauntData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1 , Name = "Restaraunt 1"},
                new Restaurant { Id = 2 , Name = "Restaraunt 2"},
                new Restaurant { Id = 3 , Name = "Restaraunt 3"}
            };
        }

        public int Commit()
        {
            return 0;
        }

        public void Add(Restaurant newRestaraunt)
        {
            newRestaraunt.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(newRestaraunt);
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
