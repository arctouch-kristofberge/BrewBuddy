using System;
using PropertyChanged;

namespace BrewBuddy.Model
{
	[ImplementPropertyChanged]
	public class Available: BaseModel
	{
		public string Description { get; set; }
	}
}

