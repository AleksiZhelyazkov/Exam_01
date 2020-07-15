using IntegrationTests.Models;
using Newtonsoft.Json;

namespace IntegrationTests.Methods
{
    public static class Serialize
    {
        public static string ToJson(this Book self) => JsonConvert.SerializeObject(self, IntegrationTests.Methods.Converter.Settings);

        public static string ToJson(this Author self) => JsonConvert.SerializeObject(self, IntegrationTests.Methods.Converter.Settings);
    }
}
