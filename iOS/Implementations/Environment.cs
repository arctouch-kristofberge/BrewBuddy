using System;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinIOS;
using UIKit;


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

		public int ScreenWidth {
			get { return Convert.ToInt32 ( UIScreen.MainScreen.Bounds.Width); }
		}
		public int ScreenHeight {
			get { return Convert.ToInt32 ( UIScreen.MainScreen.Bounds.Height); }
		}

	}
}

