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
                                                                                         new List<Song>
                                                                                             {
                                                                                                 new Song("Walk"),
                                                                                                 new Song("This Love"),
                                                                                                 new Song("Mouth For War")
                                                                                             },
                                                                                         genres[0]),
                                                                                     new Album("Cowboys From Hell",
                                                                                               new List<Song>
                                                                                                   {
                                                                                                       new Song("Cemetary Gates"),
                                                                                                       new Song("Cowboys From Hell")
                                                                                                   }, genres[0])
                                                                                 }),
                                                       new Artist("The Smiths",
                                                                  new[]
                                                                      {
                                                                          new Album("The Queen Is Dead",
                                                                                    new List<Song>
                                                                                        {
                                                                                            new Song("Frankly, Mr. Shankly"),
                                                                                            new Song("Cemetry Gates"),
                                                                                            new Song("Some Girls Are Bigger Than Others")
                                                                                        }, genres[1])
                                                                      }),
                                                       new Artist("Lady Gaga",
                                                                  new[]
                                                                      {
                                                                          new Album("The Fame Monster",
                                                                                    new List<Song>
                                                                                        {
                                                                                            new Song("Bad Romance"),
                                                                                            new Song("Telephone")
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
        public Album(string name, IEnumerable<Song> songs, Genre genre)
        {
            Name = name;
            Songs = songs;
            Genre = genre;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<Song> Songs { get; private set; }
        public Genre Genre { get; private set; }
    }

    public class Song
    {
        public Song(string name)
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