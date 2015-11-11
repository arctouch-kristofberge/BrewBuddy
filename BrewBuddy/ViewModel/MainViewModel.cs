using System;
using BrewBuddy.Shared;
using PropertyChanged;

namespace BrewBuddy.ViewModel
{
	[ImplementPropertyChanged]
	public class MainViewModel : BaseViewModel
	{
		public MainViewModel ()
		{
			Title = Constants.Text.MAIN_PAGE_TITLE;
		}
	}
}

