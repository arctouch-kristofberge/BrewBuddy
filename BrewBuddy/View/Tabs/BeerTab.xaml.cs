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

		void SearchClicked(object sender, EventArgs e)
		{
			var searchParameter = ((SearchBar)Searchbar).Text;
			((ListTabViewModel<Beer>)BindingContext).SearchClicked (searchParameter);
		}

		void ItemTapped(object sender, ItemTappedEventArgs e)
		{
			((ListTabViewModel<Beer>)BindingContext).ItemTapped (e.Item as Beer);
		}

		void FavoriteToggled(object sender, FavoriteToggledEventArgs e)
		{
			((ListTabViewModel<Beer>)BindingContext).FavoriteToggled (e.Item as Beer, e.IsFavorite);
		}
	}
}