using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BrewBuddy.ViewModel;
using BrewBuddy.Model;
using BrewBuddy.Service;
using BrewBuddy.Shared;
using BrewBuddy.View.Custom;
using BrewBuddy.Event;

namespace BrewBuddy.View
{
	public partial class BreweryTab : ContentPage
	{
		public BreweryTab ()
		{
			InitializeComponent ();

			BindingContext = new Factory ().GetListTabViewModel<BreweryListItem>();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			((ListTabViewModel<BreweryListItem>)BindingContext).RefreshFavorites();
		}

		private void SearchClicked(object sender, EventArgs e)
		{
			var searchParameter = ((SearchBar)Searchbar).Text;
			((ListTabViewModel<BreweryListItem>)BindingContext).SearchClicked (searchParameter);
		}

		private void ItemTapped(object sender, ItemTappedEventArgs e)
		{
			((ListTabViewModel<BreweryListItem>)BindingContext).ItemTapped (e.Item as BreweryListItem);
		}

		private void FavoriteToggled(object sender, FavoriteToggledEventArgs e)
		{
			((ListTabViewModel<BreweryListItem>)BindingContext).FavoriteToggled (e.Item as BreweryListItem, e.IsFavorite);
		}
	}
}