using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using TypecodeAPIService.APIRunners;
using TypecodeAPIService.DTOs;

namespace TypecodeAPIService.TypecodeAPITests
{
    public class DeletePostTests
    {

        TypecodeAPIServices<PostDTO> service;

        [Test]
        public void CheckIfDeletePostReturnsOK()
        {
            service = new TypecodeAPIServices<PostDTO>(new PostAPIRunner(
            new RestClient(TypecodeReader.BaseUrl), "posts/1", Method.DELETE));

            Assert.That(service.Status, Is.EqualTo("OK"));
        }

        [Test]
        public void GivenANonExisting_PostId_DeleteStatus_ReturnsOk()
        {
            service = new TypecodeAPIServices<PostDTO>(new PostAPIRunner(
            new RestClient(TypecodeReader.BaseUrl), "posts/234234234", Method.DELETE));

            Assert.That(service.Status, Is.EqualTo("OK"));
        }
    }
}
