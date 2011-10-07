using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FagweekendQ3.ViewModels;

namespace FagweekendQ3.Controllers
{
    public class ArtistController : Controller
    {
        private IArtistStore _artistStore;

        public ArtistController()
        {
            _artistStore = new DataStore();
        }

        public ActionResult Index()
        {
            var model = _artistStore.GetAll().Select(x => new ArtistViewModel {Id = x.Id, Name = x.Name});
            return View(model);
        }

        public ActionResult Edit(Guid id)
        {
            ArtistViewModel model;
            if(id != Guid.Empty)
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
            if(model.Id != Guid.Empty)
            {
                var artist = _artistStore.Get(model.Id);
                artist.ChangeName(model.Name);
            }
            else
            {
                _artistStore.Add(new Artist(model.Name, new List<Album>()));
            }

            return RedirectToAction("Index");
        }
    }
}
