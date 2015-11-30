using System;
using Android.Locations;
using Android.App;
using System.Collections.Generic;
using System.Linq;

using BrewBuddy.CustomExceptions;
using BrewBuddy.Model;
using Xamarin.Forms;
using Android.Content;

[assembly: Dependency(typeof(BrewBuddy.Droid.LocationManagerAndroid))]
namespace BrewBuddy.Droid
{
	public class LocationManagerAndroid : Activity, ILocationManager, ILocationListener
	{
		protected LocationManager manager;
		protected LocationProvider provider;

		private Action<MyLocation> _callBack;

		#region ILocationManager implementation

		public void StartLocationManager (Action<MyLocation> callBack)
		{
			manager = (LocationManager) Android.App.Application.Context.GetSystemService (Context.LocationService);

			_callBack = callBack;

			Criteria criteriaForLocationService = new Criteria { Accuracy = Accuracy.Coarse };

			IList<string> acceptableLocationProviders = manager.GetProviders(criteriaForLocationService, true);

			if (acceptableLocationProviders.Any())
				manager.RequestLocationUpdates (acceptableLocationProviders.First (), 0, 0, this);
			else
				throw new LocationServiceNotRunningException ();
		}
		#endregion


		#region ILocationListener implementation

		public void OnLocationChanged (Location location)
		{
			manager.RemoveUpdates (this);
			if(_callBack != null)
				_callBack( new MyLocation () { Latitude = location.Latitude, Longtitude = location.Longitude });
		}

		public void OnProviderDisabled (string provider) { }

		public void OnProviderEnabled (string provider) { }

		public void OnStatusChanged (string provider, Availability status, Android.OS.Bundle extras) { }

		#endregion
	}
}

