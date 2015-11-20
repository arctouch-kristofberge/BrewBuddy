using System;
using Xamarin.Forms;
using BrewBuddy.View.Custom;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using BrewBuddy.Design;
using System.Collections.Generic;
using BrewBuddy.Model;
using System.Collections.ObjectModel;
using System.Collections;
using BrewBuddy.CustomExceptions;

[assembly: ExportRenderer(typeof(MyViewCell), typeof(BrewBuddy.iOS.Renderers.MyViewCellRenderer))]
namespace BrewBuddy.iOS.Renderers
{
	public class MyViewCellRenderer : ViewCellRenderer
	{
//		public override UITableViewCell GetCell (Cell item, UITableViewCell reusableCell, UITableView tv)
//		{
//			UITableViewCell cell = new UITableViewCell();
//			var models = ((ListView)item.Parent).ItemsSource;
//			var myModel = item.BindingContext as BaseModel;
//
//			try 
//			{
//				int cellIndex = GetCellIdex (models, myModel);
//				if (cellIndex % 2 == 0)
//					cell.BackgroundColor = Helpers.Visual.GetUIColor (Color.Red);
//				else
//					cell.BackgroundColor = Helpers.Visual.GetUIColor (Color.Red);
//			} 
//			catch (NoItemsFoundException) { }
//				
//			return cell; 
//		}
//
//		private int GetCellIdex (IEnumerable models, BaseModel myModel)
//		{
//			int cellIndex = 0;
//			for (var i = models.GetEnumerator (); i.MoveNext ();) {
//				var model = i.Current;
//				if (model == myModel)
//					return cellIndex;
//				cellIndex++;
//			}
//			throw new NoItemsFoundException ();
//		}
	}
}

