using System;
using System.Collections.ObjectModel;
using BrewBuddy.View;
using BrewBuddy.Model;
using BrewBuddy.Shared;
using System.Threading.Tasks;
using BrewBuddy.CustomExceptions;

[assembly: Xamarin.Forms.Dependency(typeof(BrewBuddy.Service.NavigationService))]
namespace BrewBuddy.Service
{
	public class NavigationService : INavigationService
	{
		public NavigationService ()
		{

		}

		public async Task NavigateToDetails<T>(T item) where T : BaseModel
		{
			var type = typeof(T).ToString();
			switch (type) 
			{
			case Constants.Model.BREWERY:
				await App.Current.MainPage.Navigation.PushAsync (new BreweryDetailsPage (item as BreweryListItem));
				break;
			case Constants.Model.BEER:
				await App.Current.MainPage.Navigation.PushAsync (new BeerDetailsPage (item as BeerListItem));
				break;
			default:
				throw new WrongArgumentException ();
			}
		}
	}
}

