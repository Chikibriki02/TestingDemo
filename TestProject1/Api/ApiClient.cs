// Ignore Spelling: Api

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.Context;
using TestProject1.Models;

namespace TestProject1.Api
{
    public abstract class ApiClient
    {
        protected ApiContext ApiContext;
        protected readonly HttpClient _client = new();
        protected readonly string _baseUrl = "https://demoqa.com";
        protected ApiClient(ApiContext apiApiContext)
        {
            ApiContext = apiApiContext;
        }
        protected async Task<HttpResponseData<T?>> ConvertResponseData<T>(HttpResponseMessage response)
        {
            ApiContext.LastResponseData = response;
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return new HttpResponseData<T?>()
                {
                    StatusCode = response.StatusCode,
                    Body = JsonConvert.DeserializeObject<T>(body)
                };
            }
            else
            {
                return new HttpResponseData<T?>()
                {
                    StatusCode = response.StatusCode,
                    Body = default(T),
                    Message = body
                };
            }
        }
    }
}
