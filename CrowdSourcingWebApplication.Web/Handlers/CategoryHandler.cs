using CrowdSourcingWebApplication.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Web;

namespace CrowdSourcingWebApplication.Web.Handlers
{
    public class CategoryHandler
    {
        HttpClient client;
        public IEnumerable<Category> GetCategory(string tenant)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://crowdsourcingwebap.azurewebsites.net/api/category/getbytenant/" + tenant + "/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
            IEnumerable<Category> categories = JsonConvert.DeserializeObject<Category[]>(response.Content.ReadAsStringAsync().Result);
            return categories;
        }

        public HttpStatusCode AddCategory(Category c)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://crowdsourcingwebap.azurewebsites.net/api/category");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Category));
            HttpContent content = new ObjectContent<Category>(c, new JsonMediaTypeFormatter());
            var requestMessage = new HttpRequestMessage();
            var response =  client.PostAsync(client.BaseAddress, content);

            return response.Result.StatusCode;
        }

        public HttpStatusCode DeleteCategory(Category c)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://crowdsourcingwebap.azurewebsites.net/api/category/" + c.CategoryId);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var requestMessage = new HttpRequestMessage();
            var response = client.DeleteAsync(client.BaseAddress);

            return response.Result.StatusCode;
        }

        
    }
}