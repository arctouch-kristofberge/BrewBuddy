using System;
using Xamarin.Forms;
using BrewBuddy.Service;
using BrewBuddy.CustomExceptions;
using System.Collections.ObjectModel;
using BrewBuddy.Model;
using PropertyChanged;
using BrewBuddy.Shared;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.Generic;

namespace BrewBuddy.ViewModel
{
	[ImplementPropertyChanged]
	public class ListTabViewModel<T> : BaseDataViewModel where T : BaseListItem
	{
		#region Properties
		public ObservableCollection<T> Items { get; set; }
		public string ListHeader { get; set; }
		public string Message { get; set; }
		public bool IsMessageVisible { get; set; }
		#endregion

		#region Commands
		public ICommand ItemTappedCommand { get; private set; }
		#endregion

		private Func<string, Task<ObservableCollection<T>>> GetItemsFunction;

		public ListTabViewModel (Func<string, Task<ObservableCollection<T>>> getItemsFunction, string title)
		{
			Title = title;
			GetItemsFunction = getItemsFunction;

			Items = new ObservableCollection<T> ();
		}

		public async Task RefreshFavorites()
		{
			if(Items!=null && Items.Count > 0)
			{
				SetDataLoading (true);
				await SetFavorites (Items);
				SetDataLoading (false);
			}
		}

		private async Task SetFavorites (ObservableCollection<T> items)
		{
			foreach (T item in items)
				item.IsFavorite = await FavoritesDb.IsFavorite (item);
		}
		
		public async void SearchByName(string parameter)
		{
			if(!IsLoading)
			{
				SetDataLoading (true);
				await FillItems (parameter);
				ListHeader = string.Format ( "Search results ({0})", Items.Count);
				SetDataLoading (false);
			}
		}

		public void SearchByLocation()
		{
			if (!IsLoading) 
			{
				SetDataLoading (true);
				try
				{
					LocationManager.StartLocationManager (FillItemsByLocation);
				}
				catch (LocationServiceNotRunningException)
				{
					//Set message
				}
			}
		}

		private async void FillItemsByLocation(Location location)
		{
			Items = new ObservableCollection<T>( await BreweryDb.GetBreweriesByLocation (location.Latitude, location.Longtitude, 10) as List<T>);
			await SetFavorites (Items);
			Items.SetIndexes ();
			SetDataLoading (false);
		}

		private async Task FillItems(string name)
		{
			try 
			{
				Items = new ObservableCollection<T>( await GetItemsFunction(name));
				await RefreshFavorites ();
				SetIndexes();
			} 
			catch (NoItemsFoundException)
			{
				Items.Clear ();
				ListHeader = Constants.Text.NO_ITEMS_FOUND;
			}
		}

		private void SetIndexes()
		{
			for(int i=0; i<Items.Count; i++)
				Items [i].Index = i;
		}

		public async void ItemTapped(T item)
		{
			await NavigationService.NavigateToDetails(item);
		}

		public void FavoriteToggled(T item, bool isFav)
		{
			if (isFav)
				FavoritesDb.AddAsync (item);
			else
				FavoritesDb.RemoveAsync (item);
		}
	}
}