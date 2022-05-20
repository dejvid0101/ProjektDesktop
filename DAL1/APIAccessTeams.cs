using DAL1.QuickType;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL1
{
    public class APIAccessTeams : IAccess
    {
        
        
        public static IList<Team> GetData(string m)
        {
            var apiclient = new RestClient(m);
            var apiresultt = apiclient.ExecuteAsync(new RestRequest());
            return JsonConvert.DeserializeObject<IList<Team>>(apiresultt.Result.Content);
        }

        public static IList<Tekma> GetData2(string m)
        {
            var apiclient = new RestClient(m);
            var apiresultt = apiclient.ExecuteAsync(new RestRequest());
            return JsonConvert.DeserializeObject<IList<Tekma>>(apiresultt.Result.Content);
        }

    }
}
