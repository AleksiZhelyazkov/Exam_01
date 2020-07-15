using IntegrationTests.Methods;
using IntegrationTests.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class Tests
    {
        private HttpClient _client;
        private Author _actualAuthor;
        private Book _book;
        private List<Book> _books;

        [SetUp]
        public void Setup()
        {
            _client = new HttpClient();
            _client.BaseAddress = new System.Uri("https://libraryjuly.azurewebsites.net/");
            _books = new List<Book>();
        }

        [Test]
        [Order(1)]
        public async Task AddNewAuthor()
        {
            var Author = new Author();

            Author.FirstName = "FN_Testov_A";
            Author.LastName = "LN_753951";
            Author.Genre = "Fantasy";

            var content = new StringContent(Author.ToJson(), Encoding.UTF8, "application/json");
            
            var response = await _client.PostAsync("/api/authors", content);
            response.EnsureSuccessStatusCode(); var responseAsString = await response.Content.ReadAsStringAsync();
            _actualAuthor = Author.FromJson(responseAsString);

            var expectedAuthor = new Author()
            {
                   
                Name = $"{Author.FirstName} {Author.LastName}",
                Genre = Author.Genre
            };

            Assert.AreEqual(expectedAuthor.Name, _actualAuthor.Name);
            Assert.AreEqual(expectedAuthor.Genre, _actualAuthor.Genre);
        }

        [Test]
        [Order(2)]
        public async Task AddNewBooks()
        {
            var book = new Book();
            book.Title = "TestBook1";
            book.Description= "My First Test Books aa..";
            var content = new StringContent(book.ToJson(), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"/api/authors/{_actualAuthor.Id}/books", content);
                response.EnsureSuccessStatusCode();

            var responceAsString = await response.Content.ReadAsStringAsync();
                book = Book.FromJson(responceAsString);

             Assert.IsNotNull(book.Id);
             _books.Add(book);
             _book = book;
        }

        [Test]
        [Order(3)]
        public async Task GetBook()
        {
           var response = await _client.GetAsync($"/api/authors/{_actualAuthor.Id}/books");
            response.EnsureSuccessStatusCode();

            var responceAsString = await response.Content.ReadAsStringAsync();
            var realbook = Book.FromJson(responceAsString);
            //не ми се получи в convert-a :|

            Assert.AreEqual(_book.Title, realbook.Title);
        }

        [Test]
        [Order(4)]
        public async Task DeleteBook()
        {
            var response = await _client.GetAsync
                ($"/api/authors/{_actualAuthor.Id}/books/{_book.Id}");

            Assert.AreEqual(HttpStatusCode.OK,response.StatusCode);
        }
    }
}