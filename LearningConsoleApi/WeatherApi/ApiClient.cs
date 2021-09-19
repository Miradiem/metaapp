using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metaapp.WeatherApi
{
    public class ApiClient
    {
        private readonly string _baseUrl;

        public ApiClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public IFlurlClient Create()
        {
            var client = new FlurlClient(_baseUrl);

            return client;
        }
    }
}
