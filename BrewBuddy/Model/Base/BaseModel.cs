using System;
using PropertyChanged;

namespace BrewBuddy.Model
{
	[ImplementPropertyChanged]
	public class BaseModel : IBaseModel
	{
		public string Id { get; set; }
	}
}