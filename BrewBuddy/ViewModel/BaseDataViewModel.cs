using System;
using PropertyChanged;

namespace BrewBuddy.ViewModel
{
	[ImplementPropertyChanged]
	public abstract class BaseDataViewModel : BaseViewModel
	{
		public bool IsLoading { get; set; }
		public bool IsDataVisible { get; set; }

		public BaseDataViewModel ()
		{
			IsLoading = false;
			IsDataVisible = false;
		}

		protected void SetDataLoading(bool isDataLoading)
		{
			IsLoading = isDataLoading;
			IsDataVisible = !isDataLoading;
		}
	}
}

