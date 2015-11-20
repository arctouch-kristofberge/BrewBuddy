using System;
using PropertyChanged;

namespace BrewBuddy.Model
{
	[ImplementPropertyChanged]
	public class Brewery : BaseModel, IListItem
	{
		public string Name { get; set; }
	}
}

