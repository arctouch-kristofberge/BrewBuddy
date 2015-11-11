using System;
using BrewBuddy.Service;
using Xamarin.Forms;
using PropertyChanged;

namespace BrewBuddy.ViewModel
{
	[ImplementPropertyChanged]
	public abstract class BaseViewModel
	{
		public INavigationService NavigationService { get; set; }

		public string Title { get; set; }

		public BaseViewModel ()
		{
			NavigationService = DependencyService.Get<INavigationService>();
		}
	}
}

