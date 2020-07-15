using IntegrationTests.Models;

namespace IntegrationTests.Factories
{
    public static class BookFactory
    {
        public static Book CreateBook()
        {
            return new Book()
            {
                Title = "TestBook1",
                Description = "My First Test Book aa."
            };

        }
    }
}
