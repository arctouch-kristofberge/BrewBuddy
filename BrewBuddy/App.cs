using System;

using Xamarin.Forms;
using BrewBuddy.View;
using BrewBuddy.Service;
using BrewBuddy.Design;

namespace BrewBuddy
{
	public class App : Application
	{
		public App ()
		{
			Environment = DependencyService.Get<IEnvironment> ();
			FavoritesDb = new FavoritesDb (Environment.DatabasePlatform, Environment.PersonalFolder);
			BreweryDb = new BreweryDb ();
//			BreweryDb = new BreweryDbDummy ();
			NavigationService = DependencyService.Get<INavigationService>();
			LocationManager = DependencyService.Get<ILocationManager> ();
			MainPage = new NavigationPage (new MainPage());
		}

		public IEnvironment Environment { get; private set; }
		public IFavoritesDb FavoritesDb  { get; private set; }
		public IBreweryDb BreweryDb  { get; private set; }
		public INavigationService NavigationService { get; private set; }
		public ILocationManager LocationManager { get; private set; }

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

 