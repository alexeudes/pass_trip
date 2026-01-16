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

		public async Task<Country> GetCountry(string countryName)
		{
			var httpClient = Util.GetHttpInstance();
			var response = await httpClient.GetAsync($"{_configuration.GetValue<string>("COUNTRIES_API")}name/{countryName}");

			response.EnsureSuccessStatusCode();

			await using var stream = await response.Content.ReadAsStreamAsync();

			var countries = await JsonSerializer.DeserializeAsync<List<Country>>(
				stream,
				new JsonSerializerOptions
				{
                    PropertyNameCaseInsensitive = true
				});

			return countries?.FirstOrDefault() ?? new ();
		}
	}
}

