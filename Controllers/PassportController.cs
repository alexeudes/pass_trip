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

        // [HttpGet(Name = "GetListPassportIndexesByCountryName/{name}")]
        // public List<Passport> GetListPassportIndexesByCountryName([FromQuery] string name)
        // {
        //     return _passportService.GetListPassportIndexesByCountryName(name);
        // }

        [HttpPost]
        public IActionResult UpdateDbWithPassportIndex()
        {
            var _result = _passportService.UpdateDbWithPassportIndex();
            return Ok(new { success = _result });
        }

        [HttpGet(Name = "GetListOfOriginCountryPassport")]
        public IActionResult GetListOfOriginCountryPassport()
        {
            var _result = _passportService.GetListOfOriginCountryPassport();
            return Ok(new { originCountries = _result });
        }
    }
}

