using System;
using System.Collections.Generic;
using System.Linq;

namespace FagweekendQ3
{
    public class DataStore : IArtistStore, IGenreStore
    {
        private static readonly IList<Genre> genres = new List<Genre>
                                                          {new Genre("Rock"), new Genre("Pop"), new Genre("Techno")};

        private static IList<Artist> artists = new List<Artist>
                                                   {
                                                       new Artist("Pantera", new[]
                                                                                 {
                                                                                     new Album("Vulgar Display of Power",
                                                                                         new List<Track>
                                                                                             {
                                                                                                 new Track("Walk"),
                                                                                                 new Track("This Love"),
                                                                                                 new Track("Mouth For War")
                                                                                             },
                                                                                         genres[0]),
                                                                                     new Album("Cowboys From Hell",
                                                                                               new List<Track>
                                                                                                   {
                                                                                                       new Track("Cemetary Gates"),
                                                                                                       new Track("Cowboys From Hell")
                                                                                                   }, genres[0])
                                                                                 }),
                                                       new Artist("The Smiths",
                                                                  new[]
                                                                      {
                                                                          new Album("The Queen Is Dead",
                                                                                    new List<Track>
                                                                                        {
                                                                                            new Track("Frankly, Mr. Shankly"),
                                                                                            new Track("Cemetry Gates"),
                                                                                            new Track("Some Girls Are Bigger Than Others")
                                                                                        }, genres[1])
                                                                      }),
                                                       new Artist("Lady Gaga",
                                                                  new[]
                                                                      {
                                                                          new Album("The Fame Monster",
                                                                                    new List<Track>
                                                                                        {
                                                                                            new Track("Bad Romance"),
                                                                                            new Track("Telephone")
                                                                                        },
                                                                                    genres[1])
                                                                      }),
                                                   };


        public void Add(Artist obj)
        {
            artists.Add(obj);
        }

        public void Add(Genre obj)
        {
            genres.Add(obj);
        }

        IEnumerable<Genre> IGenreStore.GetAll()
        {
            return genres;
        }

        Genre IGenreStore.Get(Guid id)
        {
            return genres.Single(x=> x.Id == id);
        }

        IEnumerable<Artist> IArtistStore.GetAll()
        {
            return artists;
        }

        Artist IArtistStore.Get(Guid id)
        {
            return artists.Single(x=> x.Id == id);
        }
    }

    public interface IArtistStore
    {
        void Add(Artist obj);
        IEnumerable<Artist> GetAll();
        Artist Get(Guid id);
    }
    public interface IGenreStore
    {
        void Add(Genre obj);
        IEnumerable<Genre> GetAll();
        Genre Get(Guid id);
    }


    public class Album
    {
        public Album(string name, IEnumerable<Track> songs, Genre genre)
        {
            Name = name;
            Tracks = songs;
            Genre = genre;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<Track> Tracks { get; private set; }
        public Genre Genre { get; private set; }
    }

    public class Track
    {
        public Track(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }

    public class Artist
    {
        public Artist(string name, IEnumerable<Album> albums)
        {
            Name = name;
            Albums = albums;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<Album> Albums { get; private set; }

        public void ChangeName(string name)
        {
            Name = name;
        }
    }

    public class Genre
    {
        public Genre(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}