using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypecodeAPIService.Interfaces;

namespace TypecodeAPIService.APIRunners
{
    public class UsersAPIRunner : IAPIRunner
    {
        public RestClient Client { get; }


        public List<KeyValuePair<string, object>> Args { get; }

        public string Status { get; set; }
        public string RawResponse { get; set; }

        public UsersAPIRunner(RestClient client, string resource)
        {
            Client = client;
            Args = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("resource", resource) };
        }

        public void Execute()
        {
            var request = new RestRequest(Args.Where(x => x.Key == "resource").First().Value.ToString());
            var entireResponse = Client.Execute(request);
            Status = entireResponse.StatusCode.ToString();
            RawResponse = Client.Execute(request).Content;
        }
    }
}
