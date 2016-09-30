using System;
using System.Collections.Generic;
using System.Linq;
using cm = System.Configuration.ConfigurationManager;

namespace Omnifier.UI
{
	public static class Config
	{
		public static string AppTitle => GetSetting("AppTitle");

		public static IEnumerable<string> AllSettings => GetAllSettings();

		private static string GetSetting(string key)
		{
			return cm.AppSettings[key];
		}

		private static IEnumerable<string> GetAllSettings()
		{
			return cm.AppSettings.AllKeys.Select(key => cm.AppSettings[key]);
		}
	}
}
