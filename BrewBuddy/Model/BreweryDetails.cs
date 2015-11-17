using System;

namespace BrewBuddy.Model
{
	public class BreweryDetails : BaseModel
	{
		public string Name { get; set;}
		public string Description { get; set;}
		public string Website { get; set;}
		public string Established { get; set;}
		public string MailingListUrl { get; set;}
		public string IsOrganic { get; set;}
		public Images Images { get; set;}
	}
}

