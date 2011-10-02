using System.Web.Mvc;

namespace FagweekendQ3.Controllers
{
    public class HomeController : Controller
    {
        private IArtistStore _artistStore;

        public HomeController()
        {
            _artistStore = new DataStore();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
