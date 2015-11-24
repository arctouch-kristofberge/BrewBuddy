using System;
using PropertyChanged;

namespace BrewBuddy.Model
{
	[ImplementPropertyChanged]
	public class BaseDataModel : IBaseModel, IFavorite
	{
		public string Id { get; set; }
		public bool IsFavorite { get; set; }
	}
}