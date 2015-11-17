using System;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinIOS;


[assembly: Xamarin.Forms.Dependency(typeof(BrewBuddy.iOS.Environment))]
namespace BrewBuddy.iOS
{
	public class Environment : IEnvironment
	{
		public ISQLitePlatform DatabasePlatform
		{
			get { return new SQLitePlatformIOS(); }
		}

		public string PersonalFolder
		{
			get { return System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);}
		}
	}
}

