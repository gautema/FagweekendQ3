using System.Web.Mvc;
using FagweekendQ3.DataStore;
using FagweekendQ3.ViewModels;

namespace FagweekendQ3.Controllers
{
    public class TrackController : Controller
    {
        private IAlbumStore _albumStore;

        public TrackController()
        {
            _albumStore = new AlbumStore();
        }

        public ActionResult Index(string albumId)
        {
            var album = _albumStore.Get(albumId);
            var model = new AddTrackViewModel { AlbumId = album.Id, AlbumName = album.Name};
            return View(model);
        }

        [HttpPost]
        public ActionResult New(AddTrackViewModel model)
        {
            var album = _albumStore.Get(model.AlbumId);
            album.AddTrack(new Track(model.TrackNo, model.Name, model.TrackLength));
            return RedirectToAction("Index", "Album", new {album.Id});
        }
    }
}
