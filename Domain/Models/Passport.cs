using System;
using pass_trip.Enums;

namespace pass_trip.Domain.Models
{
	public class Passport
	{
		public Passport()
		{ }

		public Guid ID { get; set; }
		public string origin { get; set; }
		public string destination { get; set; }
		public string numberOfDays { get; set; } = string.Empty;
		public VisaEnum requirement { get; set; }
	}
}