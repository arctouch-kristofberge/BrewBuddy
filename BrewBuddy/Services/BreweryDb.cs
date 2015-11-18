﻿using System;
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
			return new ObservableCollection<Brewery>( await SearchByName<Brewery> (name));
		}

		public async Task<ObservableCollection<Beer>> GetBeers (string name)
		{ 
			var beers = await SearchByName<Beer> (name);
			await FillBreweries (beers);
			return new ObservableCollection<Beer>(beers);
		}

		public async Task FillBreweries(IList<Beer> beers)
		{
			foreach(Beer beer in beers)
			{
				var breweries = await GetBreweriesByBeer (beer.Id);
				beer.BreweryName = breweries[0].Name;
			}
		}

		protected async Task<List<T>> SearchByName<T>(string name) where T : BaseModel
		{
			DbParameter[] parameters = { 
				new DbParameter(){ 
					key = "name", 
					value = string.Format ("*{0}*", name) }
			};
			
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
			catch (ArgumentNullException) {
				throw new NoItemsFoundException ();
			}
		}

		private async Task LoadOtherPages<T>(DataObject<T> firstPage, DbParameter[] parameters)
		{
			int currentPage = 2;
			Array.Resize<DbParameter> (ref parameters, parameters.Length + 1);
			string resource = GetResource<T> ();

			for(int i=currentPage; i<=firstPage.NumberOfPages && i<3 ; i++)
			{
				parameters [parameters.Length - 1] = new DbParameter (){ key = "p", value = i.ToString () };
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
//			_request.AddQueryString ("key", "9a2a6901a06f34b07e304680c9799af5");
			_request.AddQueryString ("key", "8b99543cf345a3cdf23ea6fd2d1f895e");

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

		private struct DbParameter
		{
			public string key; 
			public string value;
		}
		#endregion
	}
}