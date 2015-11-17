using System;
using SQLite.Net.Interop;
using System.IO;
using SQLite.Net;
using SQLite.Net.Async;
using System.Threading.Tasks;
using BrewBuddy.Model;
using System.Collections.Generic;
using BrewBuddy.Shared;
using BrewBuddy.CustomExceptions;

namespace BrewBuddy.Service
{
	public class FavoritesDb : IFavoritesDb
	{
		private const string DATABASE_FILE = "favorites.db";

		private const string TYPE_BEER = "BEER";
		private const string TYPE_BREWERY = "BREWERY";

		protected ISQLitePlatform Platform;
		protected string DatabasePath { get; set; }

		public FavoritesDb (ISQLitePlatform platform, string path)
		{
			Platform = platform;
			DatabasePath = Path.Combine (path, DATABASE_FILE);

			InitializeTable ();
		}

		public Task AddAsync<T>(T item) where T : BaseModel, IFavorite
		{
			var record = new FavoriteRecord () {
				Type = GetType (item),
				Id = item.Id
			};
			return GetAsyncConnection ().InsertAsync (record);
		}

		public Task RemoveAsync<T> (T item) where T : BaseModel, IFavorite
		{
			string type = GetType (item);
			var sql = string.Format ( "DELETE FROM FavoriteRecord WHERE Id = '{0}' AND Type = '{1}'", item.Id, type);

			return GetAsyncConnection ().ExecuteAsync (sql);
		}

		public async Task<bool> IsFavorite<T> (T item) where T :BaseModel, IFavorite
		{ 
			var sql = string.Format ("Select count(*) from FavoriteRecord where Id = '{0}' and Type = '{1}'", item.Id, GetType (item));
			var result = await GetAsyncConnection ().ExecuteScalarAsync<int> (sql);
			return result > 0;
		}

		private void InitializeTable()
		{
			
			using(SQLiteConnection connection = GetConnection())
			{
				connection.CreateTable<FavoriteRecord> ();
			}
		}		

		private SQLiteConnection GetConnection()
		{
			return new SQLiteConnection(this.Platform, this.DatabasePath, true);
		}

		private SQLiteAsyncConnection GetAsyncConnection() {
			return new SQLiteAsyncConnection(() => new SQLiteConnectionWithLock(this.Platform, new SQLiteConnectionString(this.DatabasePath, true)));
		}

		private string GetType<T>(T item)
		{
			var type = typeof(T).ToString();

			switch (type) 
			{
			case Constants.Model.BREWERY:
				return TYPE_BREWERY;
			case Constants.Model.BEER:
				return TYPE_BEER;
			default:
				throw new WrongArgumentException ();
			}
		}

		private class FavoriteRecord
		{
			public string Id { get; set; }
			public string Type { get; set; }
		}
	}
}

