using CrowdSourcingWebApplication.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace CrowdSourcingWebApplication.Web.Handlers
{
    public class IdeaHandler
    {
        HttpClient client;
            public IEnumerable<Idea> RetrieveIdeas(string tenant)
            {

            
            client = new System.Net.Http.HttpClient();
            client.BaseAddress = new Uri("http://crowdsourcingwebap.azurewebsites.net/api/idea/getideasbytenant/" + tenant + "/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;

            // HttpRequestMessage f = new HttpRequestMessage(HttpMethod.Get, client.BaseAddress);
            


            
            IEnumerable<Idea> ideas = JsonConvert.DeserializeObject<Idea[]>(response.Content.ReadAsStringAsync().Result);
            return ideas;

            }
    }
}