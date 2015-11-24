using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using BrewBuddy.Model;
using PortableRest;
using System.Collections.Generic;
using BrewBuddy.CustomExceptions;
using BrewBuddy.Shared;
using System.Linq;

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
			return new ObservableCollection<Brewery>( await SearchByName<Brewery> (name));
		}

		public async Task<ObservableCollection<Beer>> GetBeers (string name)
		{ 
			List<DbParameter> parameters = new List<DbParameter> () {
				new DbParameter () {
					key = "withBreweries",
					value = "Y"
				}
			};
			var beers = await SearchByName<Beer> (name, parameters);
			if (beers == null)
				throw new NoItemsFoundException ();
			
			return new ObservableCollection<Beer>(beers);
		}

		protected async Task<List<T>> SearchByName<T>(string name, List<DbParameter> parameters = null) where T : BaseDataModel
		{
			if (parameters == null)
				parameters = new List<DbParameter> ();

			parameters.Add (
				new DbParameter () { 
					key = "name", 
					value = string.Format ("*{0}*", name)
				});
			
			string resource = GetResource<T>();
			SetupClientAndRequest (resource, parameters);

			DataObject<T> result = await GetResult<T> ();
			if(result.NumberOfPages>1)
				await LoadOtherPages(result, parameters);
			
			return result.Data;
		}

		private async Task<DataObject<T>> GetResult<T> ()
		{
			try {
				return await _client.ExecuteAsync<DataObject<T>> (_request);
			}
			catch (Exception) 
			{
				throw new NoItemsFoundException ();
			}
		}

		private async Task LoadOtherPages<T>(DataObject<T> firstPage, List<DbParameter> parameters)
		{
			int currentPage = 2;
			string resource = GetResource<T> ();

			for(int i=currentPage; i<=firstPage.NumberOfPages && i<3 ; i++)
			{
				parameters.Add ( new DbParameter (){ key = "p", value = i.ToString () });
				SetupClientAndRequest (resource, parameters);
				DataObject<T> newPage = await GetResult<T> ();
				firstPage.Data.AddRange (newPage.Data);
			}
		}
		
		public async Task<List<Brewery>> GetBreweriesByBeer(string id)
		{
			string resource = string.Format (@"beer/{0}/breweries", id);
			SetupClientAndRequest (resource);

			try
			{
				var response = await _client.ExecuteAsync<DataObject<Brewery>>(_request);
				return response.Data;
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
			List<DbParameter> parameters = new List<DbParameter>() {
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
			List<DbParameter> parameters = new List<DbParameter>() {
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

		public async Task<List<T>> GetItemsById<T>(List<string> ids) where T : BaseDataModel
		{
			List<DbParameter> parameters = new List<DbParameter>() { 
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
		private void SetupClientAndRequest (string resource, List<DbParameter> parameters = null)
		{
			_client = new RestClient () { BaseUrl = @"http://api.brewerydb.com/v2/" };
			_request = new RestRequest ();
			_request.Resource = resource;
//			_request.AddQueryString ("key", "9a2a6901a06f34b07e304680c9799af5");
			_request.AddQueryString ("key", "8b99543cf345a3cdf23ea6fd2d1f895e");


			if (parameters!=null)
				AddParametersToRequest (parameters);
		}

		private void AddParametersToRequest (List<DbParameter> parameters)
		{
			foreach (DbParameter param in parameters)
				_request.AddQueryString (param.key, param.value);
		}

		private string GetResource<T>()
		{
			var type = typeof(T).ToString ();

			switch(type)
			{
			case Constants.Model.BEER:
				return "beers";
			case Constants.Model.BREWERY:
				return "breweries";
			default:
				throw new WrongArgumentException ();
			}
		}

		private class DataObject<T>
		{
			public int NumberOfPages { get; set; }
			public List<T> Data { get; set; }
		}

		protected struct DbParameter
		{
			public string key; 
			public string value;
		}
		#endregion
	}
}