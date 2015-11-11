using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BrewBuddy.ViewModel;
using BrewBuddy.Shared;
using BrewBuddy.Model;

namespace BrewBuddy.View
{
	public partial class MainPage : TabbedPage
	{
		public MainPage ()
		{
			InitializeComponent ();

			Title = Constants.Text.MAIN_PAGE_TITLE;

			Children.Add (new BeerTab ());
			Children.Add (new BreweryTab ());
		}
	}
}

