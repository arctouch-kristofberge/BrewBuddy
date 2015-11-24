using System;
using PropertyChanged;

namespace BrewBuddy.Model
{
	[ImplementPropertyChanged]
	public class Available: BaseModel
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}
}

