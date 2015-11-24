using System;
using BrewBuddy.Model;

namespace BrewBuddy.Event
{
	public class FavoriteToggledEventArgs : EventArgs
	{
		public BaseDataModel Item { get; set; }
		public bool IsFavorite { get; set; }
	}
}

