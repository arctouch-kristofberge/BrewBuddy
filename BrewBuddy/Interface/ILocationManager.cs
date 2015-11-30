using System;
using BrewBuddy.Model;
using System.Threading.Tasks;

namespace BrewBuddy
{
	public interface ILocationManager
	{
		void StartLocationManager (Action<MyLocation> callBack);
	}
}

