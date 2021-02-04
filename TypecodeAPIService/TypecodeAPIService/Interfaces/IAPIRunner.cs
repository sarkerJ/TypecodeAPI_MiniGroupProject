using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypecodeAPIService.Interfaces
{
    public interface IAPIRunner
    {
        RestClient Client { get; }
        string RawResponse { get; set; }
        List<KeyValuePair<string, object>> Args { get; }
        string Status { get; set; }
        void Execute();
    }
}
