using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using TypecodeAPIService.APIRunners;
using TypecodeAPIService.DTOs;

namespace TypecodeAPIService.TypecodeAPITests
{
    public class NewPostTests
    {
        TypecodeAPIServices<PostDTO> service;
        [OneTimeSetUp]
        public void Setup()
        {
            var args = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("userId", 5) };
            service = new TypecodeAPIServices<PostDTO>(new PostAPIRunner<PostDTO>(
            new RestClient(TypecodeReader.BaseUrl), "posts", args, Method.POST));
        }

        [Test]
        public void CreateNewPostStatusTest()
        {
            Assert.That(service.Status, Is.EqualTo("Created"));
        }

        [Test]
        public void CreateNewPostTest()
        {
            Assert.That(service.results.userId, Is.EqualTo(5));
        }
    }
}
