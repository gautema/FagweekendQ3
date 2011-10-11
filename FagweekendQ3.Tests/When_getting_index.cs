using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FagweekendQ3.Controllers;
using FagweekendQ3.DataStore;
using FagweekendQ3.ViewModels;
using NUnit.Framework;

namespace FagweekendQ3.Tests
{
    [TestFixture]
    public class When_getting_index
    {
        private ArtistStore _artistStore;
        private ArtistController _controller;
        private IEnumerable<ArtistViewModel> _result;

        [SetUp]

        public void Setup()
        {
            _artistStore = new ArtistStore();
            _controller = new ArtistController(_artistStore);

            _result = ((ViewResult) _controller.Index()).Model as IEnumerable<ArtistViewModel>;
        }

        [Test]
        public void Should_get_all_artist()
        {
            Assert.That(_result.Count(), Is.EqualTo(3)); 
        }

        [Test]
        public void Should_get_all_properties_on_models()
        {
            Assert.That(_result.Any(x => string.IsNullOrWhiteSpace(x.Name)), Is.EqualTo(false)); 
            Assert.That(_result.All(x => Guid.Empty.ToString() == x.Id), Is.EqualTo(false));
        }
    }
}
