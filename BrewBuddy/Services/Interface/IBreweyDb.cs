using System;
using System.Collections.ObjectModel;
using BrewBuddy.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BrewBuddy.Service
{
	public interface IBreweryDb
	{
		Task<ObservableCollection<Brewery>> GetBreweries (string name);
		Task<ObservableCollection<Beer>> GetBeers (string name);
		Task<List<T>> GetItemsById<T> (List<string> ids) where T : BaseModel;
//		Task<List<Beer>> GetItemsById (List<string> ids);
		Task<BreweryDetails> GetBreweryDetails (string id);
		Task<BeerDetails> GetBeerDetails (string id);
		Task<Brewery> GetBreweryByBeer (string id);
	}
}

