using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace LibraryImplementation.Web.HttpClients
{
    public class GenericHttpClient
    {
        protected HttpClient CreateHttpClient()
        {
            return new()
            {
                BaseAddress = new Uri("https://localhost:5001")
            };
        }

        protected StringContent CreateJsonContent<T>(T contentObject)
        {
            var json = JsonConvert.SerializeObject(contentObject);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}