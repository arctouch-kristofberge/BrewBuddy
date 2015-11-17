using System;
using BrewBuddy.Service;
using Xamarin.Forms;
using PropertyChanged;

namespace BrewBuddy.ViewModel
{
	[ImplementPropertyChanged]
	public abstract class BaseViewModel
	{
		public INavigationService NavigationService 
		{ 
			get
			{
				return ((App)Application.Current).NavigationService;
			}
		}

		public IFavoritesDb FavoritesDb
		{
			get
			{
				return ((App)Application.Current).Favorites;
			}
		}

		public string Title { get; set; }
	}
}

