using System;
using PropertyChanged;

namespace BrewBuddy.Model
{
	[ImplementPropertyChanged]
	public class Srm : BaseModel
	{
		public string Name { get; set; }
		public string Hex { get; set; }
	}
}

