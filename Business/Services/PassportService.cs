using System;
using System.IO;
using System.Reflection.PortableExecutable;
using Microsoft.VisualBasic.FileIO;
using pass_trip.Business.Services.Interfaces;
using pass_trip.Domain.Models;
using pass_trip.Enums;
using pass_trip.Infra.Interfaces;

namespace pass_trip.Business.Services
{
	public class PassportService : IPassportService
	{
		private readonly IPassportRepository _passportRepository;

		public PassportService(IPassportRepository passportRepository)
		{
			_passportRepository = passportRepository;
		}

		public List<Passport> GetListPassportIndexesByCountryName(string name)
		{
			var passIndexesPath = _passportRepository.GetPassportIndexFile();

            var filteredPassportIndex = StreamParser(passIndexesPath).FindAll(x => x.origin == name);

            return filteredPassportIndex;
		}

		private List<Passport> StreamParser(string filePath)
		{
            var passportList = new List<Passport>();

			using (TextFieldParser parser = new(filePath))
			{
				parser.SetDelimiters(",");
				parser.HasFieldsEnclosedInQuotes = true;

                parser.ReadLine(); // skip header

				while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

					if (fields != null && fields.Length == 3)
					{
                        var passportIndex = new Passport
                        {
                            ID = new Guid(),
                            origin = fields[0],
                            destination = fields[1],
                            requirement = GetVisaEnum(fields[2])
                        };

                        passportList.Add(passportIndex);
                    }
                }
            }

			return passportList;
		}

		private VisaEnum GetVisaEnum(string requirement)
		{
            return requirement switch
            {
                "visa free" => VisaEnum.free,
                "visa on arrival" => VisaEnum.arrival,
                "e-visa" => VisaEnum.e_visa,
                "visa required" => VisaEnum.required,
                "covid ban" => VisaEnum.covid,
                "no admission" => VisaEnum.not_allowed,
                "Hayya Entry Permit" => VisaEnum.fifa_wc_22,
                "-1" => VisaEnum.dest,
                _ => VisaEnum.free_days_limit,
            };
        }
	}
}

