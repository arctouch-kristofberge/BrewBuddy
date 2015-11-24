using System;
using System.Collections.Generic;
using Xamarin.Forms;
using BrewBuddy.Model;
using BrewBuddy.Design;


using BrewBuddy.Design;

namespace BrewBuddy.View.Custom
{
	public partial class SrmView : ContentView
	{
		private const string LABEL_PHRASE = "SRM: {0}";

		private Color _backgroundColor;
		
		#region Bindable properties
		#region Srm
		public Srm Srm
		{
			get{ return (Srm)GetValue (SrmProperty); }
			set{ SetValue (SrmProperty, value); }
		}

		public static readonly BindableProperty SrmProperty = BindableProperty.Create<SrmView, Srm>(
			x => x.Srm,
			new Srm(),
			BindingMode.OneWay,
			null,
			new BindableProperty.BindingPropertyChangedDelegate<Srm>(SrmUpdated));
				
		public static void SrmUpdated(BindableObject bindable, Srm oldValue, Srm newValue)
		{
			
			((SrmView)bindable).UpdateView ();
		}
		#endregion
		#endregion

		public SrmView ()
		{
			InitializeComponent ();
		}

		private void UpdateView()
		{
			SetVisibility ();

			if(IsVisible)
			{
				SetText ();
				SetBackgroundColor ();
				SetTextColor ();
			}
		}

		private void SetVisibility()
		{
			this.IsVisible = Srm != null && (!string.IsNullOrWhiteSpace (Srm.Name) || !string.IsNullOrWhiteSpace (Srm.Hex));
		}

		private void SetText()
		{
			NameLabel.Text = string.Format (LABEL_PHRASE, Srm.Name);
		}

		private void SetBackgroundColor()
		{
			_backgroundColor = Color.FromHex ("#" + Srm.Hex);
			this.BackgroundColor = _backgroundColor;
		}

		private void SetTextColor ()
		{
			if (BackgroundIsALightColor ())
				NameLabel.TextColor = VisualDesign.SRM_TEXT_COLOR_LIGHT_BACKGROUND;
			else
				NameLabel.TextColor = VisualDesign.SRM_TEXT_COLOR_DARK_BACKGROUND;
		}

		private bool BackgroundIsALightColor ()
		{
			return _backgroundColor.Luminosity > 0.4;
		}
	}
}

