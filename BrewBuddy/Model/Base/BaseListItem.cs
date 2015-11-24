using System;
using PropertyChanged;

namespace BrewBuddy.Model
{
	[ImplementPropertyChanged]
	public class BaseListItem : BaseModel, IIndexed , IFavorite
	{
		public int Index { get; set; }
		public bool IsFavorite { get; set; }
	}
}

