using System;
using SQLite.Net.Interop;

namespace BrewBuddy
{
	public interface IEnvironment
	{
		string PersonalFolder{ get;}
		ISQLitePlatform DatabasePlatform { get; }
		int ScreenWidth { get; }
		int ScreenHeight { get; }
	}
}

