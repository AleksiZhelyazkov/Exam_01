﻿using Newtonsoft.Json;

namespace IntegrationTests.Models
{
    public static class Serialize
    {
        public static string ToJson(this Book self) => JsonConvert.SerializeObject(self, IntegrationTests.Models.Converter.Settings);

        public static string ToJson(this Author self) => JsonConvert.SerializeObject(self, IntegrationTests.Models.Converter.Settings);
    }
}
