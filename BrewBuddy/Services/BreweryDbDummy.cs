using System;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using BrewBuddy.Model;
using System.Collections.Generic;
using BrewBuddy.Shared;

namespace BrewBuddy.Service
{
	public class BreweryDbDummy
	{
		#region IBreweryDb implementation
		public Task<ObservableCollection<Brewery>> GetBreweries (string name)
		{
			var taskSource = new TaskCompletionSource<ObservableCollection<Brewery>>();
			taskSource.SetResult(CreateBreweriesList (3));
			return taskSource.Task;
		}

		public Task<ObservableCollection<Beer>> GetBeers (string name)
		{
			var taskSource = new TaskCompletionSource<ObservableCollection<Beer>>();
			taskSource.SetResult(CreateBeersList (3));
			return taskSource.Task;
		}

		public Task<List<T>> GetItemsById<T> (List<string> ids) where T : BaseModel
		{
			var taskSource = new TaskCompletionSource<List<T>>();
			List<T> result = new List<T>();
			var type = typeof(T).ToString ();

			switch(type)
			{
			case Constants.Model.BEER:
				result = CreateBeersList (ids.Count) as List<T>;
				break;
			case Constants.Model.BREWERY:
				result = CreateBreweriesList (ids.Count) as List<T>;
				break;
			}

			taskSource.SetResult(result);
			return taskSource.Task;
		}

		public Task<BreweryDetails> GetBreweryDetails (string id)
		{
			var taskSource = new TaskCompletionSource<BreweryDetails>();
			taskSource.SetResult(CreateBreweryDetails (id));
			return taskSource.Task;
		}

		public Task<BeerDetails> GetBeerDetails (string id)
		{
			var taskSource = new TaskCompletionSource<BeerDetails>();
			taskSource.SetResult(CreateBeerDetails (id));
			return taskSource.Task;
		}

		public Task FillBreweries (List<Beer> beers)
		{
			return Task.FromResult (false);
		}

		public Task<List<Brewery>> GetBreweriesByBeer (string id)
		{
			
			var result = new List<Brewery>(CreateBreweriesList (1));
			return Task.FromResult (result);
		}
		#endregion

		#region Creators
		private ObservableCollection<Beer> CreateBeersList(int amount)
		{
			var beers = new ObservableCollection<Beer> ();

			for (int i = 0; i < amount; i++)
				beers.Add (CreateBeer (i));
			
			return beers;
		}

		private ObservableCollection<Brewery> CreateBreweriesList(int amount)
		{
			var breweries = new ObservableCollection<Brewery> ();

			for(int i=0; i<amount; i++)
				breweries.Add (CreateBrewery (i));

			return breweries;
		}

		private Brewery CreateBrewery(int index)
		{
			return new Brewery () {
				Id = index.ToString (),
				Name = "brewery " + index,
				IsFavorite = index % 2==0
			};
		}

		private Beer CreateBeer(int index)
		{
			return new Beer () {
				Id = index.ToString (),
				Name = "beer " + index,
				Breweries = new List<Brewery>(){ new Brewery (){Name = "Brewery of beer " + index}},
				IsFavorite = index % 2==0
			};
		}

		private BreweryDetails CreateBreweryDetails(string id)
		{
			return new BreweryDetails () {
				Id = id,
				Name = "name " + id,
				Description = "description " + id,
				Established = "1984",
				IsFavorite = true,
				IsOrganic = "false",
				MailingListUrl = "http://mail." + id + ".com",
				Website = "http://www." + id + ".com"
			};
		}

		private BeerDetails CreateBeerDetails(string id)
		{
			return new BeerDetails () {
				Id = id,
				Abv = "8",
				BeerVariation = "Brown beer",
				Description = "Description " + id,
				FoodPairings = "Meat",
				GlasswareId = "glass " + id,
				Ibu = "9",
				IsFavorite = true,
				IsOrganic = "false",
				OriginalGravity = "1.065",
				ServingTemperatureDisplay = "8",
				StatusDisplay = "Available",
				StyleId = "style" + id,
				Year = "1984"
			};
		}
		#endregion
	}
}

