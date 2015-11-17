using System;

namespace BrewBuddy.Model
{
	public class BaseModel : IBaseModel, IFavorite
	{
		public string Id { get; set; }
		public bool IsFavorite { get; set; }
	}
}