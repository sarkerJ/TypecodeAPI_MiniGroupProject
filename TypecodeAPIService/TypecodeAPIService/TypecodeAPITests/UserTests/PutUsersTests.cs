using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypecodeAPIService.APIRunners;
using TypecodeAPIService.DTOs;

namespace TypecodeAPIService.TypecodeAPITests.UserTests
{
    public class PutUsersTests
    {
        TypecodeAPIServices<UsersDTO> service;

        [Test]
        public void CheckResultIsCreatedFromPutRequest_WithValidID()
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("name", "Oliver"),
                new KeyValuePair<string, object>("username", "Oliver123")
            };
            service = new TypecodeAPIServices<UsersDTO>(new UsersAPIRunner(
                 new RestClient(TypecodeReader.BaseUrl), "users/1", Method.PUT, args));
            Assert.That(service.Status, Is.EqualTo("OK"));
        }

        [Test]
        public void CheckReturnedUserFromPutRequest_HasCorrectChangedDetails()
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("name", "Oliver"),
                new KeyValuePair<string, object>("username", "Oliver123")
            };
            service = new TypecodeAPIServices<UsersDTO>(new UsersAPIRunner(
                 new RestClient(TypecodeReader.BaseUrl), "users/1", Method.PUT, args));
            Assert.That(service.results.name, Is.EqualTo("Oliver"));
            Assert.That(service.results.username, Is.EqualTo("Oliver123"));
        }

        [Test]
        public void CheckReturnedUserFromPutRequest_HasNoOtherFieldsChanged()
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("name", "Oliver"),
                new KeyValuePair<string, object>("username", "Oliver123"),
                new KeyValuePair<string, object>("email", "Sincere@april.biz"),
                new KeyValuePair<string, object>("address", 
                    new Address
                    {
                        street = "Kulas Light",
                        suite = "Apt. 556",
                        city = "Gwenborough"
                    })
            };
            service = new TypecodeAPIServices<UsersDTO>(new UsersAPIRunner(
                 new RestClient(TypecodeReader.BaseUrl), "users/1", Method.PUT, args));
            Assert.That(service.results.email, Is.EqualTo("Sincere@april.biz"));
            Assert.That(service.results.address.street, Is.EqualTo("Kulas Light"));
            Assert.That(service.results.address.suite, Is.EqualTo("Apt. 556"));
            Assert.That(service.results.address.city, Is.EqualTo("Gwenborough"));
        }
    }
}
