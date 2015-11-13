using System;
using System.Collections.Generic;
using Xamarin.Forms;
using BrewBuddy.Design;

namespace BrewBuddy.View.Custom
{
	public partial class TabSearchBar : SearchBar
	{
		public Color TextColor
		{
			get{ return (Color)GetValue (TextColorProperty); }
			set{ SetValue (TextColorProperty, value); }
		}

		public static readonly BindableProperty TextColorProperty = BindableProperty.Create<TabSearchBar, Color>(
			x => x.TextColor,
			Color.White,
			BindingMode.OneWay);
		
		public TabSearchBar ()
		{
			InitializeComponent ();

			TextColor = VisualDesign.SEARCH_BAR_TEXT_COLOR;
		}
	}
}

