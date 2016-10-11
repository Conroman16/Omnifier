namespace Omnifier.UI.Models
{
	public class SettingsModel
	{
		public string MailgunApiKey { get; set; }
		public string MailgunDomainName { get; set; }
		public string OmniSyncEmail { get; set; }

		public void Save()
		{
			Core.Config.MailgunApiKey = MailgunApiKey;
			Core.Config.MailgunDomainName = MailgunDomainName;
			Core.Config.OmniSyncEmail = OmniSyncEmail;
		}
	}
}
