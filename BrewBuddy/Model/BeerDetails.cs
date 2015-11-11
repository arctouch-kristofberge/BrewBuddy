﻿using System;

namespace BrewBuddy.Model
{
	public class BeerDetails : IDetailsModel
	{
		public string Id { get; set; } 
		public string Name { get; set; }
		public string Description { get; set; }
		public string FoodPairings { get; set; }
		public string OriginalGravity { get; set; }
		public string Abv { get; set; }
		public string Ibu { get; set; }
		public string GlasswareId { get; set; }
		public string StyleId { get; set; }
		public string IsOrganic { get; set; }
		public string Labels { get; set; }
		public string ServingTemperatureDisplay { get; set; }
		public string StatusDisplay { get; set; }
		//public Available Available { get; set; }
		public string BeerVariation { get; set; }
		public string Year { get; set; }
	}
}

