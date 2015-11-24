using System;
using PropertyChanged;

namespace BrewBuddy.Model
{
	[ImplementPropertyChanged]
	public class Srm : BaseModel
	{
		public string Hex { get; set; }
	}
}

