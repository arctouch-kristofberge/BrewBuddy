using System;
using Xamarin.Forms;

namespace BrewBuddy.Design
{
	public static class VisualDesign
	{
		#region Private values
		#region View colors
		private static readonly Color BRAND_COLOR = Color.FromHex ("#2196F3");
		private static readonly Color BRAND_COLOR_LIGHT = Color.FromHex ("#64B5F6");
		private static readonly Color BRAND_COLOR_DARK = Color.FromHex ("#1976D2");
		private static readonly Color ACCENT_COLOR = Color.FromHex ("#FAD255");
		private static readonly Color BACKGROUND_COLOR = Color.White;
		#endregion

		#region Text colors
		private static readonly Color TEXT_COLOR_NORMAL_OR_DARK_BACKGROUND = Color.White;
		private static readonly Color TEXT_COLOR_LIGHT_BACKGROUND = Color.Black;
		private const double TEXT_ALPHA_PRIMARY = 0.87;
		private const double TEXT_ALPHA_SECONDARY = 0.54;
		private const double TEXT_ALPHA_DISABLED = 0.38;
		private const double TEXT_ALPHA_DIVIDER = 0.12;
		#endregion

		#region Font
		private static readonly string FONT_FAMILY = Device.OnPlatform("Gotham-Book", "Gotham-Book.ttf", "Gotham-Book");
		private static readonly string FONT_FAMILY_MEDIUM = Device.OnPlatform("Gotham-Medium", "Gotham-Medium.ttf", "Gotham-Medium");
		private const double FONT_SIZE_SMALL = 12.0;
		private const double FONT_SIZE_MEDIUM = 16.0;
		private const double FONT_SIZE_LARGE = 20.0;

		private static readonly Color TEXT_COLOR_PRIMARY = Color.FromRgba (
			TEXT_COLOR_NORMAL_OR_DARK_BACKGROUND.R, 
			TEXT_COLOR_NORMAL_OR_DARK_BACKGROUND.G,
			TEXT_COLOR_NORMAL_OR_DARK_BACKGROUND.B,
			TEXT_ALPHA_PRIMARY);
		private static readonly Color TEXT_COLOR_SECONDARY = Color.FromRgba (
			TEXT_COLOR_NORMAL_OR_DARK_BACKGROUND.R, 
			TEXT_COLOR_NORMAL_OR_DARK_BACKGROUND.G,
			TEXT_COLOR_NORMAL_OR_DARK_BACKGROUND.B,
			TEXT_ALPHA_SECONDARY);
		private static readonly Color TEXT_COLOR_DISABLED = Color.FromRgba (
			TEXT_COLOR_NORMAL_OR_DARK_BACKGROUND.R, 
			TEXT_COLOR_NORMAL_OR_DARK_BACKGROUND.G,
			TEXT_COLOR_NORMAL_OR_DARK_BACKGROUND.B,
			TEXT_ALPHA_DISABLED);
		private static readonly Color TEXT_COLOR_DIVIDER = Color.FromRgba (
			TEXT_COLOR_NORMAL_OR_DARK_BACKGROUND.R, 
			TEXT_COLOR_NORMAL_OR_DARK_BACKGROUND.G,
			TEXT_COLOR_NORMAL_OR_DARK_BACKGROUND.B,
			TEXT_ALPHA_DIVIDER);
		
		private static readonly Color TEXT_COLOR_PRIMARY_LIGHTBACKGROUND = Color.FromRgba (
			TEXT_COLOR_LIGHT_BACKGROUND.R, 
			TEXT_COLOR_LIGHT_BACKGROUND.G,
			TEXT_COLOR_LIGHT_BACKGROUND.B,
			TEXT_ALPHA_PRIMARY);
		private static readonly Color TEXT_COLOR_SECONDARY_LIGHTBACKGROUND = Color.FromRgba (
			TEXT_COLOR_LIGHT_BACKGROUND.R, 
			TEXT_COLOR_LIGHT_BACKGROUND.G,
			TEXT_COLOR_LIGHT_BACKGROUND.B,
			TEXT_ALPHA_SECONDARY);
		private static readonly Color TEXT_COLOR_DISABLED_LIGHTBACKGROUND = Color.FromRgba (
			TEXT_COLOR_LIGHT_BACKGROUND.R, 
			TEXT_COLOR_LIGHT_BACKGROUND.G,
			TEXT_COLOR_LIGHT_BACKGROUND.B,
			TEXT_ALPHA_DISABLED);
		private static readonly Color TEXT_COLOR_DIVIDER_LIGHTBACKGROUND = Color.FromRgba (
			TEXT_COLOR_LIGHT_BACKGROUND.R, 
			TEXT_COLOR_LIGHT_BACKGROUND.G,
			TEXT_COLOR_LIGHT_BACKGROUND.B,
			TEXT_ALPHA_DIVIDER);
        #endregion

		#region Screen size
		private static int ScreenHeight = DependencyService.Get<IEnvironment>().ScreenHeight;
		private static int ScreenWidth = DependencyService.Get<IEnvironment>().ScreenWidth;
		private const double TARGET_DESIGN_WIDTH_TABLET = 1536;
		private const double TARGET_DESIGN_HEIGHT_TABLET = 2048;

		private const double TARGET_DESIGN_WIDTH_PHONE = 640;
		private const double TARGET_DESIGN_HEIGHT_PHONE = 1136;
		#endregion
        #endregion

		#region Screen size
		public static double TargetDesignWidth
		{
			get
			{
				if (IsPortrait)
				{
					return IsTablet ? TARGET_DESIGN_WIDTH_TABLET : TARGET_DESIGN_WIDTH_PHONE;
				}
				else
				{
					return IsTablet ? TARGET_DESIGN_HEIGHT_TABLET : TARGET_DESIGN_HEIGHT_PHONE;
				}
			}
		}

		public static double TargetDesignHeight
		{
			get
			{
				if (IsPortrait)
				{
					return IsTablet ? TARGET_DESIGN_HEIGHT_TABLET : TARGET_DESIGN_HEIGHT_PHONE;
				}
				else
				{
					return IsTablet ? TARGET_DESIGN_WIDTH_TABLET : TARGET_DESIGN_WIDTH_PHONE;
				}
			}
		} 

		public static bool IsPortrait
		{
			get
			{
				return (ScreenHeight > ScreenWidth);
			}
		}

		public static bool IsTablet
		{
			get
			{
				return (Device.Idiom == TargetIdiom.Tablet);
			}
		}

		public static bool IsPhone
		{
			get
			{
				return (Device.Idiom == TargetIdiom.Phone);
			}
		}


		#endregion

		#region Scaling methods
		public static double ScaleWidth(double width)
		{
			return (width / TargetDesignWidth) * ScreenWidth;
		}

		public static double ScaleHeight(double height)
		{
			return (height / TargetDesignHeight) * ScreenHeight;
		}

		public static Thickness ScalePadding(Thickness thickness)
		{
			return new Thickness(VisualDesign.ScaleWidth(thickness.Left), VisualDesign.ScaleHeight(thickness.Top),
				VisualDesign.ScaleWidth(thickness.Right), VisualDesign.ScaleHeight(thickness.Bottom));
		}

		public static double ScaleFontSize(double fontSize)
		{
			return ScaleHeight(fontSize);
		}

		public static int ScaleBorderRadius(double radius)
		{
			return (int)Math.Min(ScaleHeight(radius), ScaleWidth(radius));
		}

		public static Rectangle ScaleLayoutBounds(Rectangle rectangle)
		{
			return new Rectangle(rectangle.X <= 1 ? rectangle.X : ScaleWidth(rectangle.X), 
				rectangle.Y <= 1 ? rectangle.Y : ScaleHeight(rectangle.Y), 
				rectangle.Width <= 1 ? rectangle.Width : ScaleWidth(rectangle.Width), 
				rectangle.Height <= 1 ? rectangle.Height : ScaleHeight(rectangle.Height));
		}     
		#endregion

		#region General
		public static readonly Thickness STANDARD_PADDING = new Thickness(10, 0);
		public static readonly Color STANDARD_BACKGROUND_COLOR = Color.White;
		#endregion

		#region SearchBar
		public static readonly Color SEARCHBAR_BACKGROUND_COLOR = BRAND_COLOR;
		public static readonly Color SEARCHBAR_CANCEL_COLOR = TEXT_COLOR_SECONDARY_LIGHTBACKGROUND;
		public static readonly Color SEARCHBAR_TEXT_COLOR = TEXT_COLOR_PRIMARY_LIGHTBACKGROUND;
		public static readonly Color SEARCHBAR_INNER_BACKGROUND_COLOR = STANDARD_BACKGROUND_COLOR;
		public static readonly Color SEARCHBAR_BORDER_COLOR = BRAND_COLOR_DARK;
		public static readonly Color SEARCHBAR_PLACEHOLDER_TEXT_COLOR = TEXT_COLOR_SECONDARY_LIGHTBACKGROUND;
		public static readonly string SEARCHBAR_FONT_FAMILY = FONT_FAMILY;
		public const double SEARCHBAR_FONT_SIZE = FONT_SIZE_MEDIUM;
		#endregion

		#region List
		public static readonly Color LIST_BACKGROUND_COLOR = STANDARD_BACKGROUND_COLOR;
		public static readonly Color LISTITEM_BACKGROUND_COLOR = BACKGROUND_COLOR;
		public static readonly Color LISTITEM_EVENCELL_BACKGROUND_COLOR = BRAND_COLOR_DARK;
		public static readonly Color LISTITEM_UNEVENCELL_BACKGROUND_COLOR = BRAND_COLOR;
		public static readonly Color LISTITEM_FIRSTLINE_TEXT_COLOR = TEXT_COLOR_PRIMARY;
		public static readonly Color LISTITEM_SECONDLINE_TEXT_COLOR = TEXT_COLOR_SECONDARY;
		public static readonly string LISTITEM_FIRSTLINE_FONT_FAMILY = FONT_FAMILY;
		public static readonly string LISTITEM_SECONDLINE_FONT_FAMILY = FONT_FAMILY_MEDIUM;
		public const double LISTITEM_FIRSTLINE_FONT_SIZE = FONT_SIZE_MEDIUM;
		public const double LISTITEM_SECONDLINE_FONT_SIZE = FONT_SIZE_SMALL;
		public static readonly Color LISTITEM_SEPERATOR_COLOR = TEXT_COLOR_DIVIDER;
		#endregion

		#region Button
		public static readonly Color BUTTON_BACKGROUND_COLOR = BRAND_COLOR;
		public static readonly Color BUTTON_TEXT_COLOR_ENABLED = TEXT_COLOR_PRIMARY;
		public static readonly Color BUTTON_TEXT_COLOR_DISABLED = TEXT_COLOR_DISABLED;
		public static readonly string BUTTON_FONT_FAMILY = FONT_FAMILY;
		public const double BUTTON_FONT_SIZE = FONT_SIZE_MEDIUM;
		#endregion

		#region Page
		public static readonly Color PAGE_BACKGROUND_COLOR = STANDARD_BACKGROUND_COLOR;
		public static readonly Color DETAILSPAGE_BACKGROUND_COLOR = BRAND_COLOR_LIGHT;
		#endregion

		#region Icons
		public static readonly string ICON_NOT_FAVORITE = "star_nfav.png";
		public static readonly string ICON_FAVORITE = "star_fav.png";
		public static readonly string ICON_COLLAPSABLE_CONTENT_COLLAPSED = "arrow_right_icon.png";
		public static readonly string ICON_COLLAPSABLE_CONTENT_VISIBLE = "arrow_down_icon.png";
		#endregion

		#region Label
		public static readonly string LABEL_FONT_FAMILY = FONT_FAMILY;
		public const double LABEL_FONT_SIZE_TITLE = FONT_SIZE_LARGE;
		public const double LABEL_FONT_SIZE_NORMAL = FONT_SIZE_MEDIUM;
		public const double LABEL_FONT_SIZE_SMALL = FONT_SIZE_SMALL;
		public static readonly Color LABEL_TEXT_COLOR_PRIMARY = TEXT_COLOR_PRIMARY;
		public static readonly Color LABEL_TEXT_COLOR_SECONDARY = TEXT_COLOR_SECONDARY;
		#endregion

		#region StatsView
		public static readonly Color STATS_BACKGROUND_COLOR = ACCENT_COLOR;
		public static readonly string STATS_FONT_FAMILY = FONT_FAMILY;
		public static readonly Color STATS_NAME_TEXT_COLOR = TEXT_COLOR_SECONDARY;
		public static readonly Color STATS_VALUE_TEXT_COLOR = TEXT_COLOR_PRIMARY;
		#endregion

		#region Image with overlay
		public static readonly Color OVERLAY_BACKGROUND_COLOR = TEXT_COLOR_SECONDARY_LIGHTBACKGROUND;
		public static readonly Color OVERLAY_TEXT_COLOR = Color.White;
		public static readonly string OVERLAY_FONT_FAMILY = FONT_FAMILY;
		public static readonly double OVERLAY_FONT_SIZE = FONT_SIZE_MEDIUM;
		public static readonly double OVERLAY_SECONDLINE_FONT_SIZE = FONT_SIZE_SMALL;
		public static readonly double IMAGE_WITH_OVERLAY_MAX_HEIGHT = ScreenHeight / 3;
		#endregion

		#region ServingView
		public static readonly Color SERVING_BACKGROUND_COLOR = ACCENT_COLOR;
		#endregion

		#region List header
		public static readonly Color LISTHEADER_BACKGROUND_COLOR = BRAND_COLOR; 
		public static readonly Color LISTHEADER_TEXT_COLOR = TEXT_COLOR_PRIMARY;
		public static readonly double LISTHEADER_FONT_SIZE = FONT_SIZE_MEDIUM;
		public static readonly string LISTHEADER_FONT_ATTRIBUTES = "Bold";
		public static readonly Color LISTHEADER_SEPERATOR_COLOR = BRAND_COLOR_DARK;
		#endregion

		#region SrmView
		public static readonly Color SRM_TEXT_COLOR_LIGHT_BACKGROUND = TEXT_COLOR_PRIMARY_LIGHTBACKGROUND;
		public static readonly Color SRM_TEXT_COLOR_DARK_BACKGROUND = TEXT_COLOR_PRIMARY;
		#endregion

		#region CollapsableView
		public static readonly Color COLLAPSABLE_HEADER_BACKGROUND_COLOR = ACCENT_COLOR;
		public static readonly Color COLLAPSABLE_HEADER_TEXT_COLOR = TEXT_COLOR_PRIMARY_LIGHTBACKGROUND;
		#endregion
	}
}

