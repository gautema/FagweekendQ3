using System.Linq;
using System.Web.Mvc;
using FagweekendQ3.DataStore;
using FagweekendQ3.ViewModels;

namespace FagweekendQ3.Controllers
{
    public class ArtistController : Controller
    {
        private IArtistStore _artistStore;

        public ArtistController()
        {
            _artistStore = new ArtistStore();
        }

        public ActionResult Index()
        {
            var model = _artistStore.GetAll().Select(x => new ArtistViewModel {Id = x.Id, Name = x.Name});
            return View(model);
        }

        public ActionResult Edit(string id)
        {
            ArtistViewModel model;
            if(id != string.Empty)
            {
                var artist = _artistStore.Get(id);
                model = new ArtistViewModel { Id = artist.Id, Name = artist.Name };
            }
            else
            {
                model = new ArtistViewModel();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ArtistViewModel model)
        {
            if(model.Id != string.Empty)
            {
                var artist = _artistStore.Get(model.Id);
                artist.ChangeName(model.Name);
            }
            else
            {
                _artistStore.Add(model.Name);
            }

            return RedirectToAction("Index");
        }
    }
}
