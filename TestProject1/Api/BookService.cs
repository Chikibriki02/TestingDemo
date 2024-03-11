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
    internal class BookService(ApiContext apiContext) : ApiClient(apiContext)
    {
        public async Task<HttpResponseData<Books?>> GetAllBooksAsync()
        {
            var response = await _client.GetAsync($"{_baseUrl}/BookStore/v1/Books");

            return await ConvertResponseData<Books>(response);
        }
    }
}
