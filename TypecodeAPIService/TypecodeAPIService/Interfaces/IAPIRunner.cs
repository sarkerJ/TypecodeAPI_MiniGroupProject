using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypecodeAPIService.Interfaces
{
    public interface IAPIRunner<T>
    {
        RestClient Client { get; }
        T ResponseDTO { get; set; }
        List<KeyValuePair<string, object>> Args { get; }
        void Execute();
    }
}
