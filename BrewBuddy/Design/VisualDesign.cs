using System;
using Xamarin.Forms;

namespace BrewBuddy.Design
{
	public static class VisualDesign
	{
		#region Private values
		#region View colors
		private static readonly Color BRAND_COLOR = Color.FromHex ("#2979FF");
		private static readonly Color BRAND_COLOR_LIGHT = Color.FromHex ("#448AFF");
		private static readonly Color BRAND_COLOR_DARK = Color.FromHex ("#2962FF");
		private static readonly Color BACKGROUND_COLOR = Color.White;
		#endregion

		#region Text colors
		private static readonly Color TEXT_COLOR_BASE = Color.Black;
		private const double TEXT_ALPHA_PRIMARY = 0.87;
		private const double TEXT_ALPHA_SECONDARY = 0.54;
		private const double TEXT_ALPHA_DISABLED = 0.38;
		private const double TEXT_ALPHA_DIVIDER = 0.12;
		#endregion

		#region Font
		private static readonly string FONT_FAMILY = Device.OnPlatform("Gotham-Book", "Gotham-Book.ttf", "Gotham-Book");
		private static readonly string FONT_FAMILY_MEDIUM = Device.OnPlatform("Gotham-Medium", "Gotham-Medium.ttf", "Gotham-Medium");
		private const double FONT_SIZE_SMALL = 10.0;
		private const double FONT_SIZE_MEDIUM = 14.0;
		private const double FONT_SIZE_LARGE = 20.0;
        #endregion
		
		#region Text colors
		private static readonly Color TEXT_COLOR_PRIMARY = Color.FromRgba (
			TEXT_COLOR_BASE.R, 
			TEXT_COLOR_BASE.G,
			TEXT_COLOR_BASE.B,
			TEXT_ALPHA_PRIMARY);
		private static readonly Color TEXT_COLOR_SECONDARY = Color.FromRgba (
			TEXT_COLOR_BASE.R, 
			TEXT_COLOR_BASE.G,
			TEXT_COLOR_BASE.B,
			TEXT_ALPHA_SECONDARY);
		private static readonly Color TEXT_COLOR_DISABLED = Color.FromRgba (
			TEXT_COLOR_BASE.R, 
			TEXT_COLOR_BASE.G,
			TEXT_COLOR_BASE.B,
			TEXT_ALPHA_DISABLED);
		private static readonly Color TEXT_COLOR_DIVIDER = Color.FromRgba (
			TEXT_COLOR_BASE.R, 
			TEXT_COLOR_BASE.G,
			TEXT_COLOR_BASE.B,
			TEXT_ALPHA_DIVIDER);
		#endregion
		#endregion


		#region SearchBar
		public static readonly Color SEARCHBAR_BACKGROUND_COLOR = BACKGROUND_COLOR;
		public static readonly Color SEARCH_BAR_TEXT_COLOR = TEXT_COLOR_PRIMARY;
		public static readonly string SEARCHBAR_FONT_FAMILY = FONT_FAMILY;
		public const double SEARCHBAR_FONT_SIZE = FONT_SIZE_MEDIUM;
		#endregion

		#region List item
		public static readonly Color LISTITEM_BACKGROUND_COLOR = BACKGROUND_COLOR;
		public static readonly Color LISTITEM_FIRSTLINE_TEXT_COLOR = TEXT_COLOR_PRIMARY;
		public static readonly Color LISTITEM_SECONDLINE_TEXT_COLOR = TEXT_COLOR_SECONDARY;
		public static readonly string LISTITEM_FIRSTLINE_FONT_FAMILY = FONT_FAMILY;
		public static readonly string LISTITEM_SECONDLINE_FONT_FAMILY = FONT_FAMILY_MEDIUM;
		public const double LISTITEM_FIRSTLINE_FONT_SIZE = FONT_SIZE_LARGE;
		public const double LISTITEM_SECONDLINE_FONT_SIZE = FONT_SIZE_MEDIUM;
		#endregion

		#region Button
		public static readonly Color BUTTON_BACKGROUND_COLOR = BRAND_COLOR;
		public static readonly Color BUTTON_TEXT_COLOR_ENABLED = TEXT_COLOR_PRIMARY;
		public static readonly Color BUTTON_TEXT_COLOR_DISABLED = TEXT_COLOR_DISABLED;
		public static readonly string BUTTON_FONT_FAMILY = FONT_FAMILY;
		public const double BUTTON_FONT_SIZE = FONT_SIZE_MEDIUM;
		#endregion

		#region Page
		public static readonly Color PAGE_BACKGROUND_COLOR = BACKGROUND_COLOR;
		#endregion
	}
}

