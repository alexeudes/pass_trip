using pass_trip.DTO;

namespace pass_trip.Business.Services.Interfaces
{
    public interface IVisaRequirements
    {
        Task<PassportCountryResponseDto> GetPassportCountryResponse(string originCountry, string destCountry);
    }
}