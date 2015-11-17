using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using BrewBuddy.Model;
using PortableRest;
using System.Collections.Generic;
using BrewBuddy.CustomExceptions;
using BrewBuddy.Shared;

[assembly: Xamarin.Forms.Dependency(typeof(BrewBuddy.Service.BreweryDb))]
namespace BrewBuddy.Service 
{
	public class BreweryDb : IBreweryDb
	{
		private RestClient _client;
		private RestRequest _request;

		#region ListItems
		public async Task<ObservableCollection<Brewery>> GetBreweries(string name)
		{
			DbParameter[] parameters = { 
				new DbParameter(){ key = "name", value = name }
			};

			SetupClientAndRequest ("breweries", parameters);

			try 
			{
				var response = await _client.ExecuteAsync<DataObject<Brewery>> (_request);
				return new ObservableCollection<Brewery>(response.Data);
			} 
			catch (ArgumentNullException) 
			{
				throw new NoItemsFoundException ();
			}
		}

		public async Task<ObservableCollection<Beer>> GetBeers (string name)
		{ 
			DbParameter[] parameters = { 
				new DbParameter(){ key = "name", value = name }
			};

			SetupClientAndRequest ("beers", parameters);

			try 
			{
				var response = await _client.ExecuteAsync<DataObject<Beer>> (_request);
				var beers = new ObservableCollection<Beer>(response.Data);
				var beersWithBreweries = await FillBreweries(beers);
				return beersWithBreweries;
			} 
			catch (ArgumentNullException) 
			{
				throw new NoItemsFoundException ();
			}
		}

		private async Task<ObservableCollection<Beer>> FillBreweries(ObservableCollection<Beer> beers)
		{
			foreach(Beer beer in beers)
			{
				var brewery = await GetBreweryByBeer (beer.Id);
				beer.BreweryName = brewery.Name;
			}

			return beers;
		}

		public async Task<Brewery> GetBreweryByBeer(string id)
		{
			string resource = string.Format (@"beer/{0}/breweries", id);
			SetupClientAndRequest (resource);

			try
			{
				var response = await _client.ExecuteAsync<DataObject<Brewery>>(_request);
				return response.Data[0];
			}
			catch (ArgumentNullException) 
			{
				throw new NoItemsFoundException ();
			}
		}
		#endregion

		#region Details
		public async Task<BreweryDetails> GetBreweryDetails (string id)
		{
			DbParameter[] parameters = { 
				new DbParameter(){ key = "ids", value = id }
			};

			SetupClientAndRequest ("breweries", parameters);

			try
			{
				var response = await _client.ExecuteAsync<DataObject<BreweryDetails>>(_request);
				return response.Data[0];
			}
			catch (ArgumentNullException)
			{
				throw new NoItemsFoundException ();
			}
		}

		public async Task<BeerDetails> GetBeerDetails(string id)
		{
			DbParameter[] parameters = { 
				new DbParameter(){ key = "ids", value = id }
			};

			SetupClientAndRequest ("beers", parameters);

			try
			{ 
				var response = await _client.ExecuteAsync<DataObject<BeerDetails>>(_request);
				return response.Data[0];
			}
			catch (ArgumentNullException) 
			{
				throw new NoItemsFoundException ();
			}
		}

		public async Task<List<T>> GetItemsById<T>(List<string> ids) where T : BaseModel
		{
			DbParameter[] parameters = { 
				new DbParameter(){ key = "ids", value = string.Join (",", ids) }
			};

			var type = typeof(T).ToString ();
			var resource = type == Constants.Model.BEER ? "beers" : "breweries";
			SetupClientAndRequest (resource, parameters);

			try
			{
				var result = await _client.ExecuteAsync<DataObject<T>> (_request);
				return result.Data;
			}
			catch (ArgumentNullException)
			{
				throw new NoItemsFoundException ();
			}
		}
		#endregion

		#region Private methods
		private void SetupClientAndRequest (string resource)
		{
			SetupClientAndRequest (resource, new DbParameter[]{});
		}

		private void SetupClientAndRequest (string resource, DbParameter[] parameters)
		{
			_client = new RestClient () { BaseUrl = @"http://api.brewerydb.com/v2/" };
			_request = new RestRequest ();
			_request.Resource = resource;
			_request.AddQueryString ("key", "9a2a6901a06f34b07e304680c9799af5");

			foreach (DbParameter param in parameters) 
				_request.AddQueryString (param.key, param.value);
		}

		private class DataObject<T>
		{
			public List<T> Data { get; set; }
		}

		private struct DbParameter
		{
			public string key; 
			public string value;
		}
		#endregion
	}
}