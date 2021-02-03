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
    public class PostAPIRunner : IAPIRunner
    {
        Method _method = Method.GET;

        public string RawResponse { get; set; }
        public RestClient Client { get; }

        public List<KeyValuePair<string, object>> Args { get; }

        public string Status { get; set; }

        public PostAPIRunner(RestClient client, string resource)
        {
            Client = client;
            Args = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("resource", resource) };
        }

        public PostAPIRunner(RestClient client, string resource, List<KeyValuePair<string, object>> bodyArgs, Method method) : this(client, resource)
        {
            Args.AddRange(bodyArgs);
            _method = method;
        }

        public void Execute()
        {
            var request = new RestRequest(Args.Where(x => x.Key == "resource").First().Value.ToString());
            var bodyArgs = Args.Where(x => x.Key != "resource");
            request.Method = _method;
            JObject body = new JObject();
            if (bodyArgs.Count() > 0)
            {
                foreach(var arg in bodyArgs)
                {
                    body[arg.Key] = JToken.FromObject(arg.Value);
                }
                request.AddJsonBody(body.ToString());
            }
            var entireResponse = Client.Execute(request);
            Status = entireResponse.StatusCode.ToString();
            RawResponse = entireResponse.Content;
        }
    }
}
