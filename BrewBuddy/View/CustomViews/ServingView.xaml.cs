using System;
using System.Collections.Generic;
using Xamarin.Forms;
using BrewBuddy.Model;

namespace BrewBuddy.View.Custom
{
	public partial class ServingView : ContentView
	{
		private const string LABEL_PHRASE_FULL = "Served {0} in a {1}.";
		private const string LABEL_PHRASE_GLASS_ONLY = "Served in a {0}.";
		private const string LABEL_PHRASE_TEMP_ONLY = "Served {0}.";

		#region Bindable Property
		#region Glass
		public Glass Glass
		{
			get{ return (Glass)GetValue (GlassProperty); }
			set{ SetValue (GlassProperty, value); }
		}

		public static readonly BindableProperty GlassProperty = BindableProperty.Create<ServingView, Glass>(
			x => x.Glass,
			new Glass(),
			BindingMode.OneWay,
			null,
			new BindableProperty.BindingPropertyChangedDelegate<Glass>(PropertyUpdated));
		#endregion

		#region ServingTemparature
		public string Temperature
		{
			get{ return (string)GetValue (TemperatureProperty); }
			set{ SetValue (TemperatureProperty, value); }
		}

		public static readonly BindableProperty TemperatureProperty = BindableProperty.Create<ServingView, string>(
			x => x.Temperature,
			string.Empty,
			BindingMode.OneWay,
			null,
			new BindableProperty.BindingPropertyChangedDelegate<string>(PropertyUpdated));
		#endregion

		public static void PropertyUpdated(BindableObject bindable, object oldValue, object newValue)
		{
			
			((ServingView)bindable).UpdateLabel();
		}
		#endregion

		public ServingView ()
		{
			InitializeComponent ();
		}

		private void UpdateLabel()
		{
			UpdateVisibility ();

			if(IsVisible)
				UpdateText ();
		}

		private void UpdateVisibility()
		{
			this.IsVisible = (Glass != null && !string.IsNullOrEmpty (Glass.Name))
								|| !string.IsNullOrEmpty (Temperature);
		}

		private void UpdateText()
		{
			if (Glass == null || string.IsNullOrEmpty (Glass.Name))
				DisplayLabel.Text = string.Format (LABEL_PHRASE_TEMP_ONLY, Temperature);
			else if (string.IsNullOrEmpty (Temperature))
				DisplayLabel.Text = string.Format (LABEL_PHRASE_GLASS_ONLY, Glass.Name);
			else
				DisplayLabel.Text = string.Format (LABEL_PHRASE_FULL, Temperature, Glass.Name);
		}
	}
}

