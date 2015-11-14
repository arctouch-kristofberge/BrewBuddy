using System;
using Xamarin.Forms;
using BrewBuddy.View.Custom;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SearchResultsList),typeof(BrewBuddy.iOS.Renderers.SearchResultsListRenderer)) ]
namespace BrewBuddy.iOS.Renderers
{
	public class SearchResultsListRenderer : ListViewRenderer
	{
		public SearchResultsListRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<ListView> e)
		{
			base.OnElementChanged (e);

			if(e.NewElement != null)
			{
				
			}
		}
	}
}

