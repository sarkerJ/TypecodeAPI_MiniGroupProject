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
       
        [Test]
        public void CreateNewPostStatusTest()
        {
            var args = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("userId", 5) };
            service = new TypecodeAPIServices<PostDTO>(new PostAPIRunner(
            new RestClient(TypecodeReader.BaseUrl), "posts", Method.POST, args));

            Assert.That(service.Status, Is.EqualTo("Created"));
        }

        [Test]
        public void CreateNewPostTest()
        {
            var args = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("userId", 5) };
            service = new TypecodeAPIServices<PostDTO>(new PostAPIRunner(
            new RestClient(TypecodeReader.BaseUrl), "posts", Method.POST, args));

            Assert.That(service.results.userId, Is.EqualTo(5));
        }

        [Test]
        public void CheckIf_PostIdReturned_is101_Given_PostId234()
        {
            var args = new List<KeyValuePair<string, object>> {
                new KeyValuePair<string, object>("userId", 5),
                new KeyValuePair<string, object>("Id", 234)
            };

            service = new TypecodeAPIServices<PostDTO>(new PostAPIRunner(
            new RestClient(TypecodeReader.BaseUrl), "posts", Method.POST, args));

            Assert.That(service.results.id, Is.EqualTo(101));
        }
    }
}
