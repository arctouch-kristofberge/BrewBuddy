using System;
using PropertyChanged;

namespace BrewBuddy.Model
{
	[ImplementPropertyChanged]
	public class Available: BaseDataModel
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}
}

