using System;
using System.Collections.Generic;
using Xamarin.Forms;
using BrewBuddy.Design;
using System.Reflection;
using System.Windows.Input;
using BrewBuddy.Event;
using BrewBuddy.Model;
using PropertyChanged;
using System.Collections;
using BrewBuddy.CustomExceptions;

namespace BrewBuddy.View.Custom
{
	[ImplementPropertyChanged]
	public partial class MyViewCell : ViewCell
	{
		public MyViewCell ()
		{
			InitializeComponent ();
			
			UpdateFavoriteIcon ();
		}
		
		#region Bindable properties
		#region First line
		public string FirstLine
		{
			get{ return (string)GetValue (FirstLineProperty); }
			set{ SetValue (FirstLineProperty, value); }
		}

		public static readonly BindableProperty FirstLineProperty = BindableProperty.Create<MyViewCell, string>(
			x => x.FirstLine,
			string.Empty,
			BindingMode.OneWay,
			null,
			new BindableProperty.BindingPropertyChangedDelegate<string>(FirstLineUpdated));

		private static void FirstLineUpdated(BindableObject bindable, string oldValue, string newValue)
		{
			((MyViewCell)bindable).FirstLineLabel.Text = newValue;
		}
		#endregion

		#region Second line
		public string SecondLine
		{
			get{ return (string)GetValue (SecondLineProperty); }
			set{ SetValue (SecondLineProperty, value); }
		}

		public static readonly BindableProperty SecondLineProperty = BindableProperty.Create<MyViewCell, string>(
			x => x.SecondLine,
			string.Empty,
			BindingMode.OneWay,
			null,
			new BindableProperty.BindingPropertyChangedDelegate<string>(SecondLineUpdated));
		
		private static void SecondLineUpdated(BindableObject bindable, string oldValue, string newValue)
		{
			((MyViewCell)bindable).UpdateSecondLine (newValue);
		}

		 
		#endregion

		#region Is favorite
		public bool IsFavorite
		{
			get{ return (bool)GetValue (IsFavoriteProperty); }
			set{ SetValue (IsFavoriteProperty, value); }
		}

		public static readonly BindableProperty IsFavoriteProperty = BindableProperty.Create<MyViewCell, bool>(
			x => x.IsFavorite,
			false,
			BindingMode.TwoWay,
			null,
			new BindableProperty.BindingPropertyChangedDelegate<bool>(ToggleFavorite));

		private static void ToggleFavorite(BindableObject bindable, bool oldValue, bool newValue)
		{
			((MyViewCell)bindable).UpdateFavoriteIcon ();
		}
		#endregion

		#endregion

		#region Labels
		private void UpdateSecondLine(string text)
		{
			SecondLineLabel.Text = text;
		}
		#endregion

		#region Favorite
		private void UpdateFavoriteIcon()
		{
			if(IsFavorite)
				FavIcon.Source = ImageSource.FromResource (VisualDesign.ICON_FAVORITE);
			else
				FavIcon.Source = ImageSource.FromResource (VisualDesign.ICON_NOT_FAVORITE);
		}

		public event EventHandler<FavoriteToggledEventArgs> FavoriteToggled;
		
		private void FavIconTapped(object sender, EventArgs e)
		{
			IsFavorite = !IsFavorite;

			if(FavoriteToggled != null)
				FavoriteToggled(this, 
					new FavoriteToggledEventArgs (){
						IsFavorite = IsFavorite,
						Item = this.BindingContext as BaseDataModel
					});
		}
		#endregion
	}
}

