using System;
using BrewBuddy.Model;
using BrewBuddy.Service;
using PropertyChanged;
using BrewBuddy.Shared;
using BrewBuddy.CustomExceptions;

namespace BrewBuddy.ViewModel
{
	[ImplementPropertyChanged]
	public class BeerDetailsViewModel : BaseDataViewModel
	{
		private BeerDetails _beer;
		private BreweryDb _breweryDb;

		public string Header { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string FoodPairings { get; set; }
		public string OriginalGravity { get; set; }
		public string Abv { get; set; }
		public string Ibu { get; set; }
		public string GlasswareId { get; set; }
		public string StyleId { get; set; }
		public string IsOrganic { get; set; }
		public Images Labels { get; set; }
		public string ServingTemperatureDisplay { get; set; }
		public string StatusDisplay { get; set; }
		public Available Available { get; set; }
		public string BeerVariation { get; set; }
		public string Year { get; set; }

		public BeerDetailsViewModel (Beer beer)
		{
			SetDataLoading (true);

			_breweryDb = new BreweryDb ();

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
			_beer = await _breweryDb.GetBeerDetails (id);

			Name = _beer.Name;
			Description = _beer.Description;
			FoodPairings = _beer.FoodPairings;
			OriginalGravity = _beer.OriginalGravity;
			Abv = _beer.Abv;
			Ibu = _beer.Ibu;
			GlasswareId = _beer.GlasswareId;
			StyleId = _beer.StyleId;
			IsOrganic = _beer.IsOrganic;
			Labels = _beer.Labels;
			ServingTemperatureDisplay = _beer.ServingTemperatureDisplay;
			StatusDisplay = _beer.StatusDisplay;
			Available = _beer.Available;
			BeerVariation = _beer.BeerVariation;
			Year = _beer.Year;

			Title = Name;
			Header = GetHeaderText();
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

