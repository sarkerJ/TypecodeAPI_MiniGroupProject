using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypecodeAPIService.APIRunners;
using TypecodeAPIService.DTOs;

namespace TypecodeAPIService.TypecodeAPITests.UsersDTOTests
{
    public class NewUsersTests
    {
        TypecodeAPIServices<UsersDTO> service;

        [Test]
        public void CheckResultIsCreatedFromPostRequest_WithValidID()
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("name", "Oliver"),
                new KeyValuePair<string, object>("username", "Oliver123")
            };
            service = new TypecodeAPIServices<UsersDTO>(new UsersAPIRunner(
                 new RestClient(TypecodeReader.BaseUrl), "users", Method.POST, args));
            Assert.That(service.Status, Is.EqualTo("Created"));
        }

        [TestCase(1)]
        [TestCase("r")]
        [TestCase("!")]
        public void CheckResultIsNotFoundFromPostRequest_WithInvalidID(object parameter)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("name", "Oliver"),
                new KeyValuePair<string, object>("username", "Oliver123")
            };
            service = new TypecodeAPIServices<UsersDTO>(new UsersAPIRunner(
                 new RestClient(TypecodeReader.BaseUrl), $"users{parameter}", Method.POST, args));
            Assert.That(service.Status, Is.EqualTo("NotFound"));
        }

        [Test]
        public void CheckCreatedUserHasCorrectID()
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("name", "Oliver"),
                new KeyValuePair<string, object>("username", "Oliver123")
            };
            service = new TypecodeAPIServices<UsersDTO>(new UsersAPIRunner(
                 new RestClient(TypecodeReader.BaseUrl), "users", Method.POST, args));
            Assert.That(service.results.id, Is.EqualTo(11));
        }

        [Test]
        public void CheckCreatedUserHasCorrectName()
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("name", "Oliver"),
                new KeyValuePair<string, object>("username", "Oliver123")
            };
            service = new TypecodeAPIServices<UsersDTO>(new UsersAPIRunner(
                 new RestClient(TypecodeReader.BaseUrl), "users", Method.POST, args));
            Assert.That(service.results.name, Is.EqualTo("Oliver"));
        }
    }
}
