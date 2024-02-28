using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Models
{
    public class HttpResponseData<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public T Body { get; set; }
        public string Message { get; set; }

    }

    public static class Convertor
    {
        public static async Task<HttpResponseData<T>> ConvertResponseData<T>(this HttpResponseMessage response)
        {
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
