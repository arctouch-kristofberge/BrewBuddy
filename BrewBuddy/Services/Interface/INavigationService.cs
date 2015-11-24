using System;
using BrewBuddy.Model;
using System.Threading.Tasks;

namespace BrewBuddy.Service
{
	public interface INavigationService
	{
		Task NavigateToDetails<T>(T item) where T : BaseDataModel;
	}
}

