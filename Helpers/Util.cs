using System;
namespace pass_trip.Helpers
{
	public class Util
	{
		public Util()
		{
		}

		public static HttpClient GetHttpInstance()
		{
			HttpClient client = new();
			client.DefaultRequestHeaders.Accept.Clear();

			return client;
		}
	}
}

