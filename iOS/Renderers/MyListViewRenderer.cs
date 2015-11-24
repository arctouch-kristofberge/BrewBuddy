using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using BrewBuddy.Design;
using System.ComponentModel;
using BrewBuddy.Model;
using System.Collections;
using System.Collections.Generic;
using BrewBuddy.CustomExceptions;
using BrewBuddy.View.Custom;
using System.Linq;

[assembly: ExportRenderer(typeof(ListView), typeof(BrewBuddy.iOS.Renderers.MyListViewRenderer))]
namespace BrewBuddy.iOS.Renderers
{
	public class MyListViewRenderer : ListViewRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<ListView> e)
		{
			base.OnElementChanged (e);

			var list = Control as UITableView;
			if(list != null)
			{
				list.SeparatorStyle = UITableViewCellSeparatorStyle.None;
				list.BackgroundColor = Helpers.Visual.GetUIColor( VisualDesign.LIST_BACKGROUND_COLOR);
			}
		}
	}
}

