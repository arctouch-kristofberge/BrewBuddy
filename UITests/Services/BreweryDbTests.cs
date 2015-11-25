using System;
using NUnit.Framework;
using BrewBuddy.Service;
using Moq;
using BrewBuddy.Model;
using System.Collections.Generic;
using System.Linq;

namespace BrewBuddy.UITests
{
	public class BreweryDbTests
	{
		#region Setup

		private Mock<BreweryDb> _breweryDb;

		[SetUp]
		public void Setup()
		{
			_breweryDb = new Mock<BreweryDb>(){CallBase = true};
		}
		#endregion

		#region Tests with real api
		// These tests are ignored, because they take too long to run.
		// To run tests, remove Ignore attributes.

		#region ListItems
		[Test]
		[Ignore]
		public void GetBeers_ReturnsResults()
		{
			//Act
			var result = _breweryDb.Object.GetBeers ("duvel").Result;

			//Assert
			Assert.IsTrue (result.Count > 0);
		}

		[Test]
		[Ignore]
		public void GetBreweries_ReturnsResults()
		{
			//Act
			var result = _breweryDb.Object.GetBreweries ("moortgat").Result;

			//Assert
			Assert.IsTrue (result.Count > 0);
		}

		[Test]
		[Ignore]
		public void GetItemsByIdBeer_ReturnsCorrectResults()
		{
			//Arrange
			List<string> ids = new List<string> (){ "9AE30A", "tAmjew", "FsjaTu" };
			List<string> expected = new List<string> (){ "Houblon Chouffe Ale", "Duvel Green", "Pauwel Kwak" };

			//Act
			var result = _breweryDb.Object.GetListItemsById<BeerListItem> (ids).Result;

			//Assert
			foreach(var r in result)
				Assert.IsTrue (expected.Any(x => x == r.Name));
		}

		[Test]
		[Ignore]
		public void GetItemsByIdBrewery_ReturnsCorrectResults()
		{
			//Arrange
			List<string> ids = new List<string> (){ "fO5IlN", "RUg90U", "D7h5Pj" };
			List<string> expected = new List<string> (){ "Brouwerij Duvel Moortgat", "InBev", "Brasserie D'Achouffe" };

			//Act
			var result = _breweryDb.Object.GetListItemsById<BreweryListItem> (ids).Result;

			//Assert
			foreach(var r in result)
				Assert.IsTrue (expected.Any(x => x == r.Name));
		}

		[Test]
		[Ignore]
		public void GetBreweriesByLocation_ReturnsResults()
		{
			//Arrange
			double lat = 50.847598; double lng = 4.352020; // The center of Brussels, Belgium
			int radius = 10;

			//Act
			var result = _breweryDb.Object.GetBreweriesByLocation (lat, lng, radius).Result;

			//Assert
			Assert.IsTrue (result.Count > 0);

		}
		#endregion

		#region Details
		[TestCase("9AE30A", "Houblon Chouffe Ale")]
		[TestCase("tAmjew", "Duvel Green")]
		[TestCase("FsjaTu", "Pauwel Kwak")]
		[Ignore]
		public void GetBeerDetails_ResturnsCorrectResult(string id, string expectedName)
		{
			//Act
			var result = _breweryDb.Object.GetBeerDetails (id).Result;

			//Assert
			Assert.AreEqual (expectedName, result.Name);
		}

		[TestCase("fO5IlN", "Brouwerij Duvel Moortgat")]
		[TestCase("RUg90U", "InBev")]
		[TestCase("D7h5Pj", "Brasserie D'Achouffe")]
		[Ignore]
		public void GetBreweryDetails_ReturnsCorrectResult(string id, string expectedName)
		{
			//Act
			var result = _breweryDb.Object.GetBreweryDetails (id).Result;

			//Assert
			Assert.AreEqual (expectedName, result.Name);
		}
		#endregion
		#endregion
	}
}