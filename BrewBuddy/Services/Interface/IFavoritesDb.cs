using System;
using System.Threading.Tasks;
using BrewBuddy.Model;
using System.Collections.Generic;

namespace BrewBuddy
{
	public interface IFavoritesDb
	{
		Task AddAsync<T>(T item) where T : BaseDataModel;
		Task RemoveAsync<T> (T item) where T : BaseDataModel;
		Task<bool> IsFavorite<T> (T item) where T :BaseDataModel;
		Task<List<string>> GetAllIds<T> () where T : BaseDataModel;
	}
}

