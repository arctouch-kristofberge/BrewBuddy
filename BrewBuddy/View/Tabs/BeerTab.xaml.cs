using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BrewBuddy.ViewModel;
using BrewBuddy.Shared;
using BrewBuddy.Model;
using BrewBuddy.View.Custom;
using BrewBuddy.Event;

namespace BrewBuddy.View
{
	public partial class BeerTab : ContentPage
	{
		public BeerTab ()
		{
			InitializeComponent ();

			BindingContext = new Factory ().GetListTabViewModel<BeerListItem>();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			((ListTabViewModel<BeerListItem>)BindingContext).RefreshFavorites();
		}

		private void SearchClicked(object sender, EventArgs e)
		{
			var searchParameter = ((SearchBar)Searchbar).Text;
			((ListTabViewModel<BeerListItem>)BindingContext).SearchClicked (searchParameter);
		}

		private void ItemTapped(object sender, ItemTappedEventArgs e)
		{
			((ListView)sender).SelectedItem = null;
			((ListTabViewModel<BeerListItem>)BindingContext).ItemTapped (e.Item as BeerListItem);
		}

		private void FavoriteToggled(object sender, FavoriteToggledEventArgs e)
		{
			((ListTabViewModel<BeerListItem>)BindingContext).FavoriteToggled (e.Item as BeerListItem, e.IsFavorite);
		}
	}
}