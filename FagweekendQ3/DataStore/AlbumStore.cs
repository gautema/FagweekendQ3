using System;
using System.Collections.Generic;
using System.Linq;

namespace FagweekendQ3.DataStore
{
    public class AlbumStore :  IAlbumStore
    {
        private IList<Album> albums = new List<Album>
                                                 {
                                                     new Album("alb1", "art1", "Vulgar Display of Power",
                                                               new List<Track>
                                                                   {
                                                                       new Track(1,"Walk", 360),
                                                                       new Track(2,"This Love", 223),
                                                                       new Track(3,"Mouth For War", 280)
                                                                   },
                                                               Genre.Rock),
                                                     new Album("alb2", "art1", "Cowboys From Hell",
                                                               new List<Track>
                                                                   {
                                                                       new Track(1,"Cemetary Gates", 231),
                                                                       new Track(2,"Cowboys From Hell", 384)
                                                                   },
                                                               Genre.Rock),
                                                     new Album("alb3", "art2", "The Queen Is Dead",
                                                               new List<Track>
                                                                   {
                                                                       new Track(1,"Frankly, Mr. Shankly", 1231),
                                                                       new Track(2,"Cemetry Gates", 211),
                                                                       new Track(3,"Some Girls Are Bigger Than Others", 234)
                                                                   }, Genre.Pop),
                                                     new Album("alb4", "art3", "The Fame Monster",
                                                               new List<Track>
                                                                   {
                                                                       new Track(1,"Bad Romance",421 ),
                                                                       new Track(2,"Telephone",554)
                                                                   },
                                                               Genre.Pop)

                                                 };

        public void Add(string name, string artistId, Genre genre)
        {
          
            albums.Add(new Album(Guid.NewGuid().ToString(), artistId, name, new List<Track>(), genre));
        }

        public IEnumerable<Album> GetAll()
        {
            return albums;
        }

        public IEnumerable<Album> GetAllForArtis(string artisId)
        {
            return albums.Where(x => x.ArtistId == artisId);
        }

        public Album Get(string id)
        {
            return albums.Single(x => x.Id == id);
        }
    }

    public interface IAlbumStore
    {
        void Add(string name, string artistId, Genre genre);
        IEnumerable<Album> GetAll();
        Album Get(string id);
        IEnumerable<Album> GetAllForArtis(string artisId);
    }


    public class Album
    {
        public Album(string id, string artistId, string name, List<Track> tracks, Genre genre)
        {
            Name = name;
            Tracks = tracks ?? new List<Track>();
            Genre = genre;
            Id = id;
            ArtistId = artistId;
        }

        public string Id { get; private set; }
        public string ArtistId { get; private set; }
        public string Name { get; private set; }
        public List<Track> Tracks { get; private set; }
        public Genre Genre { get; private set; }

        public void ChangeName(string name)
        {
            Name = name;
        }

        public void ChangeGenre(Genre genre)
        {
            Genre = genre;
        }

        public void AddTrack(Track track)
        {
            Tracks.Add(track);
        }
    }

    public class Track
    {
        public Track(long trackNo, string name, long length)
        {
            Name = name;
            Id = "blabla"; //Generate something unique in datastore
            TrackNo = trackNo;
            Length = length;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public long TrackNo { get; private set; }
        public long Length { get; private set; }
    }

    public enum Genre
    {
        Rock,
        Pop,
        Techno
    }
}