using System;
using pass_trip.Domain.Models;

namespace pass_trip.Business.Services.Interfaces
{
	public interface ICountriesService
	{
        Task<Countries> GetCountries();
    }
}

