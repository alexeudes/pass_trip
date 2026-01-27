using System;
using System.Text.Json.Serialization;
using pass_trip.Enums;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace pass_trip.Domain.Models
{
	using System.Text.Json.Serialization;

    public class Country
    {
        public Guid ID { get; set; }

        [JsonPropertyName("name")]
        public CountryName Name { get; set; }

        [JsonPropertyName("capital")]
        public string[] Capital { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("subregion")]
        public string Subregion { get; set; }

        [JsonPropertyName("flags")]
        public Flags Flags { get; set; }

        [JsonPropertyName("languages")]
        public Dictionary<string, string> Languages { get; set; }

        [JsonPropertyName("area")]
        public double Area { get; set; }

        [JsonPropertyName("population")]
        public long Population { get; set; }

        [JsonPropertyName("timezones")]
        public string[] Timezones { get; set; }

        [JsonPropertyName("currencies")]
        public Dictionary<string, Currency> Currencies { get; set; }
    }

    public class CountryName
    {
        [JsonPropertyName("common")]
        public string Common { get; set; }

        [JsonPropertyName("official")]
        public string Official { get; set; }
    }

    public class Currency
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
    }

    public class Flags
    {
        [JsonPropertyName("png")]
        public string Png { get; set; }

        [JsonPropertyName("svg")]
        public string Svg { get; set; }
    }
}

