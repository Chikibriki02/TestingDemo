// Ignore Spelling: Api

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.Models;

namespace TestProject1.Context
{
    public class ApiContext
    {
        public HttpResponseData<User> User { get; set; }
        public HttpResponseData<Books?> Books { get; set; }

        public  HttpResponseMessage? LastResponseData { get; set; }
    }
}
