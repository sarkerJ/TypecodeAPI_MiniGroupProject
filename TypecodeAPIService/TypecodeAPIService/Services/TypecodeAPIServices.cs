using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypecodeAPIService.APIRunners;
using TypecodeAPIService.DTOs;
using TypecodeAPIService.Interfaces;
using TypecodeAPIService;

namespace TypecodeAPIService
{
    public class TypecodeAPIServices<T>
    {
        public T results { get; set; }

        public string Status { get; set; }
        public TypecodeAPIServices( IAPIRunner<T> postdto)
        {
            postdto.Execute();
            results = postdto.ResponseDTO;
            Status = postdto.Status;
        }
    }
}
