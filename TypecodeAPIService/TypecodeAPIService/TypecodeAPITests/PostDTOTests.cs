using NUnit.Framework;
using TypecodeAPIService.APIRunners;
using TypecodeAPIService.DTOs;

namespace TypecodeAPIService.TypecodeAPITests
{
    public class PostDTOTests
    {

        TypecodeAPIServices<PostDTO> service;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            service = new TypecodeAPIServices<PostDTO>(new PostAPIRunner<PostDTO>(
            new RestSharp.RestClient(TypecodeReader.BaseUrl), "post/1"));
        }

        [Test]
        public void CheckResultIsOk()
        {
            Assert.That(service.Status, Is.EqualTo("OK"));
        }
    }
}
