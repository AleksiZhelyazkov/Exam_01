using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace IntegrationTests.Models
{
    public partial class Author
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("firstName", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }

        [JsonProperty("lastName", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }

        [JsonProperty("genre", NullValueHandling = NullValueHandling.Ignore)]
        public string Genre { get; set; }

        [JsonProperty("links", NullValueHandling = NullValueHandling.Ignore)]
        public List<Link> Links { get; set; }

        [JsonProperty("books", NullValueHandling = NullValueHandling.Ignore)]
        public List<Book> Books { get; set; }

        public static Author FromJson(string json) => JsonConvert.DeserializeObject<Author>(json, IntegrationTests.Models.Converter.Settings);
    }
}
