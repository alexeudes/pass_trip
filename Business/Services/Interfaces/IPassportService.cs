using System;
using pass_trip.Domain.Models;

namespace pass_trip.Business.Services.Interfaces
{
	public interface IPassportService
	{
        List<Passport> GetListPassportIndexesByCountryName(string name);
        bool InsertPassportIndexes(List<Passport> passportsIndex);
        List<Passport> GetListPassportFromDb();
        List<Passport> GetListPassportFromDbByName(string name);
    }
}

