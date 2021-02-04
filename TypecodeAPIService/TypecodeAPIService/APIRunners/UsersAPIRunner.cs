using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypecodeAPIService.Interfaces;

namespace TypecodeAPIService.APIRunners
{
    public class UsersAPIRunner : APIRunnerBase
    {
        public UsersAPIRunner(RestClient client, string resource, Method method = Method.GET) : base(client, resource, method)
        {
        }
        public UsersAPIRunner(RestClient client, string resource, Method method, List<KeyValuePair<string, object>> bodyArgs) : base(client, resource, method, bodyArgs)
        {
        }
    }
}
