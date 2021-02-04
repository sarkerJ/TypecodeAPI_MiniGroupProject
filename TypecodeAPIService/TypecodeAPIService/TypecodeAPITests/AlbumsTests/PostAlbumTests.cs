using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RestSharp;
using TypecodeAPIService.APIRunners;
using TypecodeAPIService.DTOs;

namespace TypecodeAPIService.TypecodeAPITests.AlbumsTests
{
    public class PostAlbumTests
    {
        TypecodeAPIServices<AlbumsDTO> _albumsService;
        List<KeyValuePair<string, object>> _args;

        [Test]
        public void NewAlbumIsCreated_AndReturns_Created()
        {
            _args = new List<KeyValuePair<string, object>> {
                new KeyValuePair<string, object>("title", "big sad"),
                new KeyValuePair<string, object>("userId", 1)
            };
            _albumsService = new TypecodeAPIServices<AlbumsDTO>(new AlbumAPIRunner(new RestClient(TypecodeReader.BaseUrl), "/albums", Method.POST, _args));
            Assert.That(_albumsService.Status, Is.EqualTo("Created"));
        }

        [Test]
        public void NewAlbumIsCreated_WithProvidedDetails()
        {
            _args = new List<KeyValuePair<string, object>> {
                new KeyValuePair<string, object>("title", "big sad"),
                new KeyValuePair<string, object>("userId", 1)
            };
            _albumsService = new TypecodeAPIServices<AlbumsDTO>(new AlbumAPIRunner(new RestClient(TypecodeReader.BaseUrl), "/albums", Method.POST, _args));
            Assert.That(_albumsService.results.userId, Is.EqualTo(1));
            Assert.That(_albumsService.results.title, Is.EqualTo("big sad"));
        }

        [Test]
        public void NewAlbumIsCreated_WithProvidedDetails_ButIdCannotBeSet()
        {
            _args = new List<KeyValuePair<string, object>> {
                new KeyValuePair<string, object>("title", "big sad"),
                new KeyValuePair<string, object>("userId", 1),
                new KeyValuePair<string, object>("id", 1)
            };
            _albumsService = new TypecodeAPIServices<AlbumsDTO>(new AlbumAPIRunner(new RestClient(TypecodeReader.BaseUrl), "/albums", Method.POST, _args));
            Assert.That(_albumsService.results.userId, Is.EqualTo(1));
            Assert.That(_albumsService.results.title, Is.EqualTo("big sad"));
            Assert.That(_albumsService.results.title, Is.Not.EqualTo(1));
        }
    }
}
