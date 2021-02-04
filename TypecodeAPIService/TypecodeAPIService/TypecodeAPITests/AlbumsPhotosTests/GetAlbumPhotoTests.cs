using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RestSharp;
using TypecodeAPIService.APIRunners;
using TypecodeAPIService.DTOs;

namespace TypecodeAPIService.TypecodeAPITests.AlbumsPhotosTests
{
    public class GetAlbumPhotoTests
    {
        TypecodeAPIServices<PhotosDTO[]> _albumPhotosService;

        [Test]
        public void GetAllPhotos_Returns_OK_ForValidAlbumId()
        {
            _albumPhotosService = new TypecodeAPIServices<PhotosDTO[]>(new AlbumAPIRunner(new RestClient(TypecodeReader.BaseUrl), "/albums/1/photos"));

            Assert.That(_albumPhotosService.Status, Is.EqualTo("OK"));
        }

        [Test]
        public void GetAllPhotos_Returns_Results_ForValidAlbumId()
        {
            _albumPhotosService = new TypecodeAPIServices<PhotosDTO[]>(new AlbumAPIRunner(new RestClient(TypecodeReader.BaseUrl), "/albums/1/photos"));

            Assert.That(_albumPhotosService.results.Length, Is.GreaterThan(0));
        }

        [Test]
        public void GetAllPhotos_Returns_NoResults_ForInvalidAlbumId()
        {
            _albumPhotosService = new TypecodeAPIServices<PhotosDTO[]>(new AlbumAPIRunner(new RestClient(TypecodeReader.BaseUrl), "/albums/1681684161986513651/photos"));

            Assert.That(_albumPhotosService.results.Length, Is.EqualTo(0));
        }
    }
}
