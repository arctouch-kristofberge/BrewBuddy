using System;
using PropertyChanged;

namespace BrewBuddy.Model
{
	[ImplementPropertyChanged]
	public class Style : BaseModel
	{
		public string CategoryId { get; set; }
		public Category Category { get; set; }
		public string ShortName { get; set; }
		public string Description { get; set; }
	}
}

