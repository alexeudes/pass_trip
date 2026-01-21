using Microsoft.OpenApi.Extensions;
using pass_trip.Business.Services.Interfaces;
using pass_trip.DTO;
using pass_trip.Helpers;

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
                        Description = passport.requirement.GetDisplayName(),
                        NumberOfDays = passport.numberOfDays
                    },

                    Country = new CountryDto
                    {
                        Name = country.Name.Common,
                        Region = country.Region,
                        Flags = new FlagsDto
                        {
                            Png = country.Flags.Png,
                            Svg = country.Flags.Svg
                        },
                        Capitals = country.Capital,
                        Population = country.Population,
                        Area = country.Area,
                        Timezones = country.Timezones
                    }
                };
            }

            return new();
        }
    }
}