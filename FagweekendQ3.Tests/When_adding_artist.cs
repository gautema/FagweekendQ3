using System.Linq;
using FagweekendQ3.Controllers;
using FagweekendQ3.DataStore;
using FagweekendQ3.ViewModels;
using NUnit.Framework;

namespace FagweekendQ3.Tests
{
    [TestFixture]
    public class When_adding_artist
    {
        private ArtistController _controller;
        private IArtistStore _artistStore;

        [SetUp]
        public void Setup()
        {
            _artistStore = new ArtistStore();
            _controller = new ArtistController(_artistStore);

            _controller.Edit(new ArtistViewModel {Id = "", Name = "Iron Maiden"});
        }

        [Test]
        public void Should_add_artist_to_data_store()
        {
            Assert.That(_artistStore.GetAll().Count(), Is.EqualTo(4));
        }

        [Test]
        public void Should_save_artist_name()
        {
            Assert.That(_artistStore.GetAll().Any(x => x.Name == "Iron Maiden"));

        }
    }
}
