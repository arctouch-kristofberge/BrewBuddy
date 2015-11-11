using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using BrewBuddy.Model;
using PortableRest;
using System.Collections.Generic;
using BrewBuddy.Exception;

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
			string[][] parameters = { new string[]{ "name", name } };
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
			string[][] parameters = { new string[]{ "name", name } };
			SetupClientAndRequest ("beers", parameters);

			try 
			{
				var response = await _client.ExecuteAsync<DataObject<Beer>> (_request);
				return new ObservableCollection<Beer>(response.Data);
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
			string[][] parameters = { new string[] { "ids", id } };
			SetupClientAndRequest ("breweries", parameters);

			try
			{
				var response = _client.ExecuteAsync<DataObject<BreweryDetails>>(_request).Result;
				return response.Data[0];
			}
			catch (ArgumentNullException)
			{
				throw new NoItemsFoundException ();
			}
		}

		public async Task<BeerDetails> GetBeerDetails(string id)
		{
			string[][] parameters = { new string[] { "ids", id } };
			SetupClientAndRequest ("beers", parameters);

			try
			{
				var response = _client.ExecuteAsync<DataObject<BeerDetails>>(_request).Result;
				return response.Data[0];
			}
			catch (ArgumentNullException) 
			{
				throw new NoItemsFoundException ();
			}
		}
		#endregion

		#region Private methods
		private void SetupClientAndRequest (string resource, string[][] parameters)
		{
			_client = new RestClient () { BaseUrl = @"http://api.brewerydb.com/v2/" };
			_request = new RestRequest ();
			_request.Resource = resource;
			_request.AddQueryString ("key", "9a2a6901a06f34b07e304680c9799af5");

			foreach (string[] param in parameters) 
				_request.AddQueryString (param[0], param[1]);
		}

		private class DataObject<T>
		{
			public List<T> Data { get; set; }
		}
		#endregion
	}
}