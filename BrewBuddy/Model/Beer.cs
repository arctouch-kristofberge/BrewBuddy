using System;
using System.Collections.Generic;
using PropertyChanged;

namespace BrewBuddy.Model
{
	[ImplementPropertyChanged]
	public class Beer : BaseDataModel, IListItem
	{
		public string Name { get; set; }
		public List<Brewery> Breweries { get; set; }
		public string BreweryName { 
			get{
				return (Breweries != null && Breweries.Count > 0) ? Breweries [0].Name : string.Empty;
			} 
			private set{ } 
		}
	}
}

