using System;

namespace BrewBuddy.Model
{
	public class Beer : BaseModel, IListItem
	{
		public string Name { get; set; }
		public string BreweryName { get; set; }
	}
}

