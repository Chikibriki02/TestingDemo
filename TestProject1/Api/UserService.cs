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
    public class UserService(ApiContext apiContext) : Api(apiContext)
    {
        public async Task<HttpResponseData<User>> CreateUserAsync(CreateUser user)
        {
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{_baseUrl}/Account/v1/User", content);

            return await ConvertResponseData<User>(response);
        }

        public async Task<HttpResponseData<DeleteUser>> DeleteUserAsync(string user)
        {
            var response = await _client.DeleteAsync($"{_baseUrl}/Account/v1/User/{user}");

            return await ConvertResponseData<DeleteUser>(response);
        }

        public async Task<HttpResponseData<bool>> AuthorizeUserAsync(CreateUser user)
        {
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{_baseUrl}/Account/v1/Authorized", content);

            return await ConvertResponseData<bool>(response);
        } 
        public async Task<HttpResponseData<Token>> GenerateTokenForUserAsync(CreateUser user)
        {
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{_baseUrl}/Account/v1/GenerateToken", content);

            return await ConvertResponseData<Token>(response);
        } 
        public async Task<HttpResponseData<User>> GetUserAsync(string user)
        {
            var response = await _client.GetAsync($"{_baseUrl}/Account/v1/User/{user}");

            return await ConvertResponseData<User>(response);
        }
    }
}
