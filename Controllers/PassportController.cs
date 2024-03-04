using Microsoft.AspNetCore.Mvc;
using pass_trip.Business.Services.Interfaces;
using pass_trip.Domain.Models;

namespace pass_trip.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PassportController : ControllerBase
    {
        private readonly IPassportService _passportService;

        public PassportController(IPassportService passportService)
        {
            _passportService = passportService;
        }

        [HttpGet(Name = "GetListPassportIndexesByCountryName/{name}")]
        public List<Passport> GetListPassportIndexesByCountryName([FromQuery] string name)
        {
            return _passportService.GetListPassportIndexesByCountryName(name);
        }
    }
}

