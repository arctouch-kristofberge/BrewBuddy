using System;

using Xamarin.Forms;
using BrewBuddy.View;
using BrewBuddy.Service;

namespace BrewBuddy
{
	public class App : Application
	{
		public App ()
		{
			Environment = DependencyService.Get<IEnvironment> ();
			Favorites = new FavoritesDb (Environment.DatabasePlatform, Environment.PersonalFolder);
			BreweryDb = new BreweryDb ();
			NavigationService = DependencyService.Get<INavigationService>();

			MainPage = new NavigationPage (new MainPage());
		}

		public IEnvironment Environment { get; private set; }
		public IFavoritesDb Favorites  { get; private set; }
		public IBreweryDb BreweryDb  { get; private set; }
		public INavigationService NavigationService { get; private set; }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

