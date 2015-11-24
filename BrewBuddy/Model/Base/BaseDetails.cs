using System;

namespace BrewBuddy.Model
{
	public class BaseDetails : BaseModel, IFavorite
	{
		public bool IsFavorite { get; set; }
	}
}

