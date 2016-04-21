using Microsoft.AspNet.Mvc;
using OdeToFood.ViewModels;
using OdeToFood.Services;
using OdeToFood.Entities;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IGreeter _greeter;
        private IRestarauntData _restaurantData;

        public HomeController(IRestarauntData restarauntData, IGreeter greeter)
        {
            _restaurantData = restarauntData;
            _greeter = greeter;
        }

        public ViewResult Index()
        {
            var model = new HomePageViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentGreeting = _greeter.GetGreeting();

            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RestarauntEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var restaraunt = new Restaurant();
                restaraunt.Name = model.Name;
                restaraunt.Cuisine = model.Cuisine;

                _restaurantData.Add(restaraunt);

                return RedirectToAction("Details", new { id = restaraunt.Id });
            }
            return View();
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if(model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
