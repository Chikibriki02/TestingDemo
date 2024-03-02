using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TestProject1.Api;
using TestProject1.Context;
using TestProject1.Models;

namespace TestProject1.Steps
{
    [Binding]
    public class UserSteps
    {
        private readonly string _baseUrl = "https://demoqa.com";
        private readonly UserService _userService;
        private readonly BookService _bookService;
        private ApiContext _apiContext;
        private List<string> _users = new List<string>();
        private CreateUser _newUser = new CreateUser()
        {
            UserName = Guid.NewGuid().ToString(),
            Password = "123123Aa%"
        };

        public UserSteps(ApiContext apiContext )
        {
            _apiContext = apiContext;
            _userService = new UserService(apiContext);
            _bookService = new BookService(apiContext);
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

        [When(@"Send a request to get list of books")]
        public async Task WhenSendARequestToGetListOfBooks()
        {
            _apiContext.Books = await _bookService.GetAllBooksAsync();
        }

        [Then(@"Status code is '([^']*)'")]
        public void ThenStatusCodeIs(HttpStatusCode statusCode)
        {
           Assert.That(_apiContext.LastResponseData.StatusCode, Is.EqualTo(statusCode));
        }

        [Then(@"Response contains a list of books")]
        public void ThenResponseContainsAListOfBooks()
        {
            var books = File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}/Docs/Json/Books.json");
            var expectedBooks = JsonConvert.DeserializeObject<Books>(books);
            //_apiContext.Books.Body.Should().BeEquivalentTo(expectedBooks);
            Assert.Multiple(() =>
            {
                for (int i = 0; i < expectedBooks.books.Count; i++)
                {
                    Assert.That(_apiContext.Books.Body.books[i].author , Is.EqualTo(expectedBooks.books[i].author));
                    Assert.That(_apiContext.Books.Body.books[i].description.Replace("’", "").Replace("—", "") , Is.EqualTo(expectedBooks.books[i].description.Replace("\ufffd", "").Replace("�", "")));
                    Assert.That(_apiContext.Books.Body.books[i].isbn , Is.EqualTo(expectedBooks.books[i].isbn));
                    Assert.That(_apiContext.Books.Body.books[i].pages , Is.EqualTo(expectedBooks.books[i].pages));
                    Assert.That(_apiContext.Books.Body.books[i].publish_date , Is.EqualTo(expectedBooks.books[i].publish_date));
                    Assert.That(_apiContext.Books.Body.books[i].publisher , Is.EqualTo(expectedBooks.books[i].publisher));
                    Assert.That(_apiContext.Books.Body.books[i].subTitle , Is.EqualTo(expectedBooks.books[i].subTitle));
                    Assert.That(_apiContext.Books.Body.books[i].title , Is.EqualTo(expectedBooks.books[i].title));
                    Assert.That(_apiContext.Books.Body.books[i].website , Is.EqualTo(expectedBooks.books[i].website));
                }
            });
        }

    }
}
