using Microsoft.AspNet.Mvc;
using OdeToFood.ViewModels;
using OdeToFood.Services;

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

        public ViewResult Create()
        {
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
