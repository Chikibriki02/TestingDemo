using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestProject1.Api;
using TestProject1.Models;

namespace TestProject1.Steps
{
    [Binding]
    public class UserSteps
    {
        private readonly string _baseUrl = "https://demoqa.com";
        private readonly UserService _userService;
        private List<string> _users = new List<string>();
        private CreateUser _newUser = new CreateUser()
        {
            UserName = "Test11",
            Password = "123123Aa%"
        };

        public UserSteps()
        {
            _userService = new UserService(_baseUrl);
        }

        [Given(@"Create user via API")]
        public async Task GivenCreateUserViaApi()
        {
            

            var response = await _userService.CreateUserAsync(_newUser);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));

            _users.Add(response.Body.userId);
        }

        [When(@"delete user")]
        public async Task WhenDeleteUser()
        {
            foreach (var user in _users)
            {
               var response = await _userService.DeleteUserAsync(user);
               Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            }
            
        }

        [Given(@"Authorize user")]
        public async Task GivenAuthorizeUser()
        {
            var response = await _userService.AuthorizeUserAsync(_newUser);
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(response.Body, Is.EqualTo(true));

            });
            
        }

        [Given(@"Generate Token")]
        public async Task GivenGenerateToken()
        {
            var response = await _userService.GenerateTokenForUserAsync(_newUser);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Given(@"Get info for user")]
        public async Task GivenGetInfoForUser()
        {
            foreach (var user in _users)
            {
                var response = await _userService.GetUserAsync(user);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            }
        }

    }
}
