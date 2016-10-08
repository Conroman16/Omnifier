using System.Collections.Generic;
using System.Linq;
using cm = System.Configuration.ConfigurationManager;

namespace Omnifier.UI
{
	public static class Config
	{
		public static string AppTitle => GetSetting("AppTitle");

		public static Dictionary<string, string> AllSettings => GetAllSettings();

		private static string GetSetting(string key) => cm.AppSettings[key];

		private static Dictionary<string, string> GetAllSettings()
		{
			return cm.AppSettings.AllKeys.ToDictionary(key => key, key => cm.AppSettings[key]);
		}
	}
}
