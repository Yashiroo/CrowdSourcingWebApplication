using CrowdSourcingWebApplication.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Runtime.Serialization.Json;
using System.Web;

namespace CrowdSourcingWebApplication.Web.Handlers
{
    public class LogHandler
    {
        HttpClient client;
        public IEnumerable<Log> GetLogsForTenant(string tenant)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://crowdsourcingwebap.azurewebsites.net/api/log/getbytenant/" + tenant + "/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
            IEnumerable<Log> logs = JsonConvert.DeserializeObject<Log[]>(response.Content.ReadAsStringAsync().Result);



            return logs;
        }



        public HttpStatusCode AddLog(Log l)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://crowdsourcingwebap.azurewebsites.net/api/log");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Category));
            HttpContent content = new ObjectContent<Log>(l, new JsonMediaTypeFormatter());
            var requestMessage = new HttpRequestMessage();
            var response = client.PostAsync(client.BaseAddress, content);

            return response.Result.StatusCode;
        }
    }
}