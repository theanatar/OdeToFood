using Microsoft.AspNet.Mvc;
using OdeToFood.ViewModels;
using OdeToFood.Services;
using OdeToFood.Entities;
using Microsoft.AspNet.Authorization;

namespace OdeToFood.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IGreeter _greeter;
        private IRestarauntData _restaurantData;

        public HomeController(IRestarauntData restarauntData, IGreeter greeter)
        {
            _restaurantData = restarauntData;
            _greeter = greeter;
        }

        [AllowAnonymous]
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, RestarauntEditViewModel input)
        {
            var restaraunt = _restaurantData.Get(id);
            if(restaraunt != null & ModelState.IsValid)
            {
                restaraunt.Name = input.Name;
                restaraunt.Cuisine = input.Cuisine;
                _restaurantData.Commit();
                return RedirectToAction("Details", new { id = restaraunt.Id });
            }
            return View(restaraunt);
        }

        [HttpPost]
        public IActionResult Create(RestarauntEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var restaraunt = new Restaurant();
                restaraunt.Name = model.Name;
                restaraunt.Cuisine = model.Cuisine;

                _restaurantData.Commit();

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
