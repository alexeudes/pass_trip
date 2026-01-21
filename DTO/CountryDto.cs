namespace pass_trip.DTO
{
    public class CountryDto
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public FlagsDto Flags { get; set; }
        public string[] Capitals { get; set; }
        public long Population { get; set; }
        public double Area { get; set; }
        public string[] Timezones { get; set; }
    }

    public class FlagsDto
    {
        public string Png { get; set; }
        public string Svg { get; set; }
    }
}
