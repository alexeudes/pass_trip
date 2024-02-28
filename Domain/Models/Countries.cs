using System;
using System.Text.Json.Serialization;
using pass_trip.Enums;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace pass_trip.Domain.Models
{
	public class Countries
	{
		public Countries() { }

		public Guid ID { get; set; }

		[property: JsonPropertyName("name")]
		public CountryName Name { get; set; }

        [property: JsonPropertyName("capital")]
        public string[] Capital { get; set; }

        [property: JsonPropertyName("region")]
        public string Region { get; set; }

        [property: JsonPropertyName("flag")]
        public string Flag { get; set; }

        [property: JsonPropertyName("languages")]
        public Dictionary<string, string> Languages { get; set; }

        [property: JsonPropertyName("area")]
        public decimal Area { get; set; }

        [property: JsonPropertyName("population")]
        public decimal Population { get; set; }

        [property: JsonPropertyName("timezones")]
        public string[] Timezones { get; set; } = Array.Empty<string>();

        [property: JsonPropertyName("currencies")]
        public Dictionary<string, Dictionary<string,string>> Currencies { get; set; }
    }

    public class CountryName
    {
        [property: JsonPropertyName("common")]
        public string Common { get; set; }
    }
}

