using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(Button), typeof(BrewBuddy.iOS.Renderers.ButtonRenderer))]
namespace BrewBuddy.iOS.Renderers
{
	public class ButtonRenderer : Xamarin.Forms.Platform.iOS.ButtonRenderer
	{
		public ButtonRenderer ()
		{
			
		}

		protected override void OnElementChanged (ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged (e);

			SetColors ();
		}

		private void SetColors()
		{
			if (Control != null)
			{
//				Control.BackgroundColor = VisualDesign.BUTTON_BACKGROUND_COLOR;
//				Control.Font.FamilyName = VisualDesign.BUTTON_FONT_FAMILY;

			}
		}
	}
}

