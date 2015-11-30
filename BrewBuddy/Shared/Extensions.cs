using System;
using System.Collections.Generic;
using System.Linq;
using BrewBuddy.Model;
using BrewBuddy.ViewModel;
using BrewBuddy.CustomExceptions;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BrewBuddy.Shared
{
	public static class Extensions
	{
		#region IList<T>
		public static void SetIsFavorite<T>(this IList<T> list, bool isFavorite) where T : IFavorite
		{
			list.Select (x => { x.IsFavorite = isFavorite; return x; }).ToList ();
		}

		public static void SetIndexes<T>(this IList<T> list) where T : IIndexed
		{
			list.Select (x => { x.Index = list.IndexOf (x); return x; }).ToList ();
		}
		
		public static async Task SetFavorites<T> (this IList<T> items) where T : BaseListItem
		{
			var FavoritesDb = ((App)Application.Current).FavoritesDb;
			var favoritesIds = await FavoritesDb.GetAllIds<T> ();
			items.Select (x => {
				x.IsFavorite = favoritesIds.Contains (x.Id);
				return x;
			}).ToList ();
		}
		#endregion

		#region ListTabViewModel<BreweryListItem>
		public static void SearchByLocation(this ListTabViewModel<BreweryListItem> viewModel)
		{
			viewModel.SetHeader ("Getting current location");
			if (!viewModel.IsLoading) 
			{
				viewModel.SetDataLoading (true);
				try
				{
					viewModel.LocationManager.StartLocationManager (viewModel.FillItemsByLocation);
				}
				catch (LocationServiceNotRunningException)
				{
					viewModel.ShowNoItemsFound ();
				}
				finally
				{
					viewModel.SetHeader (string.Empty);
				}
			}
		}

		private static async void FillItemsByLocation(this ListTabViewModel<BreweryListItem> viewModel, MyLocation location)
		{
			viewModel.SetHeader ("Searching for breweries near you.");
			try 
			{
				viewModel.Items = new ObservableCollection<BreweryListItem> (await viewModel.BreweryDb.GetBreweriesByLocation (location.Latitude, location.Longtitude, 10) as List<BreweryListItem>);
				await viewModel.Items.SetFavorites ();
				viewModel.Items.SetIndexes ();
			} 
			catch (NoItemsFoundException) 
			{
				viewModel.ShowNoItemsFound ();
			}
			finally
			{
				viewModel.SetHeader (string.Empty);
				viewModel.SetDataLoading (false);
			}

		}
		#endregion
	}
}

