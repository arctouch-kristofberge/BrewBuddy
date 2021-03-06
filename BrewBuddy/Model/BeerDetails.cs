﻿using System;
using PropertyChanged;
using System.Collections.Generic;

namespace BrewBuddy.Model
{
	[ImplementPropertyChanged]
	public class BeerDetails : BaseDetails
	{
		public string Description { get; set; }
		public string FoodPairings { get; set; }
		public string OriginalGravity { get; set; }
		public string Abv { get; set; }
		public string Ibu { get; set; }
		public Glass Glass { get; set; }
		public string IsOrganic { get; set; }
		public Images Labels { get; set; }
		public string ServingTemperature { get; set; }
		public string ServingTemperatureDisplay { get; set; }
		public string StatusDisplay { get; set; }
		public Available Available { get; set; }
		public string BeerVariation { get; set; }
		public string Year { get; set; }
		public List<BreweryListItem> Breweries { get; set; }
		public Srm Srm { get; set; }
		public Style Style { get; set; }
	}
}

