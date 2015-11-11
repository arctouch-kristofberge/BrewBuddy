using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BrewBuddy.Model;
using BrewBuddy.ViewModel;

namespace BrewBuddy.View
{
	public partial class BeerDetailsPage : ContentPage
	{
		public BeerDetailsPage (Beer beer)
		{
			InitializeComponent ();

			BindingContext = new BeerDetailsViewModel (beer);
		}
	}
}

