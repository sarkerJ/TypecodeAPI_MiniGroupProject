﻿using Newtonsoft.Json;
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
    public abstract class APIRunnerBase : IAPIRunner
    {
        Method _method;

        public string RawResponse { get; set; }
        public RestClient Client { get; }

        public List<KeyValuePair<string, object>> Args { get; }

        public string Status { get; set; }

        public APIRunnerBase(RestClient client, string resource, Method method = Method.GET)
        {
            Client = client;
            Args = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("resource", resource) };
            _method = method;
        }

        public APIRunnerBase(RestClient client, string resource, Method method, List<KeyValuePair<string, object>> bodyArgs) : this(client, resource, method)
        {
            Args.AddRange(bodyArgs);
        }

        public virtual void Execute()
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
