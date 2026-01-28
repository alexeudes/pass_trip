using System.Text.Json.Serialization;

namespace pass_trip.DTO
{
    public class CountryDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("subregion")]
        public string Subregion { get; set; }

        [JsonPropertyName("flags")]
        public FlagsDto Flags { get; set; }

        [JsonPropertyName("capitals")]
        public string[] Capitals { get; set; }

        [JsonPropertyName("population")]
        public long Population { get; set; }

        [JsonPropertyName("area")]
        public double Area { get; set; }

        [JsonPropertyName("timezones")]
        public string[] Timezones { get; set; }

        [JsonPropertyName("carSide")]
        public string CarSide { get; set; }

        [JsonPropertyName("postalCodeFormat")]
        public string PostalCodeFormat { get; set; }

        [JsonPropertyName("startOfWeek")]
        public string StartOfWeek { get; set; }
    }

    public class FlagsDto
    {
        public string Png { get; set; }
        public string Svg { get; set; }
    }
}
