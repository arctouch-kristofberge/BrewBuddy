using System;
using PropertyChanged;

namespace BrewBuddy.Model
{
	[ImplementPropertyChanged]
	public class Images
	{
		public string Icon { get; set; }
		public string Medium { get; set; }
		public string Large { get; set; }
	}
}

