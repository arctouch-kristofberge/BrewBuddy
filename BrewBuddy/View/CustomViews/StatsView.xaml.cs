using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BrewBuddy.View.Custom
{
	public partial class StatsView : ContentView
	{
		#region Bindable properties
		#region Name
		public string Name
				{
					get{ return (string)GetValue (NameProperty); }
					set{ SetValue (NameProperty, value); }
				}

		public static readonly BindableProperty NameProperty = BindableProperty.Create<StatsView, string>(
			x => x.Name,
			string.Empty,
			BindingMode.OneWay,
			null,
			new BindableProperty.BindingPropertyChangedDelegate<string>(NameUpdated));
		
		public static void NameUpdated(BindableObject bindable, string oldValue, string newValue)
		{
			((StatsView)bindable).NameLabel.Text = newValue;
		}
		#endregion

		#region Value
		public string Value
		{
			get{ return (string)GetValue (ValueProperty); }
			set{ SetValue (ValueProperty, value); }
		}

		public static readonly BindableProperty ValueProperty = BindableProperty.Create<StatsView, string>(
			x => x.Value,
			"N/A",
			BindingMode.OneWay,
			null,
			new BindableProperty.BindingPropertyChangedDelegate<string>(ValueUpdated));
				
		public static void ValueUpdated(BindableObject bindable, string oldValue, string newValue)
		{
			if(!string.IsNullOrEmpty (newValue))
				((StatsView)bindable).ValueLabel.Text = newValue;
		}
		#endregion

		#endregion

		public StatsView ()
		{
			InitializeComponent ();

			InitializeLabels ();
		}

		public void InitializeLabels()
		{
			ValueLabel.Text = Value;
		}
	}
}

