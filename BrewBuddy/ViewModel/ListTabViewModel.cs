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
	public class ListTabViewModel<T> : BaseDataViewModel where T : BaseModel, IFavorite
	{
		#region Properties
		public ObservableCollection<T> Items { get; set; }
		public string ListHeader { get; set; }
		#endregion

		private Func<string, Task<ObservableCollection<T>>> GetItemsFunction;

		public ListTabViewModel (Func<string, Task<ObservableCollection<T>>> getItemsFunction, string title)
		{
			Title = title;

			GetItemsFunction = getItemsFunction;
		}

		public async void RefreshFavorites()
		{
			if(Items!=null && Items.Count > 0)
			{
				SetDataLoading (true);
				await SetFavorites (Items);
				ForceItemsPropertyChanged ();
				SetDataLoading (false);
			}
		}

		private async Task SetFavorites (ObservableCollection<T> items)
		{
			foreach (T item in items)
				item.IsFavorite = await FavoritesDb.IsFavorite (item);
		}

		private void ForceItemsPropertyChanged()
		{
			var items = Items;
			Items = new ObservableCollection<T>();
			foreach(var item in items)
				Items.Add (item);
		}
		
		public void SearchClicked(string parameter)
		{
			if(!IsLoading)
				FillItems (parameter);
		}

		private async void FillItems(string name)
		{
			SetDataLoading (true);

			Items = new ObservableCollection<T> ();
			try 
			{
				ObservableCollection<T> items = await GetItemsFunction(name);

				await SetFavorites (items);
				Items = items;
				ListHeader = "Search results";
			} 
			catch (NoItemsFoundException)
			{
				Items.Clear ();
				ListHeader = Constants.Text.NO_ITEMS_FOUND;
			}

			SetDataLoading (false);
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