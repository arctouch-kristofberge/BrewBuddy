﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using BrewBuddy.Design;
using System.Reflection;
using System.Windows.Input;

namespace BrewBuddy.View.Custom
{
	public partial class MyViewCell : ViewCell
	{
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
			((MyViewCell)bindable).SecondLineLabel.Text = newValue;
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

		public event EventHandler<bool> FavoriteToggled;

		#endregion

		public MyViewCell ()
		{
			InitializeComponent ();

			UpdateFavoriteIcon ();
		}

		private void UpdateFavoriteIcon()
		{
			if(IsFavorite)
				FavIcon.Source = ImageSource.FromResource (VisualDesign.ICON_FAVORITE);
			else
				FavIcon.Source = ImageSource.FromResource (VisualDesign.ICON_NOT_FAVORITE);
		}

		private void FavIconTapped(object sender, EventArgs e)
		{
			IsFavorite = !IsFavorite;

			if(FavoriteToggled != null)
				FavoriteToggled(this, IsFavorite);
		}
	}
}
