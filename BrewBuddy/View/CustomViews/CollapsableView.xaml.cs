using System;
using System.Collections.Generic;
using Xamarin.Forms;
using BrewBuddy.Design;

namespace BrewBuddy.View.Custom
{
	public partial class CollapsableView : ContentView
	{
		#region Bindable properties
		#region Header
		public string Header
		{
			get{ return (string)GetValue (HeaderProperty); }
			set{ SetValue (HeaderProperty, value); }
		}

		public static readonly BindableProperty HeaderProperty = BindableProperty.Create<CollapsableView, string>(
			x => x.Header,
			string.Empty,
			BindingMode.OneWay,
			null,
			new BindableProperty.BindingPropertyChangedDelegate<string>(Delegate));
				
		public static void Delegate(BindableObject bindable, string oldValue, string newValue)
		{
			((CollapsableView)bindable).HeaderLabel.Text = newValue;
		}
		#endregion

		#region HeaderBackgroundColor
		public Color HeaderBackgroundColor
		{
			get{ return (Color)GetValue (HeaderBackgroundColorProperty); }
			set{ SetValue (HeaderBackgroundColorProperty, value); }
		}

		public static readonly BindableProperty HeaderBackgroundColorProperty = BindableProperty.Create<CollapsableView, Color>(
			x => x.HeaderBackgroundColor,
			Color.White,
			BindingMode.OneWay,
			null,
			new BindableProperty.BindingPropertyChangedDelegate<Color>(HeaderBackgroundColorUpdated));
				
		public static void HeaderBackgroundColorUpdated(BindableObject bindable, Color oldValue, Color newValue)
		{
			((CollapsableView)bindable).LabelContentView.BackgroundColor = newValue;
		}
		#endregion

		#region HeaderTextColor
		public Color HeaderTextColor
		{
			get{ return (Color)GetValue (HeaderTextColorProperty); }
			set{ SetValue (HeaderTextColorProperty, value); }
		}

		public static readonly BindableProperty HeaderTextColorProperty = BindableProperty.Create<CollapsableView, Color>(
			x => x.HeaderTextColor,
			Color.Black,
			BindingMode.OneWay,
			null,
			new BindableProperty.BindingPropertyChangedDelegate<Color>(HeaderTextColorUpdated));
				
		public static void HeaderTextColorUpdated(BindableObject bindable, Color oldValue, Color newValue)
		{
			((CollapsableView)bindable).HeaderLabel.TextColor = newValue;
		}
		#endregion

		#region IsVisibleDefault
		public bool IsVisibleDefault
		{
			get{ return (bool)GetValue (IsVisibleDefaultProperty); }
			set{ SetValue (IsVisibleDefaultProperty, value); }
		}

		public static readonly BindableProperty IsVisibleDefaultProperty = BindableProperty.Create<CollapsableView, bool>(
			x => x.IsVisibleDefault,
			false,
			BindingMode.OneWay,
			null,
			new BindableProperty.BindingPropertyChangedDelegate<bool>(IsVisibleDefaultUpdated));
				
		public static void IsVisibleDefaultUpdated(BindableObject bindable, bool oldValue, bool newValue)
		{
			((CollapsableView)bindable).ContentToCollapse.IsVisible = newValue;
		}
		#endregion
		#endregion

		#region UI properties
		private Xamarin.Forms.View _contentToCollapse;
		public Xamarin.Forms.View ContentToCollapse {
			get {
				return _contentToCollapse;
			}
			set {
				_contentToCollapse = value;
				ContentUpdated ();
			}
		}

		public bool ContentVisible { get { return _contentToCollapse.IsVisible; } }

		#endregion
		
		#region Update methods
		private void ContentUpdated ()
		{
			if (_contentToCollapse != null) 
			{
				OuterLayout.Children.Add (_contentToCollapse);
				SetDefaultVisiblity ();
			}
		}

		private void SetDefaultVisiblity()
		{
			if (!_isDefaultVisibilitySet) 
			{
				_contentToCollapse.IsVisible = IsVisibleDefault;
				UpdateArrowIcon ();
				_isDefaultVisibilitySet = true;
			}
		}
		
		private void UpdateArrowIcon()
		{
			if(ArrowIcon!=null)
			{
				if (ContentVisible)
					ArrowIcon.Source = ImageSource.FromResource ( VisualDesign.ICON_COLLAPSABLE_CONTENT_VISIBLE);
				else
					ArrowIcon.Source = ImageSource.FromResource ( VisualDesign.ICON_COLLAPSABLE_CONTENT_COLLAPSED);
			}
		}
		#endregion

		private bool _isDefaultVisibilitySet = false;
		
		private void HeaderTapped(object sender, EventArgs e)
		{
			_contentToCollapse.IsVisible = !_contentToCollapse.IsVisible;
			UpdateArrowIcon ();
		}

		public CollapsableView ()
		{
			InitializeComponent ();
		}
	}
}

