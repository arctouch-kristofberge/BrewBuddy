using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BrewBuddy.Shared;
using System.Collections.ObjectModel;
using BrewBuddy.Model;
using BrewBuddy.ViewModel;

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
	}
}