using System;
using System.Collections.Generic;
using System.Text.Json;
using pass_trip.Business.Services.Interfaces;
using pass_trip.Domain.Models;
using pass_trip.Helpers;

namespace pass_trip.Business.Services
{
	public class CountriesService : ICountriesService
	{
        private readonly IConfiguration _configuration;

        public CountriesService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public async Task<List<Countries>> GetCountries()
		{
			var httpClient = Util.GetHttpInstance();
			var stream = await httpClient.GetStreamAsync($"{_configuration.GetValue<string>("COUNTRIES_API")}");

			var countries = await JsonSerializer.DeserializeAsync<List<Countries>>(stream);

            return countries ?? new();
		}
	}
}

