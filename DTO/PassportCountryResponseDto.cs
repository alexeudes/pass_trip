namespace pass_trip.DTO
{
    public class PassportCountryResponseDto
    {
        // Passport
        public string Origin { get; set; }
        public string Destination { get; set; }
        public VisaDto Visa { get; set; }

        // Country
        public CountryDto Country { get; set; }
    }        
}