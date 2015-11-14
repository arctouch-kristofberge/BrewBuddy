using System;
using Xamarin.Forms;
using BrewBuddy.View.Custom;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using BrewBuddy.Design;

[assembly: ExportRenderer(typeof(TwoLinesViewCell), typeof(BrewBuddy.iOS.Renderers.TwoLinesViewCellRenderer))]
namespace BrewBuddy.iOS.Renderers
{
	public class TwoLinesViewCellRenderer : ViewCellRenderer
	{
		public override UITableViewCell GetCell (Cell item, UIKit.UITableViewCell reusableCell, UIKit.UITableView tv)
		{
			UITableViewCell cell = base.GetCell (item, reusableCell, tv);

			if(cell != null)
			{
				foreach(UIView view in cell.Subviews)
				{
					foreach(UIView subView in view.Subviews)
					{
						var firstLabel = subView as LabelRenderer;

						if (firstLabel != null)
						{
							firstLabel.BackgroundColor = Helpers.Visual.GetUIColor ( VisualDesign.LISTITEM_FIRSTLINE_BACKGROUND_COLOR);
							firstLabel.Layer.BorderWidth = 0;
						}
						else
						{
							foreach(UIView subSubView in subView.Subviews)
							{
								var secondLabel = subSubView as LabelRenderer;
								if(secondLabel!=null)
								{
									secondLabel.BackgroundColor = Helpers.Visual.GetUIColor ( VisualDesign.LISTITEM_SECONDLINE_BACKGROUND_COLOR);
									secondLabel.Layer.BorderWidth = 0;
								}
							}
						}
					}
				}
				
			}


			return cell;
		}
	}
}

