using Domain.Core.DTO;
using Microsoft.Extensions.Configuration;
using Services.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace Services.Core.Implementation
{
    public class ServiceSap : IServiceSap
    {
        private readonly IConfiguration _configuration;
        public ServiceSap(IConfiguration configuration) {
            _configuration = configuration;
        }
        public async Task<HttpStatusCode> CreateOrderSap(Ordenes order)
        {
            Uri url = new Uri(string.Format(_configuration["SAP_S4HANA:UrlService"]));
            string jsonBody = JsonConvert.SerializeObject(order, Formatting.Indented);
            HttpResponseMessage response = await ExecutePut(url, jsonBody);
            if (response.IsSuccessStatusCode)
            {
                return response.StatusCode;
            }
            else
            {
                throw new Exception($"ERROR_SAP_SERVICE: {response.StatusCode}");
            }
        }

        protected async Task<HttpResponseMessage> ExecutePut(Uri url, string objectJson, Dictionary<string, string> headers = null)
        {
            HttpContent content = new StringContent(objectJson, Encoding.UTF8);
            HttpResponseMessage responseHttp = null;

            using (HttpClient client = this.SetHeaders(headers))
            {
                responseHttp = await client.PutAsync(url, content);
            }

            return responseHttp;
        }

        public HttpClient SetHeaders(Dictionary<string, string> headers = null)
        {
            HttpClient client = this.GetHttpClient();

            if (headers == null) headers = new Dictionary<string, string>();

            headers.Add("Accept", "application/json");
            headers.Add("Content-Type", "application/json");
            headers.Add("SAP-API-AppKey", _configuration["SAP_S4HANA:ApiKey"]);

            foreach (KeyValuePair<string, string> header in headers)
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
            }

            return client;
        }

        public HttpClient GetHttpClient()
        {
            return new HttpClient();
        }
    }
}
