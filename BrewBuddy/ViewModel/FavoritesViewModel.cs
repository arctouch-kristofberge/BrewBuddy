using System;
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
		public ObservableCollection<Beer> Beers { get; set; }
		public ObservableCollection<Brewery> Breweries { get; set; }

		public FavoritesViewModel ()
		{
			Title = Constants.Text.FAVORITES_TAB_TITLE;
		}

		public async void InitializeListsAsync()
		{
			SetDataLoading (true);
			Beers = await GetFavoritesAsync<Beer> ();
			Beers.Select (x => { x.IsFavorite = true; return x; }).ToList ();

			Breweries = await GetFavoritesAsync<Brewery> ();
			Breweries.Select (x => { x.IsFavorite = true; return x; }).ToList ();
			SetDataLoading (false);
		}

		protected async Task<ObservableCollection<T>> GetFavoritesAsync<T>() where T : BaseModel
		{
			List<string> favoriteIds = await FavoritesDb.GetAllIds<T> ();
			return await GetFavoriteModels<T> (favoriteIds);
		}

		protected async Task<ObservableCollection<T>> GetFavoriteModels<T>(List<string> ids) where T : BaseModel
		{
			var models = new List<T> ();
			int batchSize = 10;
			for(int i=0; i<ids.Count; i+=batchSize)
			{
				int range = Math.Min (batchSize, ids.Count - i); // This prevents IndexOutOfBoundsException
				List<string> batch = ids.GetRange (i, range);
				models.AddRange ( await BreweryDb.GetItemsById<T> (batch));
			}
			return new ObservableCollection<T> (models);
		}
	}
}

