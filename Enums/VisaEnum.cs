using System;
using System.ComponentModel;

namespace pass_trip.Enums
{
	public enum VisaEnum
	{
        [Description("Visa Required")]
        required = 1,
        [Description("Visa Free")]
        free,
        [Description("7-360")]
        free_days_limit,
        [Description("Visa on Arrival")]
        arrival,
        [Description("E-visa")]
        e_visa,
        [Description("Covid ban")]
        covid,
        [Description("No Admission")]
        not_allowed,
        [Description("Hayya Entry Permit")]
        fifa_wc_22,
        [Description("Passport = destination")]
        dest = -1,
    }
}

