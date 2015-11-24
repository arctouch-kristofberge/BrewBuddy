using System;
using PropertyChanged;

namespace BrewBuddy.Model
{
	[ImplementPropertyChanged]
	public class Temperature
	{
		public string Short { get; set; }
		public string Full { get; set; }
	}
}

