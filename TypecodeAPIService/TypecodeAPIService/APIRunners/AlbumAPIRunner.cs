using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypecodeAPIService.APIRunners
{
    public class AlbumAPIRunner : APIRunnerBase
    {
        public AlbumAPIRunner(RestClient client, string resource, Method method = Method.GET) : base(client, resource, method)
        {
        }
        public AlbumAPIRunner(RestClient client, string resource, Method method, List<KeyValuePair<string, object>> bodyArgs) : base(client, resource, method, bodyArgs)
        {
        }
    }
}
