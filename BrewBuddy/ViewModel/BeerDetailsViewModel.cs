﻿using System;
using BrewBuddy.Model;
using BrewBuddy.Service;
using PropertyChanged;
using BrewBuddy.Shared;
using BrewBuddy.CustomExceptions;
using System.Collections.Generic;

namespace BrewBuddy.ViewModel
{
	[ImplementPropertyChanged]
	public class BeerDetailsViewModel : BaseDataViewModel
	{
		private BeerDetails _beer;

		public string Header { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string FoodPairings { get; set; }
		public string OriginalGravity { get; set; }
		public string Abv { get; set; }
		public string Ibu { get; set; }
		public Glass Glass { get; set; }
		public string IsOrganic { get; set; }
		public Images Labels { get; set; }
		public string ServingTemperatureDisplay { get; set; }
		public string TemperatureForServingView { get; set;}
		public string StatusDisplay { get; set; }
		public Available Available { get; set; }
		public string BeerVariation { get; set; }
		public string Year { get; set; }
		public string ImageUri{ get; set; }
		public List<BreweryListItem> Breweries { get; set; }
		public Srm Srm { get; set; }
		public Style Style { get; set; }

		public BeerDetailsViewModel (BeerListItem beer)
		{
			SetDataLoading (true);

			try
			{
				FillDetails (beer.Id);
			}
			catch(NoItemsFoundException)
			{
				Header = Constants.Text.NO_ITEMS_FOUND;
			}

			SetDataLoading (false);
		}

		private async void FillDetails(string id)
		{
			_beer = await BreweryDb.GetBeerDetails (id);

			FillNormalProperties ();

			FillOtherProperties ();
		}

		private void FillNormalProperties ()
		{
			Name = _beer.Name;
			Description = _beer.Description;
			FoodPairings = _beer.FoodPairings;
			OriginalGravity = _beer.OriginalGravity;
			Abv = _beer.Abv;
			Ibu = _beer.Ibu;
			Glass = _beer.Glass;
			IsOrganic = _beer.IsOrganic;
			Labels = _beer.Labels;
			ServingTemperatureDisplay = _beer.ServingTemperatureDisplay;
			StatusDisplay = _beer.StatusDisplay;
			Available = _beer.Available;
			BeerVariation = _beer.BeerVariation;
			Year = _beer.Year;
			Breweries = _beer.Breweries;
			Srm = _beer.Srm;
			Style = _beer.Style;
		}
		
		private void FillOtherProperties ()
		{
			ImageUri = Labels != null ? Labels.Large : string.Empty;
			TemperatureForServingView = GetTemperatureForServingView ();
			Title = Name;
			Header = GetHeaderText ();
		}

		private string GetTemperatureForServingView()
		{
			if (!string.IsNullOrWhiteSpace (_beer.ServingTemperature))
				return _beer.ServingTemperature;
			else if (!string.IsNullOrWhiteSpace (ServingTemperatureDisplay))
				return ServingTemperatureDisplay.Split (new char[] {'-'}, 1)[0].Trim ().ToLower ();
			else
				return string.Empty;
		}

		private string GetHeaderText()
		{
			var headerText = Name;
			if (!string.IsNullOrEmpty (Year))
				headerText += string.Format (" ({0})", Year);

			return headerText;
		}
	}
}

