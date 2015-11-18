using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BrewBuddy.Shared;
using System.Collections.ObjectModel;
using BrewBuddy.Model;
using BrewBuddy.ViewModel;
using BrewBuddy.Event;

namespace BrewBuddy.View
{
	public partial class FavoritesTab : CarouselPage
	{
		public FavoritesTab ()
		{
			InitializeComponent ();

			BindingContext = new FavoritesViewModel ();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			((FavoritesViewModel)BindingContext).InitializeListsAsync ();
		}

		private void OnFavoriteBeerToggled(object sender, FavoriteToggledEventArgs e)
		{
			((FavoritesViewModel)BindingContext).FavoriteToggled (e.Item as Beer, e.IsFavorite);
		}

		private void OnFavoriteBreweryToggled(object sender, FavoriteToggledEventArgs e)
		{
			((FavoritesViewModel)BindingContext).FavoriteToggled (e.Item as Brewery, e.IsFavorite);
		}
	}
}