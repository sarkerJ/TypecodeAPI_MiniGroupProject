﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypecodeAPIService.APIRunners;
using TypecodeAPIService.DTOs;

namespace TypecodeAPIService.TypecodeAPITests
{
    public class UsersDTOTests
    {
        TypecodeAPIServices<UsersDTO> service;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            service = new TypecodeAPIServices<UsersDTO>(new UsersAPIRunner<UsersDTO>(
            new RestSharp.RestClient(TypecodeReader.BaseUrl), "users/1"));
        }

        [Test]
        public void CheckResultIsOkFromGetRequest()
        {
            Assert.That(service.Status, Is.EqualTo("OK"));
        }

        [Test]
        public void CheckCorrectIDReturnedFromGetRequest()
        {
            Assert.That(service.results.id, Is.EqualTo(1));
        }
    }
}