using System;
using PropertyChanged;

namespace BrewBuddy.Model
{
	[ImplementPropertyChanged]
	public class Brewery : BaseDataModel, IListItem
	{
		public string Name { get; set; }
	}
}

