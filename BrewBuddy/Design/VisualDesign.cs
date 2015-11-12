using System;
using Xamarin.Forms;

namespace BrewBuddy
{
	public static class VisualDesign
	{
		#region Colors
		public static readonly Color BRAND_COLOR = Color.FromHex ("#2979FF");
		public static readonly Color BRAND_COLOR_LIGHT = Color.FromHex ("#448AFF");
		public static readonly Color BRAND_COLOR_DARK = Color.FromHex ("#2962FF");
		public static readonly Color BACKGROUND_COLOR = Color.White;
		#endregion

		#region Text colors
		public static readonly Color TEXT_COLOR_BASE = Color.Black;
		public const int TEXT_ALPHA_PRIMARY = 87;
		public const int TEXT_ALPHA_SECONDARY = 54;
		public const int TEXT_ALPHA_DISABLED = 38;
		public const int TEXT_ALPHA_DIVIDER = 12;

		public static readonly Color TEXT_COLOR_PRIMARY = Color.FromRgba (
			TEXT_COLOR_BASE.R, 
			TEXT_COLOR_BASE.G,
			TEXT_COLOR_BASE.B,
			TEXT_ALPHA_PRIMARY);
		public static readonly Color TEXT_COLOR_SECONDARY = Color.FromRgba (
			TEXT_COLOR_BASE.R, 
			TEXT_COLOR_BASE.G,
			TEXT_COLOR_BASE.B,
			TEXT_ALPHA_SECONDARY);
		public static readonly Color TEXT_COLOR_DISABLED = Color.FromRgba (
			TEXT_COLOR_BASE.R, 
			TEXT_COLOR_BASE.G,
			TEXT_COLOR_BASE.B,
			TEXT_ALPHA_DISABLED);
		public static readonly Color TEXT_COLOR_DIVIDER = Color.FromRgba (
			TEXT_COLOR_BASE.R, 
			TEXT_COLOR_BASE.G,
			TEXT_COLOR_BASE.B,
			TEXT_ALPHA_DIVIDER);
		#endregion

		#region Font
		public static readonly string FONT_FAMILY = Device.OnPlatform("Gotham-Book", "Gotham-Book.ttf", "Gotham-Book");
		public static readonly string FONT_FAMILY_MEDIUM = Device.OnPlatform("Gotham-Medium", "Gotham-Medium.ttf", "Gotham-Medium");
		#endregion

		#region Button
		public static readonly Color BUTTON_BACKGROUND_COLOR = BRAND_COLOR;
		public static readonly Color BUTTON_TEXT_COLOR_ENABLED = TEXT_COLOR_PRIMARY;
		public static readonly Color BUTTON_TEXT_COLOR_DISABLED = TEXT_COLOR_DISABLED;
		public static readonly string BUTTON_FONT_FAMILY = FONT_FAMILY;
		public const double BUTTON_FONT_SIZE = 14.0;
		#endregion
	}
}

