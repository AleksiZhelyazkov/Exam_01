using IntegrationTests.Models;

namespace IntegrationTests.Factories
{
    public static class AuthorFactory
    {
        public static Author CreateAuthor()
        {
            return new Author
            {
                FirstName = "FN_Testov_A",
                LastName = "LN_753951",
                Genre = "Male"
            };

        }
    }
}
