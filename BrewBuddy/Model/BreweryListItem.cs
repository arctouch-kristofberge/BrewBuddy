using System;
using PropertyChanged;

namespace BrewBuddy.Model
{
	[ImplementPropertyChanged]
	public class BreweryListItem : BaseListItem
	{
		public string Name { get; set; }
	}
}

