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
		private bool _cellColorsSet = false;
		
		protected override void OnElementChanged (ElementChangedEventArgs<ListView> e)
		{
			base.OnElementChanged (e);

			if(e.OldElement!=null)
			{
				e.OldElement.ItemAppearing -= ItemAppearing;
				e.OldElement.PropertyChanging -= PropertyChanging;
			}

			if(e.NewElement != null)
			{
				e.NewElement.ItemAppearing += ItemAppearing;
				e.NewElement.PropertyChanging += PropertyChanging;


				var list = Control as UITableView;
				list.SeparatorStyle = UITableViewCellSeparatorStyle.None;
				list.BackgroundColor = Helpers.Visual.GetUIColor( VisualDesign.LIST_BACKGROUND_COLOR);
			}
		}

		private void PropertyChanging (object sender, Xamarin.Forms.PropertyChangingEventArgs e)
		{
			if (e.PropertyName == "ItemsSource")
				_cellColorsSet = false;
		}

		private void ItemAppearing(object sender, ItemVisibilityEventArgs e)
		{
			var itemsSource = ((ListView)sender).ItemsSource; 
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

		private int GetItemIndex(BaseModel item, IEnumerable items)
		{
			var itemsList = new List<BaseModel> ();
			if(itemsList!=null)
			{
				return itemsList.IndexOf (item);
			}
			else
			{
				throw new NoItemsFoundException ();
			}
		}

		private void SetCellColors (UITableViewCell[] cells)
		{
			for (int i = 0; i < cells.Length; i++) {
				
			}
		}
	}
}

