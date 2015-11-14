using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using BrewBuddy.View.Custom;
using Foundation;

[assembly: ExportRenderer(typeof(TabSearchBar), typeof(BrewBuddy.iOS.Renderers.SearchBarRenderer))]
namespace BrewBuddy.iOS.Renderers
{
	public class SearchBarRenderer : Xamarin.Forms.Platform.iOS.SearchBarRenderer
	{
		public SearchBarRenderer ()
		{
			
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

		}

		protected override void OnElementChanged (ElementChangedEventArgs<SearchBar> e)
		{
			base.OnElementChanged (e);
			var tabBar = e.NewElement as TabSearchBar;

			if(tabBar!= null)
				SetTextColor (tabBar.TextColor);
		} 

		private void SetTextColor(Color color)
		{
			var searchBar = Control as UISearchBar;
			UIColor uiColor = Helpers.Visual.GetUIColor (color);

			foreach (UIView view in searchBar.Subviews)
			{
				foreach (UIView subView in view.Subviews)
				{
					UITextField textField = subView as UITextField;
					if (textField != null)
					{
						textField.AttributedPlaceholder = new NSAttributedString(textField.Placeholder, new UIStringAttributes()
							{
								ForegroundColor = uiColor
							});
						textField.TextColor = uiColor;
					}
				}
			}
		}
	}
}

