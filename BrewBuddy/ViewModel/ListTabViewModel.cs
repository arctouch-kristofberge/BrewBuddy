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
		public string Header { get; set; }
		public bool IsHeaderVisible { get; set; }
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
			SetHeader (string.Empty);
		}

		public async Task RefreshFavorites()
		{
			if(Items!=null && Items.Count > 0)
			{
				SetDataLoading (true);
				await Items.SetFavorites ();
				SetDataLoading (false);
			}
		}
		
		public async void SearchByName(string parameter)
		{
			if(!IsLoading)
			{
				SetDataLoading (true);
				await FillItemsByName (parameter);
				SetHeader (string.Format ( Constants.Text.HEADER_SEARCH_RESULTS, Items.Count));
				SetDataLoading (false);
			}
		}

		private async Task FillItemsByName(string name)
		{
			try 
			{
				Items = new ObservableCollection<T>( await GetItemsFunction(name));
				await RefreshFavorites ();
				Items.SetIndexes();
			} 
			catch (NoItemsFoundException)
			{
				ShowNoItemsFound ();
			}
		}

		public void ShowNoItemsFound ()
		{
			Items.Clear ();
			Header = Constants.Text.NO_ITEMS_FOUND;
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

		public void SetHeader(string text)
		{
			Header = text;
			IsHeaderVisible = !string.IsNullOrWhiteSpace (text);
		}
	}
}