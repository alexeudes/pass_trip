using Microsoft.AspNetCore.Mvc;
using pass_trip.Business.Services.Interfaces;
using pass_trip.DTO;

namespace pass_trip.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisaRequirementsController : ControllerBase
    {
        private readonly IVisaRequirements _visaRequirements;

        public VisaRequirementsController(IVisaRequirements visaRequirements)
        {
            _visaRequirements = visaRequirements;
        }

        [HttpGet(Name = "GetDestinationCountryInfo/{countryName}")]
        public async Task<ActionResult<PassportCountryResponseDto>> GetDestinationCountryInfo([FromQuery] string originCountry, string destCountry)
        {
            return await _visaRequirements.GetPassportCountryResponse(originCountry, destCountry);
        }
    }
}

