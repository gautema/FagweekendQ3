using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FagweekendQ3.DataStore;
using FagweekendQ3.ViewModels;

namespace FagweekendQ3.Controllers
{
    public class AlbumController : Controller
    {
        private IAlbumStore _albumStore;

        public AlbumController()
        {
            _albumStore = new AlbumStore();
        }

        public ActionResult Index()
        {
            var model = _albumStore.GetAll().Select(x => new AlbumViewModel {Id = x.Id, Name = x.Name});
            return View(model);
        }

        public ActionResult Show(string id)
        {
            var album = _albumStore.Get(id);
            var tracks = album.Tracks.Select(x => new TrackViewModel { Name = x.Name, TrackLength = x.Length, TrackNo = x.TrackNo });

            var model = new AlbumViewModel { Id = album.Id, Name = album.Name, Genre = album.Genre.ToString(), Tracks = tracks};
            
            return View(model);
        }

        public ActionResult ShowServerJSON(string id)
        {
            var album = _albumStore.Get(id);
            var tracks = album.Tracks.Select(x => new TrackViewModel { Name = x.Name, TrackLength = x.Length, TrackNo = x.TrackNo});

            var model = new AlbumViewModel { Id = album.Id, Name = album.Name, Genre = album.Genre.ToString(), Tracks = tracks };

            return View(model);
        }

        public ActionResult Edit(string id)
        {
            AlbumViewModel model;
            if(id != string.Empty)
            {
                var album = _albumStore.Get(id);
                model = new AlbumViewModel { Id = album.Id, Name = album.Name };
            }
            else
            {
                model = new AlbumViewModel();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AlbumViewModel model)
        {
            if(model.Id != string.Empty)
            {
                var Album = _albumStore.Get(model.Id);
                Album.ChangeName(model.Name);
                
                Genre parsedGenre;
                Enum.TryParse(model.Genre, out parsedGenre);
                Album.ChangeGenre(parsedGenre);
            }
            else
            {
                Genre parsedGenre;
                Enum.TryParse(model.Genre, out parsedGenre);
                _albumStore.Add(model.Name, model.ArtistId, parsedGenre);
            }

            return RedirectToAction("Index");
        }
    }
}
