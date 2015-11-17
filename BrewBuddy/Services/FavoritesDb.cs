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
using System.Linq;

namespace BrewBuddy.Service
{
	public class FavoritesDb : IFavoritesDb
	{
		#region Constants
		private const string DATABASE_FILE = "favorites.db";

		private const string TYPE_BEER = "BEER";
		private const string TYPE_BREWERY = "BREWERY";
		#endregion

		#region Members
		protected ISQLitePlatform Platform;
		protected string DatabasePath { get; set; }
		#endregion

		public FavoritesDb (ISQLitePlatform platform, string path)
		{
			Platform = platform;
			DatabasePath = Path.Combine (path, DATABASE_FILE);

			InitializeTable ();
		}

		#region Public
		public Task AddAsync<T>(T item) where T : BaseModel
		{
			var record = new FavoriteRecord () {
				Type = GetType<T> (),
				Id = item.Id
			};
			return GetAsyncConnection ().InsertAsync (record);
		}

		public Task RemoveAsync<T> (T item) where T : BaseModel
		{
			string type = GetType<T>();
			var sql = string.Format ( "DELETE FROM FavoriteRecord WHERE Id = '{0}' AND Type = '{1}'", item.Id, type);

			return GetAsyncConnection ().ExecuteAsync (sql);
		}
		
		public async Task<bool> IsFavorite<T> (T item) where T :BaseModel
		{ 
			var sql = string.Format ("Select count(*) from FavoriteRecord where Id = '{0}' and Type = '{1}'", item.Id, GetType<T>());
			var result = await GetAsyncConnection ().ExecuteScalarAsync<int> (sql);
			return result > 0;
		}

		public async Task<List<string>> GetAllIds<T> () where T : BaseModel
		{
			string type = GetType<T> ();
			List<FavoriteRecord> records = await GetAsyncConnection ()
				.Table<FavoriteRecord> ()
				.Where (x => x.Type.Equals (type))
				.ToListAsync ();
			return records.Select (x => x.Id).ToList ();
		}
		#endregion

		#region Private
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

		private string GetType<T>()
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
		#endregion
	}
}

