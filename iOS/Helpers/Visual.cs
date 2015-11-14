using System;
using UIKit;
using Xamarin.Forms;

namespace BrewBuddy.iOS.Helpers
{
	public static class Visual
	{
		public static UIColor GetUIColor(Color color)
		{
			return new UIColor (
				(nfloat) color.R,
				(nfloat) color.G,
				(nfloat) color.B,
				(nfloat) color.A);
		}
	}
}

