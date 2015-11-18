using System;
using System.Collections.Generic;
using System.Linq;

namespace BrewBuddy.Shared
{
	public static class Constants
	{
		public static class Text
		{
			public static readonly string MAIN_PAGE_TITLE = "Beer Buddy";
			public static readonly string BEER_TAB_TITLE = "Beer";
			public static readonly string BREWERY_TAB_TITLE = "Breweries";
			public static readonly string NO_ITEMS_FOUND = "No items found";
			public static readonly string FAVORITES_TAB_TITLE = "Favorites";
			public static readonly string FAVORITE_BEERS_TITLE = "Favorite beers";
			public static readonly string FAVORITE_BREWERIES_TITLE = "Favorite breweries";
		}

		public static class Model
		{
			public const string BEER = "BrewBuddy.Model.Beer";
			public const string BREWERY = "BrewBuddy.Model.Brewery";
		}
	}
}

