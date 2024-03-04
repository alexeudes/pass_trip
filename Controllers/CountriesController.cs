using Microsoft.AspNetCore.Mvc;
using pass_trip.Business.Services.Interfaces;
using pass_trip.Domain.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pass_trip.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesService _countriesService;

        public CountriesController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        [HttpGet(Name = "GetCountries")]
        public Task<List<Countries>> GetCountries()
        {
            return _countriesService.GetCountries();
        }
    }
}

