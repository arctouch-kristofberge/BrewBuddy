using System;
using System.Collections.ObjectModel;
using BrewBuddy.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BrewBuddy.Service
{
	public interface IBreweryDb
	{
		Task<ObservableCollection<BreweryListItem>> GetBreweries (string name);
		Task<ObservableCollection<BeerListItem>> GetBeers (string name);
		Task<List<T>> GetListItemsById<T> (List<string> ids) where T : BaseListItem;
		Task<List<BreweryListItem>> GetBreweriesByLocation (double lat, double lng, int radius);
		Task<BreweryDetails> GetBreweryDetails (string id);
		Task<BeerDetails> GetBeerDetails (string id);
		Task<List<BreweryListItem>> GetBreweriesByBeer (string id);
	}
}

