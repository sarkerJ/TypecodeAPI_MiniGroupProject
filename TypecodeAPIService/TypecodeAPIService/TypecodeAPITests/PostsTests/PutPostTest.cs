using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using TypecodeAPIService.APIRunners;
using TypecodeAPIService.DTOs;

namespace TypecodeAPIService.TypecodeAPITests
{
    public class PutPostTests
    {
        TypecodeAPIServices<PostDTO> service;
        
        [Test]
        public void CreateNewPostStatusTest()
        {
            var args = new List<KeyValuePair<string, object>> {
                new KeyValuePair<string, object>("id", 1),
                new KeyValuePair<string, object>("title", "newTitle"),
                new KeyValuePair<string, object>("body", "NewBodyContent"),
                new KeyValuePair<string, object>("userId", 7)
            };

            service = new TypecodeAPIServices<PostDTO>(new PostAPIRunner(
            new RestClient(TypecodeReader.BaseUrl), $"posts/{args.Where(x => x.Key == "id").First().Value}", Method.PUT, args));

            Assert.That(service.Status, Is.EqualTo("OK"));
        }

        [Test]
        public void ReturnValuesHaveBeenUpdated()
        {
            var args = new List<KeyValuePair<string, object>> {
                new KeyValuePair<string, object>("id", 1),
                new KeyValuePair<string, object>("title", "newTitle"),
                new KeyValuePair<string, object>("body", "NewBodyContent"),
                new KeyValuePair<string, object>("userId", 7)
            };

            service = new TypecodeAPIServices<PostDTO>(new PostAPIRunner(
            new RestClient(TypecodeReader.BaseUrl), $"posts/{args.Where(x => x.Key == "id").First().Value}", Method.PUT, args));

            Assert.That(service.results.title, Is.EqualTo("newTitle"));
            Assert.That(service.results.body, Is.EqualTo("NewBodyContent"));
            Assert.That(service.results.userId, Is.EqualTo(7));       
        }

        [Test]
        public void CheckIfChangingPostId_ReturnsThePostId_Unchanged()
        {
            var args = new List<KeyValuePair<string, object>> {
                new KeyValuePair<string, object>("id", 234234),
                new KeyValuePair<string, object>("title", "newTitle"),
                new KeyValuePair<string, object>("body", "NewBodyContent"),
                new KeyValuePair<string, object>("userId", 7)
            };

            service = new TypecodeAPIServices<PostDTO>(new PostAPIRunner(
            new RestClient(TypecodeReader.BaseUrl), $"posts/7", Method.PUT, args));

            Assert.That(service.results.userId, Is.EqualTo(7));
        }
    }
}
