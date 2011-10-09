using System;
using System.Collections.Generic;
using System.Linq;

namespace FagweekendQ3.DataStore
{
    public class AlbumStore :  IAlbumStore
    {
        private static IList<Album> albums = new List<Album>
                                                 {
                                                     new Album("alb1", "art1", "Vulgar Display of Power",
                                                               new List<Track>
                                                                   {
                                                                       new Track("Walk"),
                                                                       new Track("This Love"),
                                                                       new Track("Mouth For War")
                                                                   },
                                                               Genre.Rock),
                                                     new Album("alb2", "art1", "Cowboys From Hell",
                                                               new List<Track>
                                                                   {
                                                                       new Track("Cemetary Gates"),
                                                                       new Track("Cowboys From Hell")
                                                                   },
                                                               Genre.Rock),
                                                     new Album("alb3", "art2", "The Queen Is Dead",
                                                               new List<Track>
                                                                   {
                                                                       new Track("Frankly, Mr. Shankly"),
                                                                       new Track("Cemetry Gates"),
                                                                       new Track("Some Girls Are Bigger Than Others")
                                                                   }, Genre.Pop),
                                                     new Album("alb4", "art3", "The Fame Monster",
                                                               new List<Track>
                                                                   {
                                                                       new Track("Bad Romance"),
                                                                       new Track("Telephone")
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
    }

    public class Track
    {
        public Track(string name)
        {
            Name = name;
            Id = "blabla"; //Generate something unique in datastore
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
    }

    public enum Genre
    {
        Rock,
        Pop,
        Techno
    }
}