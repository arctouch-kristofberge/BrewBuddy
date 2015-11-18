using System;
using System.Collections.Generic;
using System.Linq;

namespace BrewBuddy.Shared
{
	public static class Extensions
	{
		public static void SetIsFavorite<T>(this IList<T> list, bool isFavorite) where T : IFavorite
		{
			list.Select (x => { x.IsFavorite = isFavorite; return x; }).ToList ();
		}
	}
}

