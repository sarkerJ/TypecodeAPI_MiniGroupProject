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
    public class GetAlbumsTests
    {
        TypecodeAPIServices<AlbumsDTO[]> _allAlbumsService;
        TypecodeAPIServices<AlbumsDTO> _singleAlbumsService;

        [Test]
        public void GetAllAlbumsReturns_Success()
        {
            _allAlbumsService = new TypecodeAPIServices<AlbumsDTO[]>(new AlbumAPIRunner(new RestClient(TypecodeReader.BaseUrl), "/albums"));

            Assert.That(_allAlbumsService.Status, Is.EqualTo("OK"));
        }

        [Test]
        public void GetAllAlbumsReturns_MultipleAlbums()
        {
            _allAlbumsService = new TypecodeAPIServices<AlbumsDTO[]>(new AlbumAPIRunner(new RestClient(TypecodeReader.BaseUrl), "/albums"));

            Assert.That(_allAlbumsService.results.Length, Is.GreaterThan(1));
        }

        [Test]
        public void GetSingleAlbumsReturns_Ok_IfValidId()
        {
            _singleAlbumsService = new TypecodeAPIServices<AlbumsDTO>(new AlbumAPIRunner(new RestClient(TypecodeReader.BaseUrl), "/albums/1"));

            Assert.That(_singleAlbumsService.Status, Is.EqualTo("OK"));
        }

        [Test]
        public void GetSingleAlbumsReturns_ResultWithCorrectId()
        {
            _singleAlbumsService = new TypecodeAPIServices<AlbumsDTO>(new AlbumAPIRunner(new RestClient(TypecodeReader.BaseUrl), "/albums/1"));

            Assert.That(_singleAlbumsService.results.id, Is.EqualTo(1));
        }

        [Test]
        public void GetSingleAlbumsReturns_NotFound_IfInvalidId()
        {
            _singleAlbumsService = new TypecodeAPIServices<AlbumsDTO>(new AlbumAPIRunner(new RestClient(TypecodeReader.BaseUrl), "/albums/1698168163521"));

            Assert.That(_singleAlbumsService.Status, Is.EqualTo("NotFound"));

        }

        [Test]
        public void GetSingleAlbumsReturns_ResultWithZeroId_IfNotFound()
        {
            _singleAlbumsService = new TypecodeAPIServices<AlbumsDTO>(new AlbumAPIRunner(new RestClient(TypecodeReader.BaseUrl), "/albums/1698168163521"));

            Assert.That(_singleAlbumsService.results.id, Is.EqualTo(0));
        }
    }
}
