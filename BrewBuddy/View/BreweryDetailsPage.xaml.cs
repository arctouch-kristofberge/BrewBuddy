using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BrewBuddy.Model;
using BrewBuddy.ViewModel;

namespace BrewBuddy.View
{
	public partial class BreweryDetailsPage : ContentPage
	{
		public BreweryDetailsPage (BreweryListItem brewery)
		{
			InitializeComponent ();

			BindingContext = new BreweryDetailsViewModel (brewery);
		}
	}
}

