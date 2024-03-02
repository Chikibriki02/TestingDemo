using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestProject1.Context;

namespace TestProject1.Models
{
    public class HttpResponseData<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public T Body { get; set; }
        public string Message { get; set; }

    }
}
