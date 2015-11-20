using System;
using BrewBuddy.ViewModel;
using BrewBuddy.Model;
using BrewBuddy.Service;
using BrewBuddy.CustomExceptions;
using Xamarin.Forms;

namespace BrewBuddy.Shared
{
	public class Factory
	{ 
		public ListTabViewModel<T> GetListTabViewModel<T>() where T : BaseModel
		{
			var db = ((App)Application.Current).BreweryDb;
			var type = typeof(T).ToString();

			switch (type) 
			{
			case Constants.Model.BREWERY:
				return new ListTabViewModel<Brewery> (async (s) => await db.GetBreweries (s), Constants.Text.BREWERY_TAB_TITLE) as ListTabViewModel<T>;
			case Constants.Model.BEER:
				return new ListTabViewModel<Beer> (async (s) => await db.GetBeers (s), Constants.Text.BEER_TAB_TITLE) as ListTabViewModel<T>;
			default:
				throw new WrongArgumentException ();
			}
		}
	}
}

