using System;
using PropertyChanged;

namespace BrewBuddy.Model
{
	[ImplementPropertyChanged]
	public class BreweryDetails : BaseDataModel
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

