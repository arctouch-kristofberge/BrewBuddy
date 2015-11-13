using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BrewBuddy.View.Custom
{
	public partial class TwoLinesListViewCell : ViewCell
	{
		#region Bindable properties
		public string FirstLine
		{
			get{ return (string)GetValue (FirstLineProperty); }
			set{ SetValue (FirstLineProperty, value); }
		}

		public static readonly BindableProperty FirstLineProperty = BindableProperty.Create<TwoLinesListViewCell, string>(
			x => x.FirstLine,
			string.Empty,
			BindingMode.OneWay,
			null,
			new BindableProperty.BindingPropertyChangedDelegate<string>(FirstLineUpdated));

		private static void FirstLineUpdated(BindableObject bindable, string oldValue, string newValue)
		{
			((TwoLinesListViewCell)bindable).FirstLineLabel.Text = newValue;
		}
		
		public string SecondLine
		{
			get{ return (string)GetValue (SecondLineProperty); }
			set{ SetValue (SecondLineProperty, value); }
		}

		public static readonly BindableProperty SecondLineProperty = BindableProperty.Create<TwoLinesListViewCell, string>(
			x => x.SecondLine,
			string.Empty,
			BindingMode.OneWay,
			null,
			new BindableProperty.BindingPropertyChangedDelegate<string>(SecondLineUpdated));
		
		private static void SecondLineUpdated(BindableObject bindable, string oldValue, string newValue)
		{
			((TwoLinesListViewCell)bindable).SecondLineLabel.Text = newValue;
		}
		#endregion


		public TwoLinesListViewCell ()
		{
			InitializeComponent ();
		}
	}
}

