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

        TypecodeAPIServices<PostDTO[]> allPostsService;


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

        [Test]
        public void CheckIfAll_PostsAreReturnedStatusIs_OK()
        {
            allPostsService = new TypecodeAPIServices<PostDTO[]>(new PostAPIRunner(new RestClient(TypecodeReader.BaseUrl), "posts/"));

            Assert.That(allPostsService.Status, Is.EqualTo("OK"));
        }

        [Test]
        public void CheckIfAll_PostsAreReturnedCount_IsGreaterThan_One()
        {
            allPostsService = new TypecodeAPIServices<PostDTO[]>(new PostAPIRunner(new RestClient(TypecodeReader.BaseUrl), "posts/"));

            Assert.That(allPostsService.results.Length, Is.GreaterThan(1));
        }

        [Test]
        public void CheckIfAll_PostsAreReturnedCount_Is100()
        {
            allPostsService = new TypecodeAPIServices<PostDTO[]>(new PostAPIRunner(new RestClient(TypecodeReader.BaseUrl), "posts/"));

            Assert.That(allPostsService.results.Length, Is.EqualTo(100));
        }
    }
}
