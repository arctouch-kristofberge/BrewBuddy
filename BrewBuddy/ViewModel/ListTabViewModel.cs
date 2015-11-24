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

namespace BrewBuddy.ViewModel
{
	[ImplementPropertyChanged]
	public class ListTabViewModel<T> : BaseDataViewModel where T : BaseDataModel, IFavorite
	{
		#region Properties
		public ObservableCollection<T> Items { get; set; }
		public string ListHeader { get; set; }
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
		
		public async void SearchClicked(string parameter)
		{
			if(!IsLoading)
			{
				SetDataLoading (true);
				await FillItems (parameter);
				ListHeader = string.Format ( "Search results ({0})", Items.Count);
				SetDataLoading (false);
			}
		}

		private async Task FillItems(string name)
		{
			try 
			{
				Items = new ObservableCollection<T>( await GetItemsFunction(name));
				await RefreshFavorites ();
			} 
			catch (NoItemsFoundException)
			{
				Items.Clear ();
				ListHeader = Constants.Text.NO_ITEMS_FOUND;
			}


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