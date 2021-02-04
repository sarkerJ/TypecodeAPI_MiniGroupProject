using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using TypecodeAPIService.APIRunners;
using TypecodeAPIService.DTOs;

namespace TypecodeAPIService.TypecodeAPITests
{
    public class GetPostTests
    {

        TypecodeAPIServices<PostDTO> service;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            service = new TypecodeAPIServices<PostDTO>(new PostAPIRunner(
            new RestClient(TypecodeReader.BaseUrl), "posts/1"));
        }

        [Test]
        public void CheckResultIsOk()
        {
            Assert.That(service.Status, Is.EqualTo("OK"));
        }

        [Test]
        public void CheckReturnValueAreCorrect()
        {
            Assert.That(service.results.id.ToString(), Is.EqualTo("1"));
            Assert.That(service.results.title, Is.EqualTo("sunt aut facere repellat provident occaecati excepturi optio reprehenderit"));
        } 
    }
}
