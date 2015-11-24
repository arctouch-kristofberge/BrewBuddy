using System;
using PropertyChanged;

namespace BrewBuddy.Model
{
	[ImplementPropertyChanged]
	public class Glass : BaseModel
	{
		public string Name { get; set; }
	}
}

