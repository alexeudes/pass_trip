using pass_trip.Business.Services.Interfaces;
using pass_trip.DTO;
using pass_trip.Helpers;
using pass_trip.Enums;

namespace pass_trip.Business.Services
{
    public class VisaRequirementsService : IVisaRequirements
	{
        private readonly DataContext _context;
        private readonly ICountriesService _countriesService;
        private readonly IPassportService _passportService;

        public VisaRequirementsService(ICountriesService countriesService, IPassportService passportService, DataContext context)
		{
            _context = context;
            _countriesService = countriesService;
            _passportService =  passportService;
		}

        public async Task<PassportCountryResponseDto> GetPassportCountryResponse(string originCountry, string destCountry)
        {
            var passport = _passportService.GetPassportInfoByOriginAndDestCountries(originCountry, destCountry);
            var country = _countriesService.GetCountry(destCountry).Result;

            if (passport is not null && country is not null)
            {
                return new PassportCountryResponseDto {
                    Origin = passport.origin,
                    Destination = passport.destination,

                    Visa = new VisaDto
                    {
                        Code = (int)passport.requirement,
                        Description = passport.requirement.GetDescription() + (passport.requirement == Enums.VisaEnum.free_days_limit ? " days" : ""),
                        NumberOfDays = passport.numberOfDays
                    },

                    Country = new CountryDto
                    {
                        Name = country.Name.Common,
                        Region = country.Region,
                        Subregion = country.Subregion,
                        Flags = new FlagsDto
                        {
                            Png = country.Flags.Png,
                            Svg = country.Flags.Svg
                        },
                        Capitals = country.Capital,
                        Population = country.Population,
                        Area = country.Area,
                        Timezones = country.Timezones,
                        CarSide = country.Car?.Side,
                        PostalCodeFormat = country.PostalCode?.Format,
                        StartOfWeek = country.StartOfWeek
                    }
                };
            }

            return new();
        }
    }
}