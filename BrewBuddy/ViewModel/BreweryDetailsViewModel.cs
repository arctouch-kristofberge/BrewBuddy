using System;
using BrewBuddy.Model;
using BrewBuddy.Service;
using BrewBuddy.CustomExceptions;
using BrewBuddy.Shared;
using System.Threading.Tasks;
using PropertyChanged;

namespace BrewBuddy.ViewModel
{
	[ImplementPropertyChanged]
	public class BreweryDetailsViewModel : BaseDataViewModel
	{
		private BreweryDetails _brewery;

		public string Header { get; set; }


		public string Name { get; set;}
		public string Description { get; set;}
		public string Website { get; set;}
		public string Established { get; set;}
		public string MailingListUrl { get; set;}
		public string IsOrganic { get; set;}
		public Images Images { get; set;}


		public BreweryDetailsViewModel (BreweryListItem brewery)
		{
			SetDataLoading (true);

			try
			{
				FillDetails (brewery.Id);
			}
			catch (NoItemsFoundException)
			{
				Header = Constants.Text.NO_ITEMS_FOUND;
			}
			Title = Name;

			SetDataLoading (false);
		}

		private async void FillDetails (string id)
		{
			_brewery = await BreweryDb.GetBreweryDetails (id);
			Name = _brewery.Name;
			Description = _brewery.Description;
			Website = _brewery.Website;
			Established = _brewery.Established;
			MailingListUrl = _brewery.MailingListUrl;
			IsOrganic = _brewery.IsOrganic;
			Images = _brewery.Images;

			Header = string.Format ("{0} ({1})", Name, Established);
		}
	}
}

