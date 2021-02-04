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
    public class DeleteUsersTests
    {
        TypecodeAPIServices<UsersDTO> service;

        [Test]
        public void CheckUserIsDeleted_WithValidIDInURL()
        {
            service = new TypecodeAPIServices<UsersDTO>(new UsersAPIRunner(
                 new RestClient(TypecodeReader.BaseUrl), "users/1", Method.DELETE));
            Assert.That(service.Status, Is.EqualTo("OK"));
        }

        [Test]
        public void CheckThatAllUsersCannotBeDeleted()
        {
            service = new TypecodeAPIServices<UsersDTO>(new UsersAPIRunner(
                 new RestClient(TypecodeReader.BaseUrl), "users", Method.DELETE));
            Assert.That(service.Status, Is.EqualTo("NotFound"));
        }
    }
}
