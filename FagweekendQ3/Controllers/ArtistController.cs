using System;
using System.Linq;
using System.Web.Mvc;
using FagweekendQ3.DataStore;
using FagweekendQ3.ViewModels;

namespace FagweekendQ3.Controllers
{
    public class ArtistController : Controller
    {
        private IArtistStore _artistStore;

        public ArtistController(IArtistStore artistStore)
        {
            _artistStore = artistStore;
        }

        public ActionResult Index()
        {
            var model = _artistStore.GetAll().Select(x => new ArtistViewModel {Id = x.Id, Name = x.Name});
            return View(model);
        }

        public ActionResult Edit(string id)
        {
            ArtistViewModel model;
            if(Guid.Parse(id) != Guid.Empty)
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
            if (!ModelState.IsValid)
                return View(model);

            if (Guid.Parse(model.Id) != Guid.Empty)
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
