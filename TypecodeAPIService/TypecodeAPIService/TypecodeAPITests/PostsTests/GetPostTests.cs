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

        [Test]
        public void CheckResultIsOk()
        {
            service = new TypecodeAPIServices<PostDTO>(new PostAPIRunner(
            new RestClient(TypecodeReader.BaseUrl), "posts/1"));

            Assert.That(service.Status, Is.EqualTo("OK"));
        }

        [Test]
        public void CheckReturnValueAreCorrect()
        {
            service = new TypecodeAPIServices<PostDTO>(new PostAPIRunner(
            new RestClient(TypecodeReader.BaseUrl), "posts/1"));

            Assert.That(service.results.id.ToString(), Is.EqualTo("1"));
            Assert.That(service.results.title, Is.EqualTo("sunt aut facere repellat provident occaecati excepturi optio reprehenderit"));
        }

        [Test]
        public void CheckErrorNotFound_IsReturned_GivenInvalid_Id()
        {
            service = new TypecodeAPIServices<PostDTO>(new PostAPIRunner(
            new RestClient(TypecodeReader.BaseUrl), "posts/13423424"));

            Assert.That(service.Status, Is.EqualTo("NotFound"));
        }
    }
}
