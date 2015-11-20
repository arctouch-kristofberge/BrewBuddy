using System;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;
using Android.Content.Res;

[assembly: Xamarin.Forms.Dependency(typeof(BrewBuddy.Droid.Environment))]
namespace BrewBuddy.Droid
{
	public class Environment : Java.Lang.Object, IEnvironment
	{
		public Environment ()
		{
		}

		#region IEnvironment implementation

		public string PersonalFolder {
			get {
				return System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);
			}
		}

		public ISQLitePlatform DatabasePlatform {
			get {
				return new SQLitePlatformAndroid ();
			}
		}

		public int ScreenWidth {
			get { Resources.DisplayMetrics.WidthPixels; }
		}

		public int ScreenHeight {
			get { Resources.DisplayMetrics.HeightPixels; }
		}
		#endregion
	}
}

