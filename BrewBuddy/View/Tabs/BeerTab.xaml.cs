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

			BindingContext = new Factory ().GetListTabViewModel<Beer>();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			((ListTabViewModel<Beer>)BindingContext).RefreshFavorites();
		}

		private void SearchClicked(object sender, EventArgs e)
		{
			var searchParameter = ((SearchBar)Searchbar).Text;
			((ListTabViewModel<Beer>)BindingContext).SearchClicked (searchParameter);
		}

		private void ItemTapped(object sender, ItemTappedEventArgs e)
		{
			((ListView)sender).SelectedItem = null;
			((ListTabViewModel<Beer>)BindingContext).ItemTapped (e.Item as Beer);
		}

		private void FavoriteToggled(object sender, FavoriteToggledEventArgs e)
		{
			((ListTabViewModel<Beer>)BindingContext).FavoriteToggled (e.Item as Beer, e.IsFavorite);
		}
	}
}