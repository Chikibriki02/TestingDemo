using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TestProject1.Steps
{
    [Binding]
    public class UserSteps
    {
        private const string BaseUrl = "https://demoqa.com";

        [Given(@"Create user via API")]
        public async Task GivenCreateUserViaApi()
        {
            var client = new HttpClient();
            var newUser = new
            {
                userName = "Test",
                password = "123123Aa%"
            };

            var content = new StringContent(
                Newtonsoft.Json.JsonConvert.SerializeObject(newUser),
                Encoding.UTF8,
                "application/json");

            var response = await client.PostAsync($"{BaseUrl}/Account/v1/GenerateToken", content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var responseBody = await response.Content.ReadAsStringAsync();

        }

    }
}
