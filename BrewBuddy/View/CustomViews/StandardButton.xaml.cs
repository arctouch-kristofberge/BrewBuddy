using System;
using System.Collections.Generic;
using Xamarin.Forms;
using BrewBuddy.Design;

namespace BrewBuddy.View.Custom
{
	public partial class StandardButton : Button
	{
		public StandardButton ()
		{
			InitializeComponent ();

			BackgroundColor = VisualDesign.BUTTON_BACKGROUND_COLOR;
			FontFamily = VisualDesign.BUTTON_FONT_FAMILY;
			FontSize = VisualDesign.BUTTON_FONT_SIZE;
			TextColor = VisualDesign.BUTTON_TEXT_COLOR_ENABLED;
		}
	}
}

