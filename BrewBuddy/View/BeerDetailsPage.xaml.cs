using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BrewBuddy.Model;
using BrewBuddy.ViewModel;

namespace BrewBuddy.View
{
	public partial class BeerDetailsPage : ContentPage
	{
		public BeerDetailsPage (BeerListItem beer)
		{
			InitializeComponent ();

			BindingContext = new BeerDetailsViewModel (beer);
		}

		private void ServingViewTapped(object sender, EventArgs e)
		{
			string temperature = ((BeerDetailsViewModel)BindingContext).ServingTemperatureDisplay;

			if(!string.IsNullOrWhiteSpace (temperature))
				DisplayAlert ("Serving temperature", temperature, "Close");
		}
	}
}

