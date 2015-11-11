using System;
using System.Collections.ObjectModel;
using BrewBuddy.Model;
using System.Threading.Tasks;

namespace BrewBuddy.Service
{
	public interface IBreweryDb
	{
		Task<ObservableCollection<Brewery>> GetBreweries (string name);
		Task<ObservableCollection<Beer>> GetBeers (string name);
		Task<BreweryDetails> GetBreweryDetails (string id);
		Task<BeerDetails> GetBeerDetails (string id);
	}
}

