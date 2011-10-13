using System;
using System.Collections.Generic;
using System.Linq;

namespace FagweekendQ3.DataStore
{
    public class ArtistStore : IArtistStore
    {
        private IList<Artist> artists = new List<Artist>
                                                   {
                                                       new Artist("art1", "Pantera"),
                                                       new Artist("art2", "The Smiths"),
                                                       new Artist("art3", "Lady Gaga")
                                                   };


        public void Add(string name)
        {

            artists.Add(new Artist(Guid.NewGuid().ToString(), name));
        }

        IEnumerable<Artist> IArtistStore.GetAll()
        {
            return artists;
        }
       

        Artist IArtistStore.Get(string id)
        {
            return artists.Single(x=> x.Id == id);
        }
    }

    public interface IArtistStore
    {
        void Add(string name);
        IEnumerable<Artist> GetAll();
        Artist Get(string id);
    }

    public class Artist
    {
        public Artist(string id, string name)
        {
            Name = name;
            Id = id;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }

        public void ChangeName(string name)
        {
            Name = name;
        }
    }
}