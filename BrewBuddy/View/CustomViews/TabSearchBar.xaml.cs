using System;
using System.Collections.Generic;
using Xamarin.Forms;
using BrewBuddy.Design;

namespace BrewBuddy.View.Custom
{
	public partial class TabSearchBar : SearchBar
	{
		#region Bindable Properties
		#region Text color
		public Color TextColor
		{
			get{ return (Color)GetValue (TextColorProperty); }
			set{ SetValue (TextColorProperty, value); }
		}

		public static readonly BindableProperty TextColorProperty = BindableProperty.Create<TabSearchBar, Color>(
			x => x.TextColor,
			Color.White,
			BindingMode.OneWay);
		#endregion

		#region InnerBackgroundColor
		public Color InnerBackgroundColor
		{
			get{ return (Color)GetValue (InnerBackgroundColorProperty); }
			set{ SetValue (InnerBackgroundColorProperty, value); }
		}

		public static readonly BindableProperty InnerBackgroundColorProperty = BindableProperty.Create<TabSearchBar, Color>(
			x => x.InnerBackgroundColor,
			Color.Gray,
			BindingMode.OneWay);
		#endregion
		#endregion
		
		public TabSearchBar ()
		{
			InitializeComponent ();

			TextColor = VisualDesign.SEARCHBAR_TEXT_COLOR;
			InnerBackgroundColor = VisualDesign.SEARCHBAR_INNER_BACKGROUND_COLOR;
		}
	}
}

