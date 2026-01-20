using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic.FileIO;
using pass_trip.Business.Services.Interfaces;
using pass_trip.Domain.Models;
using pass_trip.Enums;
using pass_trip.Helpers;
using pass_trip.Infra.Interfaces;

namespace pass_trip.Business.Services
{
    public class PassportService : IPassportService
	{
        private readonly DataContext _context;
        private readonly IPassportRepository _passportRepository;

		public PassportService(IPassportRepository passportRepository, DataContext context)
		{
            _context = context;
            _passportRepository = passportRepository;
		}

        public bool UpdateDbWithPassportIndex()
        {
            if (GetFirstCheckExists())
                throw new SqliteException("It already has data", 1);

            var passIndexesPath = _passportRepository.GetPassportIndexFile();

            var filteredPassportIndex = StreamParser(passIndexesPath);

            return InsertPassportIndexes(filteredPassportIndex);
        }

		public List<Passport> GetListPassportIndexesByCountryName(string name)
		{
            return GetFirstCheckExists() ? GetListPassportFromDbByName(name) : [];
		}

        public Passport GetPassportInfoByOriginAndDestCountries(string originCountry, string destCountry)
        {
            return GetFirstCheckExists() ? 
             _context.Passports.Where(p => p.origin == originCountry && p.destination == destCountry).First()
             : new();
        }

		private List<Passport> StreamParser(string filePath)
		{
            var passportList = new List<Passport>();

			using (TextFieldParser parser = new(filePath))
			{
				parser.SetDelimiters(",");
				parser.HasFieldsEnclosedInQuotes = true;
                parser.ReadLine();

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
                            numberOfDays = GetVisaNumberOfDays(fields[2].ToString()),
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

        private string GetVisaNumberOfDays(string visaValue)
        {
            var typesOfVisa = new string[]
            {
                "visa free",
                "visa on arrival",
                "e-visa",
                "eta",
                "visa required",
                "covid ban",
                "no admission",
                "Hayya Entry Permit",
                "-1",
            };

            var normalizedValue = visaValue.Trim().ToLowerInvariant();

            if (typesOfVisa.Any(t => normalizedValue.Contains(t))) return string.Empty;

            return visaValue;
        }

        public List<Passport> GetListPassportFromDb()
        {
            return _context.Passports.ToList();
        }

        public List<Passport> GetListPassportFromDbByName(string name)
        {
            return _context.Passports.Where(p => p.origin == name).ToList();
        }

        private bool GetFirstCheckExists()
        {
             return _context.Passports.Any();
        }

        public bool InsertPassportIndexes(List<Passport> passportsIndex)
        {   
            _context.Passports.AddRange(passportsIndex);
            return _context.SaveChanges() > 0;
        }
    }
}

