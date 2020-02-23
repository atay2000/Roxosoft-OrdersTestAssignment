using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrdersClient.Helper
{
    public class OrdersWebAPI
    {
        public HttpClient Initial()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(configuration.GetValue<string>("WebApiUri"));

            return client;
        }

    }
}
