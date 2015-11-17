using System;
using BrewBuddy.Model;

namespace BrewBuddy.Event
{
	public class FavoriteToggledEventArgs : EventArgs
	{
		public BaseModel Item { get; set; }
		public bool IsFavorite { get; set; }
	}
}

