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
		Task<List<T>> GetItemsById<T> (List<string> ids) where T : BaseModel;
		Task<BreweryDetails> GetBreweryDetails (string id);
		Task<BeerDetails> GetBeerDetails (string id);
		Task<List<BreweryListItem>> GetBreweriesByBeer (string id);
	}
}

