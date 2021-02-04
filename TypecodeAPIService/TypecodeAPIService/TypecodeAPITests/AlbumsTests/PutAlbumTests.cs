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
    public class PutAlbumTests
    {
        TypecodeAPIServices<AlbumsDTO> _albumsService;
        List<KeyValuePair<string, object>> _args;

        [Test]
        public void AlbumTitleUpdates_IfAlbumIdIsValid()
        {
            _args = new List<KeyValuePair<string, object>> {
                new KeyValuePair<string, object>("title", "hello from the other side")
            };
            _albumsService = new TypecodeAPIServices<AlbumsDTO>(new AlbumAPIRunner(new RestClient(TypecodeReader.BaseUrl), "/albums/1", Method.PUT, _args));

            Assert.That(_albumsService.results.title, Is.EqualTo("hello from the other side"));
        }

        [Test]
        public void AlbumIdDoesntUpdate_IfAlbumIdIsValid()
        {
            _args = new List<KeyValuePair<string, object>> {
                new KeyValuePair<string, object>("id", 50)
            };
            _albumsService = new TypecodeAPIServices<AlbumsDTO>(new AlbumAPIRunner(new RestClient(TypecodeReader.BaseUrl), "/albums/1", Method.PUT, _args));

            Assert.That(_albumsService.results.id, Is.EqualTo(1));
        }

        [Test]
        public void UserIdUpdates_IfAlbumIdIsValid()
        {
            _args = new List<KeyValuePair<string, object>> {
                new KeyValuePair<string, object>("userId", 50)
            };
            _albumsService = new TypecodeAPIServices<AlbumsDTO>(new AlbumAPIRunner(new RestClient(TypecodeReader.BaseUrl), "/albums/1", Method.PUT, _args));

            Assert.That(_albumsService.results.userId, Is.EqualTo(50));
        }
    }
}
