using System;
using System.Collections.Generic;
using PropertyChanged;

namespace BrewBuddy.Model
{
	[ImplementPropertyChanged]
	public class BeerListItem : BaseListItem
	{
		public string Name { get; set; }
		public List<BreweryListItem> Breweries { get; set; }
		public string BreweryName { 
			get{
				return (Breweries != null && Breweries.Count > 0) ? Breweries [0].Name : string.Empty;
			} 
			private set{ } 
		}
	}
}

