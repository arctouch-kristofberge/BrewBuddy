﻿using System;
using BrewBuddy.Shared;
using BrewBuddy.Model;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyChanged;
using System.Linq;

namespace BrewBuddy.ViewModel
{
	[ImplementPropertyChanged]
	public class FavoritesViewModel : BaseDataViewModel
	{
		#region Properties
		public ObservableCollection<BeerListItem> Beers { get; set; }
		public ObservableCollection<BreweryListItem> Breweries { get; set; }
		public string BeersTitle { get; set; }
		public string BreweriesTitle { get; set; }
		#endregion

		public FavoritesViewModel ()
		{
			Title = Constants.Text.FAVORITES_TAB_TITLE;
			BeersTitle = Constants.Text.FAVORITE_BEERS_TITLE;
			BreweriesTitle = Constants.Text.FAVORITE_BREWERIES_TITLE;
		}

		#region Init lists
		public async void InitializeListsAsync()
		{
			SetDataLoading (true);

			Beers = await GetFavoriteBeers ();
			Breweries = await GetFavoriteBreweries ();

			SetDataLoading (false);
		}

		protected async Task<ObservableCollection<BeerListItem>> GetFavoriteBeers ()
		{
			var favoriteBeers = await GetFavoritesAsync<BeerListItem> ();
			favoriteBeers.SetIsFavorite (true);
			favoriteBeers.SetIndexes ();

			return favoriteBeers;
		}
		
		protected async Task<ObservableCollection<BreweryListItem>> GetFavoriteBreweries()
		{
			var favoriteBreweries = await GetFavoritesAsync<BreweryListItem> ();
			favoriteBreweries.SetIsFavorite (true);
			favoriteBreweries.SetIndexes ();
			
			return favoriteBreweries;
		}

		protected async Task<ObservableCollection<T>> GetFavoritesAsync<T>() where T : BaseListItem
		{
			List<string> favoriteIds = await FavoritesDb.GetAllIds<T> ();
			return await GetFavoriteModels<T> (favoriteIds);
		}

		protected async Task<ObservableCollection<T>> GetFavoriteModels<T>(List<string> ids) where T : BaseListItem
		{
			var models = new List<T> ();
			int batchSize = 10;
			for(int i=0; i<ids.Count; i+=batchSize)
			{
				int range = Math.Min (batchSize, ids.Count - i); // This prevents IndexOutOfBoundsException
				List<string> batch = ids.GetRange (i, range);
				models.AddRange ( await BreweryDb.GetListItemsById<T> (batch));
			}
			return new ObservableCollection<T> (models);
		}
		#endregion

		public void FavoriteToggled<T>(T item, bool isFavorite) where T : BaseListItem
		{
			if (isFavorite)
				FavoritesDb.AddAsync (item);
			else
				FavoritesDb.RemoveAsync (item);
		}
	}
}

