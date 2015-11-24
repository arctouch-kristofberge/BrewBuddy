using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using BrewBuddy.View.Custom;
using Foundation;
using BrewBuddy.Design;

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
				SetColors (tabBar.TextColor, tabBar.InnerBackgroundColor);
		} 

		private void SetColors(Color textColor, Color backgroundColor)
		{
			var searchBar = Control as UISearchBar;

			searchBar.Layer.BorderColor = Helpers.Visual.GetUIColor (VisualDesign.SEARCHBAR_BORDER_COLOR).CGColor;

			foreach (UIView view in searchBar.Subviews)
			{
				foreach (UIView subView in view.Subviews)
				{
					UITextField textField = subView as UITextField;
					if (textField != null)
					{
						textField.AttributedPlaceholder = new NSAttributedString(textField.Placeholder, new UIStringAttributes()
							{
									ForegroundColor = Helpers.Visual.GetUIColor (textColor)
							});
						textField.TextColor = Helpers.Visual.GetUIColor (textColor);
						textField.BackgroundColor = Helpers.Visual.GetUIColor (backgroundColor);
						textField.Layer.BorderColor = Helpers.Visual.GetUIColor (VisualDesign.SEARCHBAR_BORDER_COLOR).CGColor;
					}
				}
			}
		}
	}
}

