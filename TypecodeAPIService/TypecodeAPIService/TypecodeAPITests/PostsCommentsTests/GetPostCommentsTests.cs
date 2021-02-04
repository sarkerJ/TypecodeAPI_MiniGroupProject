using NUnit.Framework;
using RestSharp;
using System.Linq;
using TypecodeAPIService.APIRunners;
using TypecodeAPIService.DTOs;

namespace TypecodeAPIService.TypecodeAPITests
{
    public class GetPostCommentsTests
    {
        TypecodeAPIServices<PostCommentsDTO[]> service;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            service = new TypecodeAPIServices<PostCommentsDTO[]>(new PostAPIRunner(new RestClient(TypecodeReader.BaseUrl), "posts/1/comments"));
        }

        [Test]
        public void CommentSuccessTest()
        {
            Assert.That(service.Status, Is.EqualTo("OK"));
        }

        [Test]
        public void PostIdLocatedTest()
        {
            Assert.That(service.results.Where(x => x.postId == 1).Count() > 0);
        }
    }
}
