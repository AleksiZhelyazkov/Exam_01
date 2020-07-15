using IntegrationTests.Factories;
using IntegrationTests.Models;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;

namespace IntegrationTests
{
    public class Tests
    {
        private RestClient _httpClient;
        private string _authorid;
        private string _bookId;

        [SetUp]
        public void Setup()
        {
            _httpClient = new RestClient();
            _httpClient.BaseUrl = new Uri("https://libraryjuly.azurewebsites.net");

            _authorid = CreateAuthor();
            _bookId = AssignNewBookToAuthor();
        }


        [Test]
        public void PostBookToAuthor()
        {
            var request = new RestRequest($"/api/authors/{_authorid}/books");

            var newBook = new Book()
            {
                Title = "New Book Test",
                Description = "Next try",
                AuthorId = new Guid()
            };

            request.AddJsonBody(newBook.ToJson(), "application/json");

            var response = _httpClient.Post(request);
            var responceAsString = response.Content.ToString();
            var actualBook = Book.FromJson(responceAsString);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.AreEqual(newBook.Title, actualBook.Title);
        }

        [Test]
        public void GetBookForAuthor()
        {
            var request = new RestRequest($"/api/authors/{_authorid}/books");

            var response = _httpClient.Get(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void DeleteBookForAuthor()
        {
            var request = new RestRequest($"/api/authors/{_authorid}/books/{_bookId}");

            var response = _httpClient.Delete(request);

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }



        public string CreateAuthor()
        {
            var newAuthor = AuthorFactory.CreateAuthor();

            var request = new RestRequest($"/api/authors");
            request.AddJsonBody(newAuthor.ToJson(), "application/json");

            var response = _httpClient.Post(request);

            var createdAuthor = Author.FromJson(response.Content);

            return createdAuthor.Id.ToString();
        }

        public string AssignNewBookToAuthor()
        {
            var newBook = BookFactory.CreateBook();

            var request = new RestRequest($"/api/authors/{_authorid}/books");
            request.AddJsonBody(newBook.ToJson(), "application/json");

            var response = _httpClient.Post(request);

            var assignedBook = Book.FromJson(response.Content);

            return assignedBook.Id.ToString();
        }
    }
}