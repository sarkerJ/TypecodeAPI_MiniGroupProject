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
    public class DeleteAlbumTests
    {
        TypecodeAPIServices<AlbumsDTO> _albumsService;
        
        [Test]
        public void AlbumReturns_OK_When_Deleted()
        {
            _albumsService = new TypecodeAPIServices<AlbumsDTO>(new AlbumAPIRunner(new RestClient(TypecodeReader.BaseUrl), "/albums/1", Method.DELETE));

            Assert.That(_albumsService.Status, Is.EqualTo("OK"));
        }
    }
}
