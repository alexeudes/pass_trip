using System;
using pass_trip.Domain.Models;

namespace pass_trip.Business.Services.Interfaces
{
	public interface IPassportService
	{
        List<Passport> GetListPassportIndexesByCountryName(string name);
    }
}

