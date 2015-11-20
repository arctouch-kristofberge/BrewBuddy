using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BrewBuddy.View.Custom
{
	public partial class ImageWithOverlay : ContentView
	{
		#region Bindable properties
		#region ImageUri
		public string ImageUri
		{
			get{ return (string)GetValue (ImageUriProperty); }
			set{ SetValue (ImageUriProperty, value); }
		}

		public static readonly BindableProperty ImageUriProperty = BindableProperty.Create<ImageWithOverlay, string>(
			x => x.ImageUri,
			string.Empty,
			BindingMode.OneWay,
			null,
			new BindableProperty.BindingPropertyChangedDelegate<string>(ImageUriUpdated));
				
		public static void ImageUriUpdated(BindableObject bindable, string oldValue, string newValue)
		{
			if(!string.IsNullOrEmpty(newValue))
				((ImageWithOverlay)bindable).UpdateImage(newValue);
		}
		#endregion

		#region OverlayText
		public string OverlayText
		{
			get{ return (string)GetValue (OverlayTextProperty); }
			set{ SetValue (OverlayTextProperty, value); }
		}

		public static readonly BindableProperty OverlayTextProperty = BindableProperty.Create<ImageWithOverlay, string>(
			x => x.OverlayText,
			string.Empty,
			BindingMode.OneWay,
			null,
			new BindableProperty.BindingPropertyChangedDelegate<string>(TextUpdated));
				
		public static void TextUpdated(BindableObject bindable, string oldValue, string newValue)
		{
			((ImageWithOverlay)bindable).OverlayTextLabel.Text = newValue;
		}
		#endregion
		#endregion

		public ImageWithOverlay ()
		{
			InitializeComponent ();
		}

		private void UpdateImage(string uri)
		{
			DisplayedImage.IsVisible = true;
			DisplayedImage.Source = ImageSource.FromUri (new Uri (uri));
		}
	}
}

