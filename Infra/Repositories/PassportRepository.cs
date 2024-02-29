using System;
using pass_trip.Infra.Interfaces;

namespace pass_trip.Infra.Repositories
{
	public class PassportRepository : IPassportRepository
    {
		public PassportRepository()
		{}

		public string GetPassportIndexFile()
		{
			return "Infra/Data/pass_index.csv";
		}
	}
}

