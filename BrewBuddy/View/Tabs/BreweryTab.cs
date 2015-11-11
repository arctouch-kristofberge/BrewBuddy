using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BrewBuddy.ViewModel;
using BrewBuddy.Model;
using BrewBuddy.Service;
using BrewBuddy.Shared;

namespace BrewBuddy.View
{
	public partial class BreweryTab : ContentPage
	{
		public BreweryTab ()
		{
			InitializeComponent ();

			BindingContext = new Factory ().GetListTabViewModel<Brewery>();
		}

		void SearchClicked(object sender, EventArgs e)
		{
			var searchParameter = ((SearchBar)Searchbar).Text;
			((ListTabViewModel<Brewery>)BindingContext).SearchClicked (searchParameter);
		}

		void ItemTapped(object sender, ItemTappedEventArgs e)
		{
			((ListTabViewModel<Brewery>)BindingContext).ItemTapped (e.Item as Brewery);
		}
	}
}

