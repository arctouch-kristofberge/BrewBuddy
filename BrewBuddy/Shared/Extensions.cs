using System;
using System.Collections.Generic;
using System.Linq;
using BrewBuddy.Model;

namespace BrewBuddy.Shared
{
	public static class Extensions
	{
		public static void SetIsFavorite<T>(this IList<T> list, bool isFavorite) where T : IFavorite
		{
			list.Select (x => { x.IsFavorite = isFavorite; return x; }).ToList ();
		}

		public static void SetIndexes<T>(this IList<T> list) where T : IIndexed
		{
			list.Select (x => { x.Index = list.IndexOf (x); return x; }).ToList ();
		}
	}
}

