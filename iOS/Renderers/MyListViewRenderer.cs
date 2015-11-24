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

			if(e.OldElement!=null)
			{
				e.OldElement.ItemAppearing -= ItemAppearing;
				e.OldElement.PropertyChanged -= PropertyChanged;
			}

			if(e.NewElement != null)
			{
				e.NewElement.ItemAppearing += ItemAppearing;
				e.NewElement.PropertyChanged += PropertyChanged;

				var list = Control as UITableView;
				list.SeparatorStyle = UITableViewCellSeparatorStyle.None;
				list.BackgroundColor = Helpers.Visual.GetUIColor( VisualDesign.LIST_BACKGROUND_COLOR);
			}
		}



		private void PropertyChanged (object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "IsVisible" && ((ListView)sender).IsVisible && Control.VisibleCells !=null && Control.VisibleCells.Length>0)
				SetColorsOfAllCells ();
		}

		private void ItemAppearing(object sender, ItemVisibilityEventArgs e)
		{
			SetColorsOfAllCells ();
		}

		private int GetItemIndex(BaseDataModel item, IEnumerable items)
		{
			var itemsList = new List<BaseDataModel> ();
			if(itemsList!=null)
			{
				return itemsList.IndexOf (item);
			}
			else
			{
				throw new NoItemsFoundException ();
			}
		}

		private void SetColorsOfAllCells ()
		{
			var indexOfFirstCell = Control.IndexPathsForVisibleRows[0].Item;
			var cells = ((UITableView)Control).VisibleCells;

			nint index = indexOfFirstCell;
			foreach(var cell in cells)
			{
				if (index % 2 == 0)
					cell.BackgroundColor = Helpers.Visual.GetUIColor (VisualDesign.LISTITEM_EVENCELL_BACKGROUND_COLOR);
				else
					cell.BackgroundColor = Helpers.Visual.GetUIColor (VisualDesign.LISTITEM_UNEVENCELL_BACKGROUND_COLOR);
				index++; 
			}
		}
	}
}

