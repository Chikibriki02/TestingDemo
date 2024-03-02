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
    public abstract class Api
    {
        protected ApiContext Context;
        protected readonly HttpClient _client = new();
        protected readonly string _baseUrl = "https://demoqa.com";
        protected Api(ApiContext apiContext)
        {
            Context = apiContext;
        }
        protected async Task<HttpResponseData<T>> ConvertResponseData<T>(HttpResponseMessage response)
        {
            Context.LastResponseData = response;
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return new HttpResponseData<T>()
                {
                    StatusCode = response.StatusCode,
                    Body = JsonConvert.DeserializeObject<T>(body)
                };
            }
            else
            {
                return new HttpResponseData<T>()
                {
                    StatusCode = response.StatusCode,
                    Body = default(T),
                    Message = body
                };
            }
        }
    }
}
