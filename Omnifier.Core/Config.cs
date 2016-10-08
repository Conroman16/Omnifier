using Microsoft.Win32;

namespace Omnifier.Core
{
	public static class Config
	{
		public static string LocalSenderEmail => $"omnifier@{MailgunDomainName}";

		public static string MailgunDomainName
		{
			get
			{
				return Get(nameof(MailgunDomainName));
			}
			private set
			{
				Set(nameof(MailgunDomainName), value);
			}
		}

		public static string MailgunApiKey
		{
			get
			{
					return Get(nameof(MailgunApiKey));
			}
			private set
			{
				Set(nameof(MailgunApiKey), value);
			}
		}

		public static string OmniSyncEmail
		{
			get
			{
				return Get(nameof(OmniSyncEmail));
			}
			private set
			{
				Set(nameof(OmniSyncEmail), value);
			}
		}

		private static string Get(string valueName, string defaultValue = null)
		{
			return (string)Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Omnifier", valueName, defaultValue);
		}

		private static void Set(string valueName, string value)
		{
			var key = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
			key = key?.CreateSubKey("Omnifier");
			key?.SetValue(valueName, value, RegistryValueKind.String);
		}
	}
}
