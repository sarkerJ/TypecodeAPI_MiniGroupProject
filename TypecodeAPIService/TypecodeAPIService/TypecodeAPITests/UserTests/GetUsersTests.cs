using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypecodeAPIService.APIRunners;
using TypecodeAPIService.DTOs;
using TypecodeAPIService.Utilities;

namespace TypecodeAPIService.TypecodeAPITests
{
    public class GetUsersTests
    {
        TypecodeAPIServices<UsersDTO> service;
        TypecodeAPIServices<UsersDTO[]> bulkService;

        [Test]
        public void CheckResultIsOkFromGetRequest_WithValidID()
        {
            service = new TypecodeAPIServices<UsersDTO>(new UsersAPIRunner(
                 new RestSharp.RestClient(TypecodeReader.BaseUrl), "users/1"));
            Assert.That(service.Status, Is.EqualTo("OK"));
        }

        [TestCase(100)]
        [TestCase("r")]
        [TestCase("!")]
        public void CheckResultIsNotFoundFromGetRequest_WithInvalidID(object parameter)
        {
            service = new TypecodeAPIServices<UsersDTO>(new UsersAPIRunner(
               new RestSharp.RestClient(TypecodeReader.BaseUrl), $"users/{parameter}"));
            Assert.That(service.Status, Is.EqualTo("NotFound"));
        }

        [Test]
        public void CheckCorrectIDReturnedFromGetRequest()
        {
            service = new TypecodeAPIServices<UsersDTO>(new UsersAPIRunner(
                new RestSharp.RestClient(TypecodeReader.BaseUrl), "users/1"));
            Assert.That(service.results.id, Is.EqualTo(1));
        }

        [Test]
        public void CheckCorrectAddressReturnedFromGetRequest()
        {
            service = new TypecodeAPIServices<UsersDTO>(new UsersAPIRunner(
                 new RestSharp.RestClient(TypecodeReader.BaseUrl), "users/1"));
            Assert.That(service.results.address.street, Is.EqualTo("Kulas Light"));
        }

        [Test]
        public void CheckCorrectNumberOfUsersReturnedFromGetRequest_WithNoIDSpecified()
        {
            bulkService = new TypecodeAPIServices<UsersDTO[]>(new UsersAPIRunner(
               new RestSharp.RestClient(TypecodeReader.BaseUrl), "users"));
            Assert.That(UsersUtilities.FindNumberOfUsers(bulkService.results), Is.EqualTo(10));
        }

        [TestCase("Leanne Graham")]
        public void CheckUserExistsInArrayOfUsers_GivenName(string name)
        {
            bulkService = new TypecodeAPIServices<UsersDTO[]>(new UsersAPIRunner(
               new RestSharp.RestClient(TypecodeReader.BaseUrl), "users"));
            Assert.That(UsersUtilities.VerifyUserExistsByName(bulkService.results, name));
        }

        [TestCase("Leanne Graham")]
        public void ReturnedUserFromArrayOfUsersHasCorrectProperties_GivenName(string name)
        {
            bulkService = new TypecodeAPIServices<UsersDTO[]>(new UsersAPIRunner(
              new RestSharp.RestClient(TypecodeReader.BaseUrl), "users"));
            UsersDTO retrievedUser = UsersUtilities.GetUserIfExists(bulkService.results, name);
            Assert.That(retrievedUser.username, Is.EqualTo("Bret"));
            Assert.That(retrievedUser.phone, Is.EqualTo("1-770-736-8031 x56442"));
        }
    }
}
