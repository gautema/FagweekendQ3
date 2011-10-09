using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FagweekendQ3.ViewModels
{
    public class AlbumViewModel
    {
        public string Id { get; set; }
        public string ArtistId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }

        public IEnumerable<TrackViewModel> Tracks { get; set; }
    }
}