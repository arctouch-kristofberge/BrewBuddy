using System;

namespace BrewBuddy.Model
{
	public class Beer : IListItemModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string BreweryName { get; set; }
	}
}

