using System;
using CoreLocation;
using UIKit;
using BrewBuddy.Model;
using BrewBuddy;
using BrewBuddy.CustomExceptions;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(BrewBuddy.iOS.LocationManager))]
namespace BrewBuddy.iOS
{
	public class LocationManager : ILocationManager
	{
		protected CLLocationManager manager;
		protected Action<MyLocation> CallBack;

		public LocationManager ()
		{
			this.manager = new CLLocationManager();

			if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0))
			{
				manager.RequestAlwaysAuthorization ();
			}
		}

		#region ILocation implementation

		public void StartLocationManager (Action<MyLocation> callBack)
		{
			CallBack = callBack;
			if (CLLocationManager.LocationServicesEnabled) {
				manager.DesiredAccuracy = 100;
				manager.LocationsUpdated += LocationUpdated;
				manager.UpdatedLocation += Manager_UpdatedLocation;
				manager.RequestLocation ();
			} else {
				throw new LocationServiceNotRunningException ();
			}
		}

		private void Manager_UpdatedLocation (object sender, CLLocationUpdatedEventArgs e)
		{
			manager.UpdatedLocation -= Manager_UpdatedLocation;
				manager.StopUpdatingLocation ();
				if(CallBack!=null)
				{
					double lat = e.NewLocation.Coordinate.Latitude;
					double lng = e.NewLocation.Coordinate.Longitude;
					var loc = new MyLocation (){Latitude = lat, Longtitude = lng};
					CallBack(loc);
				}
		
		}

		private void LocationUpdated(object sender, CLLocationsUpdatedEventArgs e)
		{
			manager.LocationsUpdated -= LocationUpdated;
			manager.StopUpdatingLocation ();
			if(CallBack!=null)
			{
				double lat = e.Locations[e.Locations.Length-1].Coordinate.Latitude;
				double lng = e.Locations[e.Locations.Length-1].Coordinate.Longitude;
				var loc = new MyLocation (){Latitude = lat, Longtitude = lng};
				CallBack(loc);
			}
		}

		#endregion
	}
}

