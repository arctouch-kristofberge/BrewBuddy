﻿using System;
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

			BindingContext = new Factory ().GetListTabViewModel<Brewery>();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			((ListTabViewModel<Brewery>)BindingContext).RefreshFavorites();
		}

		private void SearchClicked(object sender, EventArgs e)
		{
			var searchParameter = ((SearchBar)Searchbar).Text;
			((ListTabViewModel<Brewery>)BindingContext).SearchClicked (searchParameter);
		}

		private void ItemTapped(object sender, ItemTappedEventArgs e)
		{
			((ListTabViewModel<Brewery>)BindingContext).ItemTapped (e.Item as Brewery);
		}

		private void FavoriteToggled(object sender, FavoriteToggledEventArgs e)
		{
			((ListTabViewModel<Brewery>)BindingContext).FavoriteToggled (e.Item as Brewery, e.IsFavorite);
		}
	}
}